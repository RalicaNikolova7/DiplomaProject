
using KidsPrograms.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KidsPrograms.Data.Configurations;

public class AttendanceConfiguration
    : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.HasKey(attendance => attendance.Id);

        builder.Property(attendance => attendance.Date)
            .IsRequired();

        builder.Property(attendance => attendance.IsPresent)
            .IsRequired();

        builder.Property(attendance => attendance.Notes)
            .HasMaxLength(500);

        builder.HasOne(attendance => attendance.Enrollment)
            .WithMany()
            .HasForeignKey(attendance => attendance.EnrollmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(attendance => new
        {
            attendance.EnrollmentId,
            attendance.Date
        }).IsUnique();
    }
}
