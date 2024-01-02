using DesafioNetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioNetCore.Infra.Mappers;

public class UserMapper : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> user)
    {
        user.ToTable("user");
        user.HasKey(x => x.Id);

        user.Property(x => x.Id).HasColumnName("id");
        user.Property(x => x.Name).HasColumnName("name");
        user.Property(x => x.Nickname).HasColumnName("nickname");
        user.Property(x => x.Email).HasColumnName("email");
        user.Property(x => x.Document).HasColumnName("document");
    }
}
