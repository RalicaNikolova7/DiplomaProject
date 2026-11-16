namespace KidsPrograms.Core.Entities;
public class Attendance
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public bool IsPresent { get; set; }

    public string? Notes { get; set; }

    public int EnrollmentId { get; set; }

    public Enrollment Enrollment { get; set; } = null!;
}