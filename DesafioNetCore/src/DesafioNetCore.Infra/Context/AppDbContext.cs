using DesafioNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DesafioNetCore.Infra.Context;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server = localhost; Port = 5432; Database = desafioBd; UserId = postgres; Password = 12345");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");
        MapEntities(modelBuilder);
    }
    public DbSet<Person> Persons => Set<Person>();
    public DbSet<Product> Produtcts => Set<Product>();
    public DbSet<Unit> Units => Set<Unit>();
    
    private void MapEntities(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration();
    }
}
