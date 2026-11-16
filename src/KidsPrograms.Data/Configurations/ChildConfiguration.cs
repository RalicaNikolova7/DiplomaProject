
using KidsPrograms.Core.Entities;
using KidsPrograms.Data.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KidsPrograms.Data.Configurations;

public class ChildConfiguration : IEntityTypeConfiguration<Child>
{
    public void Configure(EntityTypeBuilder<Child> builder)
    {
        builder.HasKey(child => child.Id);

        builder.Property(child => child.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(child => child.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany<ApplicationUser>()
            .WithMany(user => user.Children)
            .UsingEntity("ChildParents");
    }
}
