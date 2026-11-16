namespace KidsPrograms.Core.Entities;

public class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int ShiftId { get; set; }

    public Shift Shift { get; set; } = null!;

    public ICollection<Instructor> Instructors { get; set; }
        = new List<Instructor>();
}
