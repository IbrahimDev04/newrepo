using EcoCoinUni.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EcoCoinUni.Configurations;

public class ToCardInfoConfiguration : IEntityTypeConfiguration<ToCardInfo>
{
    public void Configure(EntityTypeBuilder<ToCardInfo> builder)
    {
        builder.Property(u => u.CardNumber)
            .IsRequired()
            .HasMaxLength(16);

        builder.Property(u => u.FullName)
            .IsRequired()
            .HasMaxLength(64);


    }
}