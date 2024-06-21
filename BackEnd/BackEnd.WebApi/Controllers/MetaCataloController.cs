using BackEnd.Application.Dtos;
using BackEnd.Application.Services;
using BackEnd.Domain.Entities;
using BackEnd.Infrastructure.Base.ApiController;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.WebApi.Controllers;

// [Authorize]
[ApiController]
[Route("/api/meta-catalo")]
public class MetaCataloController: BaseController<MetaCatalo, Guid, MetaCataloDetailDto,
    MetaCataloDetailDto,
    MetaCataloCreateDto,
    MetaCataloUpdateDto>
{
    public MetaCataloController(IMetaCataloService entityService) : base(
        entityService)
    {
    }
}