using DesafioNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioNetCore.Infra.Mappers;

public class UnitMapper : IEntityTypeConfiguration<Unit>
{
    public void Configure(EntityTypeBuilder<Unit> unit)
    {
        unit.ToTable("unit");
        unit.Property(x => x.Acronym).HasColumnName("acronym");
        unit.Property(x => x.Description).HasColumnName("description");
        unit.Property(x => x.Id).HasColumnName("id");
        unit.HasKey(x => x.Acronym);
    }
}
