using EcoCoinUni.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EcoCoinUni.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(32);

        builder.Property(u => u.Surname)
            .IsRequired()
            .HasMaxLength(32);

        builder.Property(u => u.AllToken)
            .IsRequired();

        builder.HasMany(u => u.Histories)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.ToCards)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
