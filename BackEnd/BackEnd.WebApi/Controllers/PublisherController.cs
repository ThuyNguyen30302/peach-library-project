using BackEnd.Application.Dtos;
using BackEnd.Application.Services;
using BackEnd.Domain.Entities;
using BackEnd.Infrastructure.Base.ApiController;
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
    public PublisherController(PublisherService entityService) : base(
        entityService)
    {
    }
}