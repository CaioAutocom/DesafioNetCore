using DesafioNetCore.Infra;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace DesafioNetCore.API.Services.Configuration
{
    public static class JwtConfig
    {
        public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // utilizando os dados do appsettings para popular a classe appsettings criada
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            // pegando a key do appsettings
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOpt =>
            {
                bearerOpt.RequireHttpsMetadata = false; // obriga acesso por https, deixei como falso para testes
                bearerOpt.SaveToken = true; // token é salvo na instancia assim que logado
                // parametros de validação do token
                bearerOpt.TokenValidationParameters = new TokenValidationParameters
                {
                    // valida emissor por base na assinatura do token
                    ValidateIssuerSigningKey = true,
                    // minha chave do token
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    // não lembro
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSettings.LifeTime,
                    ValidIssuer = appSettings.Issuer,
                };

            });

            return services;
        }
    }

}
