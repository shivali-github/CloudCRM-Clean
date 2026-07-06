using CloudCRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudCRM.Infrastructure.Configurations;

public class MembershipTypeConfiguration : IEntityTypeConfiguration<MembershipType>
{
    public void Configure(EntityTypeBuilder<MembershipType> builder)
    {
        builder.ToTable("MembershipTypes");

        builder.HasKey(mt => mt.Id);

        builder.Property(mt => mt.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(mt => mt.Description)
               .HasMaxLength(500);

        builder.Property(mt => mt.MonthlyFee)
               .HasColumnType("decimal(10,2)");
    }
}