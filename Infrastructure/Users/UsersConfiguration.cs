using Domain.User;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Users;

public class UserDbConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(Tables.Users);

        builder.HasKey(user => user.Id);

        builder.HasIndex(user => user.IdentityProviderId)
            .IsUnique();

        builder.Property(user => user.Id)
            .HasConversion(userId => userId.Value.ToGuid(), userId => new UserId(Ulid.Parse(userId.ToByteArray())))
            .HasMaxLength(Ulid.MaxValue.ToString().Length);
    }
}
