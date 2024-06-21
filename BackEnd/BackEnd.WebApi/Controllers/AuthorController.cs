using BackEnd.Application.Dtos;
using BackEnd.Application.Services;
using BackEnd.Domain.Entities;
using BackEnd.Infrastructure.Base.ApiController;
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
    public AuthorController(IAuthorService entityService) : base(
        entityService)
    {
    }
}