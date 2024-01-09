using DesafioNetCore.Application.Contracts;
using DesafioNetCore.Infra.Repository;
using DesafioNetCore.Infra.Repository.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioNetCore.Application.Services
{
    public static class StartUp 
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration config)
        {
            // Lembrar de resolver as dependencias de um jeito mais profissional
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnitService, UnitService>();

            return services;
        }
    }
}
