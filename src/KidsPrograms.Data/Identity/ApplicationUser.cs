using KidsPrograms.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace KidsPrograms.Data.Identity;

public class ApplicationUser : IdentityUser<int>
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;

    public ICollection<Child> Children { get; set; } = new List<Child>();

    public Instructor? Instructor { get; set; }
}