﻿using DesafioNetCore.Domain.Entities;
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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
    public DbSet<Person> Persons => Set<Person>();
    public DbSet<Product> Produtcts => Set<Product>();
    public DbSet<Unit> Units => Set<Unit>();
    
}
