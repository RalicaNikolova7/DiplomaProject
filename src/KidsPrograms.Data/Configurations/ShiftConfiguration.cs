
using KidsPrograms.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KidsPrograms.Data.Configurations;

public class ShiftConfiguration : IEntityTypeConfiguration<Shift>
{
    public void Configure(EntityTypeBuilder<Shift> builder)
    {
        builder.HasKey(shift => shift.Id);

        builder.Property(shift => shift.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(shift => shift.Capacity)
            .IsRequired();

        builder.ToTable(table =>
        {
            table.HasCheckConstraint(
                "CK_Shifts_Capacity",
                "[Capacity] > 0");

            table.HasCheckConstraint(
                "CK_Shifts_Dates",
                "[EndDate] >= [StartDate]");
        });

        builder.HasOne(shift => shift.Program)
            .WithMany(program => program.Shifts)
            .HasForeignKey(shift => shift.ProgramId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
