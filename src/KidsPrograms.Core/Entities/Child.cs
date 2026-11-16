
namespace KidsPrograms.Core.Entities;

public class Child
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    public string? MedicalNotes { get; set; }
}
