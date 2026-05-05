using Infrastructure.Persistance.Entities.Memberships;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.Configurations.Memberships;

internal class MembershipConfiguration : IEntityTypeConfiguration<MembershipEntity>
{
    public void Configure(EntityTypeBuilder<MembershipEntity> builder)
    {
        builder.ToTable("Memberships");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.Title)
            .IsRequired();

        builder.Property(x => x.Description)
            .IsRequired();

        builder.Property(x => x.Price)
            .IsRequired();

        builder.Property(x => x.MonthlyClasses)
            .IsRequired();

        builder.HasMany(x => x.Members)
            .WithOne(x => x.Membership)
            .HasForeignKey(x => x.MembershipId)
            .OnDelete(DeleteBehavior.SetNull);


    }
}

internal class MembershipBenefitConfiguration : IEntityTypeConfiguration<MembershipBenefitEntity>
{
    public void Configure(EntityTypeBuilder<MembershipBenefitEntity> builder)
    {
        builder.ToTable("MembershipBenefits");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired();
        builder.Property(x => x.MembershipId)
           .IsRequired();
        

    }
}