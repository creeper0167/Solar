using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using MailKit.Net.Smtp;
using MimeKit;
using Solar.Application.DTOs.User;
using Solar.Application.Services.Interfaces;
using Solar.Application.Services.Interfaces.User;
using Solar.Infrastructure.Repository.Interface.User;

namespace Solar.Application.Services.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    public UserService(IUserRepository userRepository, IMapper mapper, IEmailService emailService)
    {
        _emailService = emailService;
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public IEnumerable<LoginResponseDTO> GetAll()
    {
        var users = _userRepository.GetAll();
        var result = _mapper.Map<List<LoginResponseDTO>>(users);
        return result;
    }

    public bool IsValidUser(string userEmail, string password)
    {
        var user = _userRepository.GetByUserEmail(userEmail);

        if (user == null)
            return false;

        if (string.Compare(user.Password, GenerateHashPassword(password)) != 0) //password not match
        {
            return false;
        }

        return true;
    }

    public LoginResponseDTO GetUserByEmail(string userEmail)
    {
        var response = _userRepository.GetByUserEmail(userEmail);

        return new LoginResponseDTO()
        {
            RefreshToken = "refresh"
        };
    }

    public void Register(RegisterRequestDTO requestDTO)
    {
        var user = _mapper.Map<Domain.User.User>(requestDTO);
        user.Password = GenerateHashPassword(user.Password);
        user.EmailConfirmText = Guid.NewGuid().ToString();

        _userRepository.InsertAsync(user);
        _userRepository.SaveChanges();

        _emailService.SendEmail(user.Email, user.EmailConfirmText);
    }

    private string GenerateHashPassword(string password)
    {
        // Create a SHA256
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // ComputeHash - returns byte array
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Convert byte array to a string
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }

    public bool IsEmailConfirmed(string email)
    {
        var user = _userRepository.GetByUserEmail(email);
        if (user.EmailConfirmed == false)
            return false;
        return true;
    }

    public bool ConfirmEmail(string userEmail, string verifyEmailText)
    {
        var user = _userRepository.GetByUserEmail(userEmail);
        if(user == null)
            return false;

        if (String.Compare(verifyEmailText, user.EmailConfirmText) == 0)
        {
            user.EmailConfirmed = true;
            _userRepository.SaveChanges();
            return true;
        }

        return false;
    }
}