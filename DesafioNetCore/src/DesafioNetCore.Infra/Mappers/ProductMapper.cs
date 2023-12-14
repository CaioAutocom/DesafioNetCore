using DesafioNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DesafioNetCore.Infra.Mappers;

public class ProdutctMapper : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> person)
    {
        person.ToTable("persons");
        person.HasKey(x => x.Id);

        person.Property(x => x.Id).HasColumnName("id");
        person.Property(x => x.FullDescription).HasColumnName("fulldescription");
        person.Property(x => x.Price).HasColumnName("price");
        person.Property(x => x.Storage).HasColumnName("storage");
        person.Property(x => x.BarCode).HasColumnName("barcode");
        person.Property(x => x.CanSell).HasColumnName("cansell");
        person.Property(x => x.Active).HasColumnName("active");
        person.Property(x => x.Active).HasColumnName("active");
        
    }
}