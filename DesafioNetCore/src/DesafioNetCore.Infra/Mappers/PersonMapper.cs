using DesafioNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioNetCore.Infra.Mappers;

public class PersonMapper : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> person)
    {
        person.ToTable("persons");
        person.HasKey(x => x.Id);

        person.Property(x => x.Id).HasColumnName("id");
        person.Property(x => x.Name).HasColumnName("name");
        person.Property(x => x.Document).HasColumnName("document");
        person.Property(x => x.Town).HasColumnName("town");
        person.Property(x => x.CanBuy).HasColumnName("canbuy");
        person.Property(x => x.Observations).HasColumnName("observations");
        person.Property(x => x.AlternativeIdentifier).HasColumnName("alternativeidentifier");
        person.Property(x => x.Active).HasColumnName("active");
    }
}
