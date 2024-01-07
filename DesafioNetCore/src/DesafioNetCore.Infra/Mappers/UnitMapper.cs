using DesafioNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DesafioNetCore.Infra.Mappers;

public class UnitMapper : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> unit)
    {
        unit.ToTable("unit");
        unit.Property(x => x.Id).HasColumnName("id");
        unit.Property(x => x.ShortId).HasColumnName("shortid");
        unit.Property(x => x.Acronym).HasColumnName("acronym");
        unit.HasKey(x => x.Acronym);
        unit.Property(x => x.Description).HasColumnName("description");
    }
}
