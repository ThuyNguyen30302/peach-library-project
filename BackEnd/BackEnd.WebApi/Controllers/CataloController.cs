using BackEnd.Application.Dtos;
using BackEnd.Application.Services;
using BackEnd.Domain.Entities;
using BackEnd.Infrastructure.Base.ApiController;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.WebApi.Controllers;

// [Authorize]
[ApiController]
[Route("/api/catalo")]
public class CataloController: BaseController<Catalo, Guid, CataloDetailDto,
    CataloDetailDto,
    CataloCreateDto,
    CataloUpdateDto>
{
    public CataloController(ICataloService entityService) : base(
        entityService)
    {
    }
}