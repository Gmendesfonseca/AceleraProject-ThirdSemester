using System.ComponentModel.DataAnnotations;

namespace InnerAPI.Dtos.Login
{
    public record class LoginDto
    (
        [Required] string Email,
        [Required] string Password
    )
    {
        public string Email { get; init; } = Email;
        public string Password { get; init; } = Password;
    }
}
