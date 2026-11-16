using KidsPrograms.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KidsPrograms.Data.Configurations;

public class ProgramConfiguration : IEntityTypeConfiguration<Program>
{
    public void Configure(EntityTypeBuilder<Program> builder)
    {
        builder.HasKey(program => program.Id);

        builder.Property(program => program.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(program => program.Description)
            .HasMaxLength(1000);

        builder.Property(program => program.Category)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(program => program.Price)
            .HasPrecision(10, 2);

        builder.HasMany(program => program.Shifts)
            .WithOne(shift => shift.Program)
            .HasForeignKey(shift => shift.ProgramId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}