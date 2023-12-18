using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioNetCore.Infra.Context;

internal static class Startup
{
    internal static IServiceCollection AddContext(this IServiceCollection services, IConfiguration config)
    {
        // db context precisa ser iniciado na startup devido a connection string estar presente no appsetting.json
        services.AddDbContext<AppDbContext>(opt =>
        {
            var strConn = config.GetConnectionString("mainConn");
            opt.UseNpgsql(strConn);
        });

        services.AddDbContext<IdentityContext>(opt =>
        {
            var strConn = config.GetConnectionString("identityConn");
            opt.UseNpgsql(strConn);
        });

        return services;
    }
}
