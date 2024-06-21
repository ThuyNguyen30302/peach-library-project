using BackEnd.Application.Dtos;
using BackEnd.Application.Services;
using BackEnd.Domain.Entities;
using BackEnd.Infrastructure.Base.ApiController;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.WebApi.Controllers;

// [Authorize]
[ApiController]
[Route("/api/member")]
public class MemberController: BaseController<Member, Guid, MemberDetailDto,
    MemberDetailDto,
    MemberCreateDto,
    MemberUpdateDto>
{
    public MemberController(IMemberService entityService) : base(
        entityService)
    {
    }
}