using System.Net;
using BackEnd.Application.Dtos;
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

    public MemberController(IMemberService entityService) : base(entityService)
    {
    }

    // [HttpPost("create")]
    // [ProducesResponseType((int)HttpStatusCode.OK)]
    // [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    // [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    // public override async Task<ApiResponse<MemberDetailDto>> HandleCreateAction([FromBody] MemberCreateDto request,
    //     CancellationToken cancellationToken)
    // {
    //     using (var transaction = await _unitOfWork.BeginTransactionAsync())
    //     {
    //         try
    //         {
    //             var user = new User() { UserName = request.UserName, Email = request.Email };
    //             var userCreateResult = await _userManager.CreateAsync(user, request.Password);
    //
    //             if (!userCreateResult.Succeeded)
    //             {
    //                 return ApiResponse<MemberDetailDto>.Error(string.Join("; ", userCreateResult.Errors.Select(e => e.Description)));
    //             }
    //
    //             request.UserId = user.Id;
    //             request.Password = user.PasswordHash;
    //
    //             var result = await _memberService.CreateAsync(request, cancellationToken);
    //
    //             await _unitOfWork.CommitAsync();
    //
    //             return ApiResponse<MemberDetailDto>.Ok(result);
    //         }
    //         catch (Exception e)
    //         {
    //             await _unitOfWork.RollbackAsync();
    //
    //             return ApiResponse<MemberDetailDto>.Error(e.Message);
    //         }
    //     }
    // }
}