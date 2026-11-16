
using KidsPrograms.Core.Entities;
using KidsPrograms.Data.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KidsPrograms.Data.Configurations;

public class InstructorConfiguration
    : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.HasKey(instructor => instructor.Id);

        builder.Property(instructor => instructor.Specialization)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(instructor => instructor.Biography)
            .HasMaxLength(1000);

        builder.Property(instructor => instructor.IsActive)
            .IsRequired();

        builder.HasOne<ApplicationUser>()
            .WithOne(user => user.Instructor)
            .HasForeignKey<Instructor>("ApplicationUserId")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex("ApplicationUserId")
            .IsUnique();
    }
}
