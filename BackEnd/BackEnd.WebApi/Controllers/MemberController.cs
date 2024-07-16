using System.Net;
using BackEnd.Application.Dtos;
using BackEnd.Application.Model;
using BackEnd.Application.Services;
using BackEnd.Domain.Base.Uow;
using BackEnd.Domain.Entity.Entities;
using BackEnd.Domain.Ums.Entities;
using BackEnd.Infrastructure.Base.ApiController;
using BackEnd.Infrastructure.Base.ApiResponse;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.WebApi.Controllers;

// [Authorize]
[ApiController]
[Route("/api/member")]
public class MemberController : BaseController<Member, Guid, MemberDetailDto,
    MemberDetailDto,
    MemberCreateDto,
    MemberUpdateDto>
{
    private readonly IMemberService _memberService;
    public MemberController(IMemberService entityService, IMemberService memberService) : base(entityService)
    {
        _memberService = memberService;
    }

    [HttpGet("get-combo-option-member")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public virtual async Task<ApiResponse<List<ComboOption<Guid, string>>>> HandleGetComboOptionMemberAction(
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await _memberService.GetComboOptionMemberCanBorrow(cancellationToken);

            return ApiResponse<List<ComboOption<Guid, string>>>.Ok(result);
        }
        catch (Exception e)
        {
            return ApiResponse<List<ComboOption<Guid, string>>>.Error(e.Message);
        }
    }
}