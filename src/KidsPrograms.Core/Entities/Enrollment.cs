using KidsPrograms.Core.Enums;

namespace KidsPrograms.Core.Entities;

public class Enrollment
{
    public int Id { get; set; }

    public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

    public EnrollmentStatus Status { get; set; }
        = EnrollmentStatus.Pending;

    public int ChildId { get; set; }
    public Child Child { get; set; } = null!;

    public int ShiftId { get; set; }
    public Shift Shift { get; set; } = null!;

    public int? GroupId { get; set; }
    public Group? Group { get; set; }
}
