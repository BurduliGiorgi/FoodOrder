using FoodOrder.Domain.Constants;
using FoodOrder.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace FoodOrder.Infrastructure.Seeders
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            string[] roles = [ Roles.Admin, Roles.User ];


            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole<Guid>(role));
            }


            var adminEmail = "admin@foodorder.com";

            if (await userManager.FindByEmailAsync(adminEmail) is null)
            {
                var admin = new AppUser
                {
                    FirstName = "Admin",
                    LastName = "User",
                    UserName = adminEmail,
                    Email = adminEmail
                };

                await userManager.CreateAsync(admin, "Admin@123");
                await userManager.AddToRoleAsync(admin, Roles.Admin);
            }
        }
    }
}
