using DesafioNetCore.Application.CQRS.Handlers;
using DesafioNetCore.Application.Middleware;
using DesafioNetCore.Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace DesafioNetCore.Application
{
    public static class StartUp
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateUnitHandler>());
            services.ResolveDependencies(config);

            return services;
        }

        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app) => app.UseMiddleware<ExceptionMiddleware>();
    }
}
