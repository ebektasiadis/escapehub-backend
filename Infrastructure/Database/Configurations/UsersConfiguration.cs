using Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class UserDbConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(Tables.Users);

        builder.HasKey(user => user.Id);

        builder.HasIndex(user => user.IdentityProviderId)
            .IsUnique();

        builder.HasIndex(user => user.Email)
            .IsUnique();

        builder.Property(user => user.Id)
            .HasConversion(userId => userId.Value.ToString(), userId => new UserId(Ulid.Parse(userId)))
            .HasMaxLength(Ulid.MaxValue.ToString().Length);
    }
}
