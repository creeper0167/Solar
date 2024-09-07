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
        
        if (string.Compare(user.Password, password) != 0) //password not match
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
        _userRepository.InsertAsync(user);
        _userRepository.SaveChanges();
    }
}