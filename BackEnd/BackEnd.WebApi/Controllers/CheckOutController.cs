using BackEnd.Application.Dtos;
using BackEnd.Application.Services;
using BackEnd.Domain.Base.Service;
using BackEnd.Domain.Entity.Entities;
using BackEnd.Infrastructure.Base.ApiController;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.WebApi.Controllers;

[ApiController]
[Route("/api/check-out")]
public class CheckOutController : BaseController<CheckOut, Guid, CheckOutDetailDto,
    CheckOutDetailDto,
    CheckOutCreateDto,
    CheckOutUpdateDto>
{
    public CheckOutController(ICheckOutService entityService) : base(entityService)
    {
    }
}