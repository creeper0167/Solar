using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using Solar.Application.DTOs.User;
using Solar.Application.Services.Interfaces;
using Solar.Application.Services.Interfaces.User;

namespace Solar.Api.Controllers.Authentication;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : Controller
{
    private readonly IUserService _userService;
    private readonly IEmailService _emailService;
    public AuthenticationController(IUserService userService, IEmailService emailService)
    {
        _emailService = emailService;
        _userService = userService;
    }

    // POST
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO user)
    {
        if (!_userService.IsValidUser(user.Email, user.Password))
            return Unauthorized(new {status = 401});

        if (!_userService.IsEmailConfirmed(user.Email))
            return Ok(new
            {
                message = "Your email is not confirmed yet"
            });

        var result = _userService.GetUserByEmail(user.Email);
        return Ok(new
        {
            message= "login"
        });
    }
    
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDTO requestDTO)
    {
        _userService.Register(requestDTO);
        //_userService.Generate
        _emailService.SendEmail();
        return Ok();
    }

    [HttpGet("ConfirmEmail")]
    public IActionResult ConfirmEmail(string userEmail)
    {
        _userService.ConfirmEmail(userEmail);
        return Ok(new
        {
            message = "Email Confirmed!"
        });
    }

    //Test Email sender
    [HttpPost]
    public IActionResult SendEmail()
    {
        _emailService.SendEmail();

        return Ok();
    }
}