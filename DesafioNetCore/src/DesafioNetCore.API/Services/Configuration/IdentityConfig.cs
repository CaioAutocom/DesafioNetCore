using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra;
using Microsoft.AspNetCore.Identity;


namespace DesafioNetCore.API.Services.Configuration
{
    internal static class IdentityConfig
    {
        internal static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDefaultIdentity<User>() // minha entidade padrão para modelo de controle do identity
             .AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<IdentityContext>()
             .AddDefaultTokenProviders();

            // adicionado só para testar mais fácil, remover na versão final
            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 0;
            });
            return services;
        }
    }

}
