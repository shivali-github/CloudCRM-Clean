using CloudCRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudCRM.Infrastructure.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Amount)
               .HasColumnType("decimal(10,2)");

        builder.Property(p => p.PaymentMethod)
               .HasMaxLength(50);

        builder.Property(p => p.TransactionReference)
               .HasMaxLength(100);

        builder.Property(p => p.PaymentDate)
               .IsRequired();
    }
}