using Microsoft.AspNetCore.Identity;

namespace Clean_Blog.Utilities
{
    public class RoleUtilities
    {
        public static async Task EnsureRolesCreated(RoleManager<IdentityRole> roleManager)
        {
            string[] rolesToCreate = { "SuperAdmin", "Admin", "Author" };

            foreach (var roleName in rolesToCreate)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);

                if (!roleExists)
                {
                    var newRole = new IdentityRole { Name = roleName };
                    await roleManager.CreateAsync(newRole);
                }
            }
        }
    }
}
