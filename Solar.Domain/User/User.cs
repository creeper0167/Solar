using System.ComponentModel.DataAnnotations;

namespace Solar.Domain.User;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public string RefreshToken { get; set; }
}