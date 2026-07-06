using CloudCRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudCRM.Infrastructure.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.FirstName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(c => c.LastName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(c => c.Email)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(c => c.PhoneNumber)
               .HasMaxLength(20);

        builder.Property(c => c.Address)
               .HasMaxLength(250);

        builder.Property(c => c.City)
               .HasMaxLength(100);

        builder.Property(c => c.Country)
               .HasMaxLength(100);
    }
}