using System.Net;
using BackEnd.Application.Dtos;
using BackEnd.Application.Model;
using BackEnd.Application.Services;
using BackEnd.Domain.Entity.Entities;
using BackEnd.Infrastructure.Base.ApiController;
using BackEnd.Infrastructure.Base.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.WebApi.Controllers;

// [Authorize]
[ApiController]
[Route("/api/publisher")]
public class PublisherController: BaseController<Publisher, Guid, PublisherDetailDto,
    PublisherDetailDto,
    PublisherCreateDto,
    PublisherUpdateDto>
{
    private readonly IPublisherService _publisherService;

    
    public PublisherController(IPublisherService entityService, IPublisherService publisherService) : base(
        entityService)
    {
        _publisherService = publisherService;
    }
    
    [HttpGet("get-combo-option")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public virtual async Task<ApiResponse<List<ComboOption<Guid, string>>>> HandleGetComboOptionAction(
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await _publisherService.GetComboOptionPublisher(cancellationToken);

            return ApiResponse<List<ComboOption<Guid, string>>>.Ok(result);
        }
        catch (Exception e)
        {
            return ApiResponse<List<ComboOption<Guid, string>>>.Error(e.Message);
        }
    }
}