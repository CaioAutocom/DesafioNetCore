using DesafioNetCore.Domain.Entities;
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
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
       
        if (env.IsDevelopment())
        {
            // uso do postgres e sqlite
            await context.Database.MigrateAsync();
            await identityContext.Database.MigrateAsync();
            
            // uso do in memory
            //context.Database.EnsureCreated();
            //identityContext.Database.EnsureCreated();

            await EnsureSeedRolesAsync(identityContext);
            await EnsureSeedInitialUserAsync(identityContext, userManager);
        }
    }
    private static async Task EnsureSeedRolesAsync(IdentityContext identityContext)
    {
        if (identityContext.Roles.Any()) return;

        foreach (var item in Enum.GetValues(typeof(EAccessPriority)))
        {
            var id = Guid.NewGuid().ToString();
            IdentityRole role = new()
            {
                Id = id,
                Name = item.ToString().ToUpper(),
                NormalizedName = item.ToString().ToUpper(),
            };
            identityContext.Roles.Add(role);
        }
        await identityContext.SaveChangesAsync();
    }

    private static async Task EnsureSeedInitialUserAsync(IdentityContext identityContext, UserManager<User> userManager)
    {
        if (identityContext.Users.Any()) return;

        User user = new()
        {
            UserName = "admin@admin.com",
            Document = "08679558648",
            EmailConfirmed = true,
            Name = "administrator",
            Nickname = "admin@admin.com",
            Email = "admin@admin.com"
        };

        var result = await userManager.CreateAsync(user, "administrator");

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, EAccessPriority.Administrator.ToString().ToUpper());
        }
    }
}
