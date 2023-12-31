﻿using DesafioNetCore.Application.CQRS.Handlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DesafioNetCore.Application
{
    public static class StartUp
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateUnitHandler>());
            return services;
        }
    }
}
