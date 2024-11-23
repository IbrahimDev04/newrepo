using EcoCoinUni.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EcoCoinUni.Configurations;

public class HistoriesConfiguration : IEntityTypeConfiguration<Histories>
{
    public void Configure(EntityTypeBuilder<Histories> builder)
    {
        builder.Property(u => u.From)
            .IsRequired()
            .HasMaxLength(360);

        builder.Property(u => u.To)
            .IsRequired()
            .HasMaxLength(360);
    }
}