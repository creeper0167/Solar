using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Solar.Application.DTOs.User;
using Solar.Application.Services.Interfaces.User;
using Solar.Infrastructure.Repository.Interface.User;

namespace Solar.Application.Services.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public IEnumerable<LoginResponseDTO> GetAll()
    {
        var users = _userRepository.GetAll();
        var result = _mapper.Map<List<LoginResponseDTO>>(users);
        return result;
    }

    public bool IsValidUser(string userEmail,string password)
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

    public bool IsEmailConfirmed(string userEmail)
    {
        var user = _userRepository.GetByUserEmail(userEmail);
        if (user.EmailConfirmed == true)
            return true;
        return false;

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
        _userRepository.InsertAsync(user);
        _userRepository.SaveChanges();
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
}