
namespace KidsPrograms.Core.Entities;

public class Instructor
{
    public int Id { get; set; }

    public string Specialization { get; set; } = string.Empty;

    public string? Biography { get; set; }

    public bool IsActive { get; set; } = true;
}
