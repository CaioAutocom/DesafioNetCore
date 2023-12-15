using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioNetCore.Infra.Context;

internal static class Startup
{
    internal static IServiceCollection AddPgSqlContext(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(opt =>
        {
            var strConn = config.GetConnectionString("pgsqlDb");
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
