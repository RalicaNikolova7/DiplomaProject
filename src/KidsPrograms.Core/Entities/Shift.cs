namespace KidsPrograms.Core.Entities;
public class Shift
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int Capacity { get; set; }

    public int ProgramId { get; set; }

    public Program Program { get; set; } = null!;

    public ICollection<Group> Groups { get; set; }
    = new List<Group>();
}