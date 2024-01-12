
using DesafioNetCore.API.Services.Configuration;
using DesafioNetCore.Application.Validation;
using FluentValidation;


namespace DesafioNetCore.API;

public static class StartUp
{
    public static IServiceCollection AddApiServices (this IServiceCollection services, IConfiguration config)
    {

        // utiliza as configurações do identity
        services.AddIdentityConfiguration(config);
        // utiliza as configurações de token
        services.AddJwtConfiguration(config);

        services.AddValidatorsFromAssemblyContaining<UnitValidator>();
        //services.AddScoped<IValidator<Unit>, UnitValidator>();
        return services;
    }
}
