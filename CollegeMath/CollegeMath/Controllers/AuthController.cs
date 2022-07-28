using CollegeMath.Application.DTO;
using CollegeMath.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CollegeMath.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        //Configurações do Token
        private readonly AppSettings _appSettings;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            IOptions<AppSettings> appSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
        }

        //Cadastro do usuário
        //Retorna um status OK com o token do usuário
        //Envia para o banco a conta 
        [HttpPost("nova-conta")]
        public async Task<IActionResult> Register(RegisterUserDTO registerUserDTO)
        {
            //Informações básicas do usuário
            var user = new IdentityUser
            {
                UserName = registerUserDTO.Email,
                Email = registerUserDTO.Email,
                EmailConfirmed = true
            };

            //Autenticação
            //Cria o usuário na API
            var result = await _userManager.CreateAsync(user, registerUserDTO.Password);
            //Retorna se a criação funcionou ou não
            if (result.Succeeded)
            {
                //Já faz o Login para o usuário ter uma seção
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return Ok(registerUserDTO);
        }

        //Login na conta criada pelo usuário
        [HttpPost("entrar")]
        public async Task<IActionResult> Login(LoginUserDTO loginUserDTO)
        {
            //Verifica se o usuário está autenticado, ou seja, se email e/ou senha estão corretos (se estão no BD)
            var result = await _signInManager.PasswordSignInAsync(loginUserDTO.Email, loginUserDTO.Password, false, false);
            if (result.Succeeded)
            {
                return Ok(GerarJwt());
            }
            else
            {
                return BadRequest("Usuário e/ou senha inválidos");
            }
        }

        //Gera o Token necessário para o APP autenticar o usuário
        //Criação do loginResponse
        //Criação do AppSettings
        private string GerarJwt()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                //Expiração do Token
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);
            
            return encodedToken;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
