using EcoCoinUni.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EcoCoinUni.Configurations;

public class TransportTypeConfiguration : IEntityTypeConfiguration<TransportType>
{
    public void Configure(EntityTypeBuilder<TransportType> builder)
    {
        builder.Property(n => n.Name)
            .IsRequired();

        builder.Property(t => t.TokenPerWay)
            .IsRequired();

        builder.HasMany(u => u.Histories)
            .WithOne(e => e.Transport)
            .HasForeignKey(e => e.TransportId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
