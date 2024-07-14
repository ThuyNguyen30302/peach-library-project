using BackEnd.Application.Dtos;
using BackEnd.Application.Services;
using BackEnd.Domain.Entity.Entities;
using BackEnd.Infrastructure.Base.ApiController;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.WebApi.Controllers;

[ApiController]
[Route("/api/hold")]
public class HoldController: BaseController<Hold, Guid, HoldDetailDto,
    HoldDetailDto,
    HoldCreateDto,
    HoldUpdateDto>
{
    public HoldController(IHoldService entityService) : base(entityService)
    {
    }
}