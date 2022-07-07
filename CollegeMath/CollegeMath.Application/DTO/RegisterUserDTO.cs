using System.ComponentModel.DataAnnotations;

namespace CollegeMath.Application.DTO
{
    public class RegisterUserDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Senhas não conferem")]
        public string ConfirmPassword { get; set; }
    }
}
