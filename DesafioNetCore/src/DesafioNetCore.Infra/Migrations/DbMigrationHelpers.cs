using DesafioNetCore.Entities.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DesafioNetCore.Infra.Migrations;

public static class DbMigrationHelpers
{
    public static async Task EnsureSeedData(WebApplication serviceScope)
    {
        var services = serviceScope.Services.CreateScope().ServiceProvider;
        await EnsureSeedData(services);
    }

    public static async Task EnsureSeedData(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var identityContext = scope.ServiceProvider.GetRequiredService<IdentityContext>();

        if (env.IsDevelopment())
        {
            await context.Database.MigrateAsync();
            await identityContext.Database.MigrateAsync();

            await EnsureSeedRoles(identityContext);
        }
    }
    private static async Task EnsureSeedRoles(IdentityContext identityContext)
    {
        if (identityContext.Roles.Any()) return;

        foreach (var item in Enum.GetValues(typeof(EAccessPriority)))
        {
            var id = Guid.NewGuid().ToString();
            IdentityRole role = new ()
            {
                Id = id,
                Name = item.ToString().ToUpper(),
                NormalizedName = item.ToString().ToUpper(),
            };
            identityContext.Roles.Add(role);
        }
        await identityContext.SaveChangesAsync();
    }
}
