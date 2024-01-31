using DesafioNetCore.API.Services.Configuration;
using DesafioNetCore.API.Views;
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
        // registra as validações
        services.AddValidatorsFromAssemblyContaining<CreateUnitValidator>();
        // registra o MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
        // registra as Views
        services.AddMvc(options => options.EnableEndpointRouting = false);

        services.AddControllersWithViews().AddRazorRuntimeCompilation();
        return services;
    }

    public static IApplicationBuilder ConfigureApiServices(this IApplicationBuilder app)
    {
        app.ConfigureMvc();
        return app;
    }
}
