

using Infrastructure.Identity;
using Infrastructure.Persistance.Entities.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations.Members;

internal class MemberEntityConfiguration : IEntityTypeConfiguration<MemberEntity>
{
    public void Configure(EntityTypeBuilder<MemberEntity> builder)
    {
        builder.ToTable("Members");
        builder.HasIndex(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.FirstName)
            .HasMaxLength(100);

        builder.Property(x => x.LastName)
            .HasMaxLength(100);

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(50);

        builder.Property(x => x.ProfileImageUrl)
            .HasMaxLength(500);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.ModifiedAt)
           .IsRequired();

        builder.HasIndex(x => x.UserId)
            .IsUnique();

        builder
            .HasOne(x => x.User)
            .WithOne(x => x.Member)
            .HasForeignKey<MemberEntity>(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .HasOne(x => x.Membership)
            .WithMany(x => x.Members)
            .HasForeignKey(x => x.MembershipId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
