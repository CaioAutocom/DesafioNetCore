using DesafioNetCore.Infra;
using Microsoft.AspNetCore.Identity;


namespace DesafioNetCore.API.Services.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDefaultIdentity<IdentityUser>() // minha entidade padrão para modelo de controle do identity
             .AddRoles<IdentityRole>()
             .AddEntityFrameworkStores<IdentityContext>()
             .AddDefaultTokenProviders();

            return services;
        }
    }

}
