using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DesafioNetCore.Infra;

public class IdentityContext :  IdentityDbContext<User>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("public");
        modelBuilder.ApplyConfiguration(new UserMapper());

        modelBuilder.Entity<User>()
            .HasKey(x => x.Id);
    }
    public DbSet<User> Users => Set<User>();
}
