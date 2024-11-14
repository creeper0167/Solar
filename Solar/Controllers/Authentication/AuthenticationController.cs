using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MimeKit.Text;
using Solar.Application.DTOs.User;
using Solar.Application.Services.Interfaces;
using Solar.Application.Services.Interfaces.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes( "OurVerifyAmini"));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var tokenOption = new JwtSecurityToken(
            issuer: "http://localhost:7141",
            claims: new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, "Admin")
            },
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: signinCredentials
            );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);

        return Ok(new
        {
            token = tokenString
        });
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDTO requestDTO)
    {
        _userService.Register(requestDTO);
        

        return Ok();
    }

    [HttpGet("ConfirmEmail")]
    public IActionResult ConfirmEmail(string userEmail, string verifyEmailText)
    {
        if(_userService.ConfirmEmail(userEmail, verifyEmailText))
            return Ok(new
            {
                message = "Email Confirmed!"
            });

        return Ok(new
        {
            message = "Your code is incorrect"
        });
    }
}