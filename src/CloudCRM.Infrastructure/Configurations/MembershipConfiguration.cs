using CloudCRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudCRM.Infrastructure.Configurations;

public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
{
    public void Configure(EntityTypeBuilder<Membership> builder)
    {
        builder.ToTable("Memberships");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.StartDate)
               .IsRequired();

        builder.Property(m => m.EndDate)
               .IsRequired();

        builder.Property(m => m.Price)
               .HasColumnType("decimal(10,2)");

        builder.Property(m => m.IsActive)
               .IsRequired();

                // Relationship: Membership -> Customer
        builder.HasOne(m => m.Customer)
               .WithMany(c => c.Memberships)
               .HasForeignKey(m => m.CustomerId);

        // Relationship: Membership -> MembershipType
        builder.HasOne(m => m.MembershipType)
               .WithMany(mt => mt.Memberships)
               .HasForeignKey(m => m.MembershipTypeId);
    }
}