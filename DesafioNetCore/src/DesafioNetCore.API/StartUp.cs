
using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra;
using Microsoft.AspNetCore.Identity;

namespace DesafioNetCore.API;

public static class StartUp
{
    public static IServiceCollection AddServices (this IServiceCollection services, IConfiguration config)
    {
        services.AddDefaultIdentity<User>() // minha entidade padrão para modelo de controle do identity
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IdentityContext>()
            .AddDefaultTokenProviders();
        return services;
    }
}
