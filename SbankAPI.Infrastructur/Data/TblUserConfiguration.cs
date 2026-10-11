using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SbankAPI.Domain.Entities;

namespace SbankAPI.Infrastructure.Data.Configurations;

public class TblUserConfiguration
    : IEntityTypeConfiguration<Tbl_User>
{
    public void Configure(EntityTypeBuilder<Tbl_User> builder)
    {
        builder.ToTable("Tbl_Users");

        builder.HasKey(u => u.UserID);

        builder.Property(u => u.UserID)
            .ValueGeneratedOnAdd();

        builder.Property(u => u.UName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.UEmail)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.UMobile)
            .IsRequired()
            .HasMaxLength(12);

        builder.Property(u => u.UPassword)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(u => u.CreatedAt)
            .IsRequired();

        builder.Property(u => u.UpdatedAt)
            .IsRequired(false);

        builder.Property(u => u.IsActive)
            .IsRequired()
            .HasDefaultValue(true);
    }
}