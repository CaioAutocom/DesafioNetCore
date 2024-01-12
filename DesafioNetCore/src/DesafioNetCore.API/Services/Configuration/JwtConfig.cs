using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


namespace DesafioNetCore.API.Services.Configuration
{
    internal static class JwtConfig
    {
        internal static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
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
            // configurações do swagger para habilitar o uso de token
            services.AddSwaggerGen(x => {
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Set your token access of type: Bearer {your_token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            
            return services;
        }
    }

}
