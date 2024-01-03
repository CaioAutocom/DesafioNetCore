
using DesafioNetCore.API.Services.Configuration;

namespace DesafioNetCore.API;

public static class StartUp
{
    public static IServiceCollection AddServices (this IServiceCollection services, IConfiguration config)
    {

        // utiliza as configurações do identity
        services.AddIdentityConfiguration(config);
        // utiliza as configurações de token
        services.AddJwtConfiguration(config);
        return services;
    }
}
