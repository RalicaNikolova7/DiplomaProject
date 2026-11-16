using Microsoft.AspNetCore.Identity;

namespace KidsPrograms.Data.Seed;

public static class RoleSeeder
{
    private static readonly string[] Roles =
    {
        "Parent",
        "Instructor",
        "Organizer"
    };

    public static async Task SeedRolesAsync(
        RoleManager<IdentityRole<int>> roleManager)
    {
        foreach (var role in Roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                var result = await roleManager.CreateAsync(
                    new IdentityRole<int>(role));

                if (!result.Succeeded)
                {
                    var errors = string.Join(
                        "; ",
                        result.Errors.Select(error => error.Description));

                    throw new InvalidOperationException(
                        $"Could not create role '{role}': {errors}");
                }
            }
        }
    }
}
