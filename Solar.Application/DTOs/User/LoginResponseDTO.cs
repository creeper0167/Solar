namespace Solar.Application.DTOs.User;

public class LoginResponseDTO
{
    public int Id { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}