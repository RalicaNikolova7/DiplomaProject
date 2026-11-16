using KidsPrograms.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KidsPrograms.Data.Configurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(group => group.Id);

        builder.Property(group => group.Name)
            .IsRequired()
            .HasMaxLength(150);

       builder.HasOne(group => group.Shift)
            .WithMany(shift => shift.Groups)
            .HasForeignKey(group => group.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(group => group.Instructors)
            .WithMany()
            .UsingEntity("GroupInstructors");
    }
}
