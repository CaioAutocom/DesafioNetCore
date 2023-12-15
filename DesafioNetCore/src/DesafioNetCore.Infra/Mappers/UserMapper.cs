using DesafioNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioNetCore.Infra.Mappers;

public class UserMapper : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> person)
    {
        person.ToTable("user");
        person.HasKey(x => x.Id);

        person.Property(x => x.Id).HasColumnName("id");
        person.Property(x => x.Name).HasColumnName("name");
        person.Property(x => x.Nickname).HasColumnName("nickname");
        person.Property(x => x.Email).HasColumnName("email");
        person.Property(x => x.Document).HasColumnName("document");
        person.Property(x => x.Password).HasColumnName("password");
        person.Property(x => x.AccessPriority).HasColumnName("accesspriority");
    }
}
