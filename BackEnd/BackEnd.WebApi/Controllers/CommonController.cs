using BackEnd.Application.Dtos;
using BackEnd.Domain.Ums.Entities;
using BackEnd.Infrastructure.Base.ApiResponse;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.WebApi.Controllers;

[ApiController]
[Route("/api")]
public class CommonController : ControllerBase
{
     private readonly SignInManager<User> _signInManager;
     private readonly UserManager<User> _userManager;

     public CommonController(SignInManager<User> signInManager, UserManager<User> userManager)
     {
          _signInManager = signInManager;
          _userManager = userManager;
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
          var result = await _signInManager.PasswordSignInAsync(request.Account, request.Password, false, false);
          if (result.Succeeded)
          {
               var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == request.Account);
               return ApiResponse<User>.Ok(user);
          }
          else
          {
               throw new Exception("Login fail");
          }
     }
}