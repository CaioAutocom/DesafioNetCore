using DesafioNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DesafioNetCore.Infra.Mappers;

public class ProdutctMapper : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> product)
    {
        product.ToTable("product");
        product.HasKey(x => x.Id);

        product.Property(x => x.Id).HasColumnName("id");
        product.Property(x => x.ShortId).HasColumnName("shortid");
        product.Property(x => x.FullDescription).HasColumnName("shortdescription");
        product.Property(x => x.ShortDescription).HasColumnName("fulldescription");
        product.Property(x => x.Price).HasColumnName("price");
        product.Property(x => x.Storage).HasColumnName("storage");
        product.Property(x => x.BarCode).HasColumnName("barcode");
        product.Property(x => x.CanSell).HasColumnName("cansell");
        product.Property(x => x.Active).HasColumnName("active");
        product.Property(x => x.Acronym).HasColumnName("acronym").IsRequired();

        product.HasOne(x => x.Unit)
            .WithMany()
            .HasForeignKey(x => x.Acronym)
            .IsRequired();
    }
}