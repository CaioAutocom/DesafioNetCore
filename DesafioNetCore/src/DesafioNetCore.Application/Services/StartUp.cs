using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Application.Middleware;
using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Repository;
using DesafioNetCore.Infra.Repository.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioNetCore.Application.Services;

internal static class StartUp
{
    internal static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUnitService, UnitService>();
        services.AddScoped<UserManager<User>>();
        services.AddScoped<ExceptionMiddleware>();

        return services;
    }
}
