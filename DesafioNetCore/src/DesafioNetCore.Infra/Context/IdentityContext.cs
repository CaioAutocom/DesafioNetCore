using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DesafioNetCore.Infra;

public class IdentityContext : DbContext
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");
        modelBuilder.ApplyConfiguration(new UserMapper());

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = Guid.NewGuid(),
                AccessPriority = Entities.Enums.EAccessPriority.Administrator,
                Document = "08679558648",
                Email = "admin@admin.com",
                Name = "admin",
                Nickname = "admin",
            });
    }
    public DbSet<User> Users => Set<User>();
}
