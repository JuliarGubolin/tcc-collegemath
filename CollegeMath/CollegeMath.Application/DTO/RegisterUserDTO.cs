using System.ComponentModel.DataAnnotations;

namespace CollegeMath.Application.DTO
{
    public class RegisterUserDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        //Só funciona se ConfirmPassword for igual ao Password (assim, ela é feita pela API, mas pode ser feita pelo aplicativo comparando os campos)
        [Compare("Password", ErrorMessage = "Senhas não conferem")]
        public string ConfirmPassword { get; set; }
    }
}
