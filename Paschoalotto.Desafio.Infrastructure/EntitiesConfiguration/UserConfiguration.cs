using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Paschoalotto.Desafio.Domain.Entities;

namespace Paschoalotto.Desafio.Infrastructure.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt);
        builder.Property(x => x.UpdatedAt);
        builder.Property(x => x.DeletedAt);

        builder.Property(x => x.FullName).IsRequired();
        builder.Property(x => x.Username).IsRequired();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.Picture);
    }
}
