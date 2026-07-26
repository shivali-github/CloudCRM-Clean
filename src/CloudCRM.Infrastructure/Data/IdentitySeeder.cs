using Microsoft.AspNetCore.Identity;

namespace CloudCRM.Infrastructure.Data;

public static class IdentitySeeder
{
    public static async Task SeedAsync(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        const string adminRole = "Admin";
        const string adminEmail = "admin@cloudcrm.com";
        const string adminPassword = "Admin@12345";

        if (!await roleManager.RoleExistsAsync(adminRole))
        {
            await roleManager.CreateAsync(new IdentityRole(adminRole));
        }

        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser is null)
        {
            adminUser = new IdentityUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            var createUserResult =
                await userManager.CreateAsync(adminUser, adminPassword);

            if (!createUserResult.Succeeded)
            {
                var errors = string.Join(
                    ", ",
                    createUserResult.Errors.Select(error => error.Description));

                throw new InvalidOperationException(
                    $"Could not create admin user: {errors}");
            }
        }

        if (!await userManager.IsInRoleAsync(adminUser, adminRole))
        {
            var addToRoleResult =
                await userManager.AddToRoleAsync(adminUser, adminRole);

            if (!addToRoleResult.Succeeded)
            {
                var errors = string.Join(
                    ", ",
                    addToRoleResult.Errors.Select(error => error.Description));

                throw new InvalidOperationException(
                    $"Could not assign admin role: {errors}");
            }
        }
    }
}