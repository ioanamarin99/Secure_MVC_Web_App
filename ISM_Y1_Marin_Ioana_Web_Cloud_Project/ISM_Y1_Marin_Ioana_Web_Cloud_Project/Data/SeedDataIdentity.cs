using Microsoft.AspNetCore.Identity;

namespace ISM_Y1_Marin_Ioana_Web_Cloud_Project.Data
{
    public static class SeedDataIdentity
    {
        private const string adminUsername = "admin@test.com";
        private const string adminPassword = "Qwerty123$";

        public static async Task PopulationAsync(IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices.CreateScope().ServiceProvider;

            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser identityUser = await userManager.FindByEmailAsync(adminUsername);

            if (identityUser == null)
            {
                identityUser = new IdentityUser { UserName = adminUsername, Email = adminUsername };
                await userManager.CreateAsync(identityUser, adminPassword);
            }

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string roleName = "DeleteEditRole";

            if(!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            var adminWithRoleEmail = "cooladmin@test.com";
            var adminWithRole = await userManager.FindByEmailAsync(adminWithRoleEmail);

            if(adminWithRole == null)
            {
                adminWithRole = new IdentityUser
                {
                    UserName = adminWithRoleEmail,
                    Email = adminWithRoleEmail
                };
                await userManager.CreateAsync(adminWithRole, adminPassword);
                await userManager.AddToRoleAsync(adminWithRole, roleName);
            }
        }
    }
}
