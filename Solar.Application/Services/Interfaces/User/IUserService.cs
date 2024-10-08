using Solar.Application.DTOs.User;

namespace Solar.Application.Services.Interfaces.User;

public interface IUserService
{
    IEnumerable<LoginResponseDTO> GetAll();
    bool IsValidUser(string userEmail, string password);
    bool IsEmailConfirmed(string email);
    LoginResponseDTO GetUserByEmail(string userEmail);
    void Register(RegisterRequestDTO requestDTO);
    bool ConfirmEmail(string userEmail, string verifyEmailText);
}