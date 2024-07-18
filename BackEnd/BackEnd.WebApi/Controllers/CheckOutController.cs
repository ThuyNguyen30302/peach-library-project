using System.Net;
using BackEnd.Application.Dtos;
using BackEnd.Application.Services;
using BackEnd.Domain.Base.Service;
using BackEnd.Domain.Entity.Entities;
using BackEnd.Infrastructure.Base.ApiController;
using BackEnd.Infrastructure.Base.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.WebApi.Controllers;

[ApiController]
[Route("/api/check-out")]
public class CheckOutController : BaseController<CheckOut, Guid, CheckOutDetailDto,
    CheckOutDetailDto,
    CheckOutCreateDto,
    CheckOutUpdateDto>
{
    private readonly ICheckOutService _checkOutService;

    public CheckOutController(ICheckOutService entityService, ICheckOutService checkOutService) : base(entityService)
    {
        _checkOutService = checkOutService;
    }

    [HttpGet("get-list-check-out/{type}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public virtual async Task<ApiResponse<List<CheckOutDetailDto>>> HandleGetListCheckOutIndexAction(string type,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await _checkOutService.GetListCheckOutAsync(type, cancellationToken);

            return ApiResponse<List<CheckOutDetailDto>>.Ok(result);
        }
        catch (Exception e)
        {
            return ApiResponse<List<CheckOutDetailDto>>.Error(e.Message);
        }
    }
     
    [HttpGet("get-list-check-out-by-member/{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public virtual async Task<ApiResponse<List<CheckOutDetailDto>>> HandleGetListCheckOutByMemberIndexAction(Guid id,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await _checkOutService.GetListCheckOutByMemberAsync(id, cancellationToken);

            return ApiResponse<List<CheckOutDetailDto>>.Ok(result);
        }
        catch (Exception e)
        {
            return ApiResponse<List<CheckOutDetailDto>>.Error(e.Message);
        }
    }
}