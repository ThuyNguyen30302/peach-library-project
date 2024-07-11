using System.Net;
using BackEnd.Application.Dtos;
using BackEnd.Application.Model;
using BackEnd.Application.Services;
using BackEnd.Domain.Entity.Entities;
using BackEnd.Infrastructure.Base.ApiController;
using BackEnd.Infrastructure.Base.ApiResponse;
using BackEnd.Infrastructure.Base.Spectification;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.WebApi.Controllers;

// [Authorize]
[ApiController]
[Route("/api/author")]
public class AuthorController : BaseController<Author, Guid, AuthorDetailDto,
    AuthorDetailDto,
    AuthorCreateDto,
    AuthorUpdateDto>
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService entityService, IAuthorService authorService) : base(
        entityService)
    {
        _authorService = authorService;
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
            var result = await _authorService.GetComboOptionAuthor(cancellationToken);

            return ApiResponse<List<ComboOption<Guid, string>>>.Ok(result);
        }
        catch (Exception e)
        {
            return ApiResponse<List<ComboOption<Guid, string>>>.Error(e.Message);
        }
    }
}