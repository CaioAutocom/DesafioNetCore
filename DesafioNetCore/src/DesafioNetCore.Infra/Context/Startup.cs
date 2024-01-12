using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioNetCore.Infra.Context;

internal static class Startup
{
    internal static IServiceCollection AddContext(this IServiceCollection services, IConfiguration config)
    {
        // db context precisa ser iniciado na startup devido a connection string estar presente no appsetting.json
        //const string sqliteConn = "Data Source=DesafioNetCore_main.db";
        //const string sqliteIdentityConn = "Data Source=DesafioNetCore_Identity.db";
        
        services.AddDbContext<AppDbContext>(opt =>
        {
            
            var strConn = config.GetConnectionString("mainConn");
            opt.UseNpgsql(strConn);
            // opt.UseSqlite(sqliteConn); 
            //opt.UseInMemoryDatabase(databaseName: "InMemoryDb");
        });

        services.AddDbContext<IdentityContext>(opt =>
        {
            opt.UseNpgsql(config.GetConnectionString("identityConn"));
            //opt.UseSqlite(sqliteIdentityConn);
            //opt.UseInMemoryDatabase(databaseName: "InMemoryDb");
        });

        return services;
    }
}
