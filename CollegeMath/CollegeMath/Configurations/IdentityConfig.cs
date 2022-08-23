using CollegeMath.Data;
using CollegeMath.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CollegeMath.Configurations
{
    public static class IdentityConfig
    {
        //A classe IdentityConfig possui um método AddIdentityConfig que recebe ele mesmo (extention method)
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services, IConfiguration configuration)
        {
            #region ConnectionString
            //Mesma connectionString 
            var connectionString = configuration.GetConnectionString("CollegeMathConnection");
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));
            #endregion

            //depois daqui, pode rodar update database
            //Add-Migration identity -Context ApplicationDBContext (tanho que indicar qual contexto que quero adicionar)
            //IdentityRole por causa da última versão
            #region Novo Identity (com tabelas para auxiliar na configuração do usuário)
            services.AddIdentity<IdentityUser, IdentityRole>()
               .AddRoles<IdentityRole>()
               //Usa o EF para armazenamento
               .AddEntityFrameworkStores<ApplicationDBContext>()
               //Identitty portuguese para mensagens de erro
               .AddErrorDescriber<IdentityPortuguese>()
               //Autenticação por Token
               .AddDefaultTokenProviders();
            #endregion


            #region Configuração do AppSttings
            //Configuraçaõ do JWT
            //Registra o APPSettings
            //Configuração que está no Json
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            #endregion

            #region Criptografar
            //Criptografar
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            #endregion

            #region Adiciona configurações da autenticação
            //Mostra que o sistema de autenticação vai ser pelo token JWT
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSettings.ValidoEm,
                    ValidIssuer = appSettings.Emissor
                };
            });
            #endregion

            return services;
        }
    }
}
