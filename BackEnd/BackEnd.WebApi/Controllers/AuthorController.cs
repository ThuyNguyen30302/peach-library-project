using System.Net;
using BackEnd.Application.Dtos;
using BackEnd.Application.Services;
using BackEnd.Domain.Base.Spectification;
using BackEnd.Domain.Entities;
using BackEnd.Infrastructure.Base.ApiController;
using BackEnd.Infrastructure.Base.ApiResponse;
using BackEnd.Infrastructure.Base.Spectification;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.WebApi.Controllers;

// [Authorize]
[ApiController]
[Route("/api/author")]
public class AuthorController: BaseController<Author, Guid, AuthorDetailDto,
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
    
    [HttpGet("index")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public override async Task<ApiResponse<List<AuthorDetailDto>>> HandleIndexAction(CancellationToken cancellationToken)
    {
        try
        {
            var result = await _authorService.GetListAsync(cancellationToken);

            result = result.OrderBy(x => x.Name.Split(" ").Last()).ToList();
            return ApiResponse<List<AuthorDetailDto>>.Ok(result);
        }
        catch (Exception e)
        {
            return ApiResponse<List<AuthorDetailDto>>.Error(e.Message);
        }
    }
}