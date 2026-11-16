using KidsPrograms.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KidsPrograms.Data.Configurations;

public class EnrollmentConfiguration
    : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.HasKey(enrollment => enrollment.Id);
        builder.Property(enrollment => enrollment.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(enrollment => enrollment.EnrollmentDate)
            .IsRequired();

        builder.HasOne(enrollment => enrollment.Child)
            .WithMany()
            .HasForeignKey(enrollment => enrollment.ChildId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(enrollment => enrollment.Shift)
            .WithMany()
            .HasForeignKey(enrollment => enrollment.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(enrollment => new
        {
            enrollment.ChildId,
            enrollment.ShiftId
        }).IsUnique();

        builder.HasOne(enrollment => enrollment.Group)
           .WithMany()
           .HasForeignKey(enrollment => enrollment.GroupId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}
