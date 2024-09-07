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
            return Unauthorized(new {status = 401});
        var result = _userService.GetUserByEmail(user.Email);
        return Ok(new
        {
            message= "login"
        });
    }
    
}