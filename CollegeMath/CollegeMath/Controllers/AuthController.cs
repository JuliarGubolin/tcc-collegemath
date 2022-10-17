using CollegeMath.Application.DTO;
using CollegeMath.Application.Helpers;
using CollegeMath.Application.Interfaces;
using CollegeMath.Domain.Entities;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        //Classe para Configurações do Token
        private readonly AppSettings _appSettings;
        private readonly IEmailApplication _emailApplication;

        #region Construtor
        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IOptions<AppSettings> appSettings, IEmailApplication emailApplication)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //Valor das configurações do token
            _appSettings = appSettings.Value;
            _emailApplication = emailApplication;
        }
        #endregion

        //Cadastro do usuário
        //Retorna um status OK com o token do usuário
        //Envia para o banco a conta 
        #region Registro de usuário
        [HttpPost("nova-conta")]
        public async Task<IActionResult> Register(RegisterUserDTO registerUserDTO)
        {
            //Informações básicas do usuário
            var user = new ApplicationUser
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
                await SendRegisterEmail(user);
            }

            return Ok(registerUserDTO);
        }

        private async Task SendRegisterEmail(ApplicationUser user)
        {
            string body = ReadEmbeddedResource.ReadEmbeddedResourceFile("ConfirmationRegisterEmail.html", typeof(Program).Assembly);

            var emailRequest = new EmailRequest
            {
                Subject = "Bem-vindo ao CollegeMath",
                ToEmail = user.Email,
                Body = body
            };

            await _emailApplication.SendEmailAsync(emailRequest);
        }
        #endregion

        #region Login
        //Login na conta criada pelo usuário
        [HttpPost("entrar")]
        public async Task<IActionResult> Login(LoginUserDTO loginUserDTO)
        {
            //Verifica se o usuário está autenticado, ou seja, se email e/ou senha estão corretos (se estão no BD)
            var result = await _signInManager.PasswordSignInAsync(loginUserDTO.Email, loginUserDTO.Password, false, false);
            var user = await _userManager.FindByEmailAsync(loginUserDTO.Email);
            if (result.Succeeded)
            {
                return Ok(GerarJwt(user.Id));
            }
            else
            {
                return BadRequest("Usuário e/ou senha inválidos");
            }
        }
        #endregion

        #region Geração do Token de acesso do usuário
        //Gera o Token necessário para o APP autenticar o usuário
        //Criação do loginResponse
        //Criação do AppSettings
        private string GerarJwt(string userId)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                //Expiração do Token
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            return encodedToken;
        }
        #endregion

        #region GetAll de Usuários
        //[HttpGet]
        //public async Task<IActionResult> GetUsers()
        //{
        //var result = _signInManager.UserManager.GetUsersInRoleAsync("");
        //return Ok(result);
        //}
        #endregion


        [HttpPost("email-resetar-senha")]
        public async Task<IActionResult> ResetPasswordEmail(LoginUserDTO loginUserDTO)
        {
            //enviar email se resetar senha
            return null;
        }
    }

}
