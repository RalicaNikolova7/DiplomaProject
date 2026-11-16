using KidsPrograms.Core.Entities;
using KidsPrograms.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KidsPrograms.Data.Context;

public class ApplicationDbContext
    : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Child> Children => Set<Child>();

    public DbSet<Program> Programs => Set<Program>();

    public DbSet<Shift> Shifts => Set<Shift>();

    public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    public DbSet<Attendance> Attendances => Set<Attendance>();

    public DbSet<Instructor> Instructors => Set<Instructor>();

    public DbSet<Group> Groups => Set<Group>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>(entity =>
{
    entity.Property(user => user.FirstName)
        .IsRequired()
        .HasMaxLength(100);

    entity.Property(user => user.LastName)
        .IsRequired()
        .HasMaxLength(100);

    entity.Property(user => user.IsActive)
        .IsRequired()
        .HasDefaultValue(true);
});

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);
    }
}
