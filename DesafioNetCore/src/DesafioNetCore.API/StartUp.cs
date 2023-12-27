using DesafioNetCore.API.Services.Configuration;
using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra;
using Microsoft.AspNetCore.Identity;

namespace DesafioNetCore.API;

public static class StartUp
{
    public static IServiceCollection AddServices (this IServiceCollection services, IConfiguration config)
    {
        services.AddIdentityConfiguration(config);
        return services;
    }
}
