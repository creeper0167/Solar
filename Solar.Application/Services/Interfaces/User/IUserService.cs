using Solar.Application.DTOs.User;

namespace Solar.Application.Services.Interfaces.User;

public interface IUserService
{
    IEnumerable<LoginResponseDTO> GetAll();
    bool IsValidUser(string userEmail, string password);
    LoginResponseDTO GetUserByEmail(string userEmail);
    void Register(RegisterRequestDTO requestDTO);
}