using DesafioNetCore.Domain.Entities;
using DesafioNetCore.Infra.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DesafioNetCore.Infra;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("public");
        modelBuilder.ApplyConfiguration(new PersonMapper());
        modelBuilder.ApplyConfiguration(new ProdutctMapper());
        modelBuilder.ApplyConfiguration(new UnitMapper());
    }
    public DbSet<Person> Persons => Set<Person>();
    public DbSet<Product> Produtcts => Set<Product>();
    public DbSet<Unit> Units => Set<Unit>();
    
}
