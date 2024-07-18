using System.Net;
using System.Security.Claims;
using BackEnd.Application.Dtos;
using BackEnd.Domain.Base.Specification;
using BackEnd.Domain.Entity.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Domain.Ums.Entities;
using BackEnd.Infrastructure.Base.ApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace BackEnd.WebApi.Controllers;

[ApiController]
[Route("/api")]
public class CommonController : ControllerBase
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly IMemberRepository _memberRepository;
    private readonly ICheckOutRepository _checkOutRepository;

    public CommonController(SignInManager<User> signInManager, UserManager<User> userManager,
        IMemberRepository memberRepository, ICheckOutRepository checkOutRepository)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _memberRepository = memberRepository;
        _checkOutRepository = checkOutRepository;
    }

    [HttpGet]
    [Route("identity/logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return Ok(new { success = true });
    }

    [HttpPost("identity/login")]
    public async Task<ApiResponse<User>> HandleIndexAction([FromBody] LoginRequestDto request)
    {
        // var user = await _userManager.FindByNameAsync(request.Account);
        // if (user != null)
        // {
        //      await _signInManager.SignInAsync(user, true);
        //      //var userProfile = await GetUserProfile(user);
        //      return ApiResponse<User>.Ok(user);
        // }
        var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false);
        if (result.Succeeded)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName);
            return ApiResponse<User>.Ok(user);
        }
        else
        {
            throw new Exception("Login fail");
        }
    }

    [HttpGet("identity/check-login/{id}")]
    [AllowAnonymous]
    public async Task<ApiResponse<JObject>> CheckLoginAction(Guid id, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user != null)
        {
            var roles = await _userManager.GetRolesAsync(user);
            
            var serializer = new JsonSerializer
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var authData = JObject.FromObject(user, serializer);
            authData.Add("roles", JToken.FromObject(roles));
            if (!roles.Contains("admin"))
            {
                var member = await _memberRepository.FirstOrDefaultAsync(new Specification<Member>(x => x.UserId == id),
                    cancellationToken);
                var checkOut = await _checkOutRepository.FirstOrDefaultAsync(
                    new Specification<CheckOut>(x => x.MemberId == member.Id && !x.IsReturned),
                    cancellationToken);
                authData.Add("memberId", JToken.FromObject(member.Id));
                authData.Add("canBorrow", JToken.FromObject(checkOut == null));
            }
            return ApiResponse<JObject>.Ok(authData);
        }

        return ApiResponse<JObject>.Error("User is not sign in");
    }

    [HttpPost("identity/change-password/{id}")]
    public async Task<ApiResponse<string>> ChangePassword(Guid id, [FromBody] ChangePasswordDto model)
    {
        if (!ModelState.IsValid)
        {
            return ApiResponse<string>.Error("Lỗi xác thực.");
        }

        try
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return ApiResponse<string>.Error("Không thể xác định người dùng hiện tại.");
            }

            var changePasswordResult =
                await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (changePasswordResult.Succeeded)
            {
                return ApiResponse<string>.Ok("Đổi mật khẩu thành công.");
            }
            else
            {
                var errors = changePasswordResult.Errors.Select(e => e.Description);
                return ApiResponse<string>.Error("Đổi mật khẩu thất bại.");
            }
        }
        catch (Exception e)
        {
            return ApiResponse<string>.Error("Đã xảy ra lỗi khi đổi mật khẩu.");
        }
    }
}