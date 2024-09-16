using Microsoft.AspNetCore.Mvc;
using Solar.Application.DTOs.User;
using Solar.Application.Services.Interfaces.User;

namespace Solar.Api.Controllers.Authentication;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : Controller
{
    private readonly IUserService _userService;

    public AuthenticationController(IUserService userService)
    {
        _userService = userService;
    }

    // POST
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO user)
    {
        if (!_userService.IsValidUser(user.Email, user.Password))
            return Unauthorized(new 
            {
                status = 401 
                });
        if (!_userService.IsEmailConfirmed(user.Email))
            return Unauthorized(new
            {
                message = "Email is not confirmed yet",
                status = 401
            });

        var result = _userService.GetUserByEmail(user.Email);
        return Ok(new
        {
            message = "login"
        });
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDTO requestDTO)
    {
        _userService.Register(requestDTO);
        return Ok();
    }

}