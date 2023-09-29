using Microsoft.AspNetCore.Identity;
using ProyectoFinal.Models;
using System.Net;

namespace ProyectoFinal.Data
{
    public class Seed
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "test@test.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        CUI = "2912354091234",
                        Nombres = "Josue David",
                        Apellidos = "De Leon M",
                        Telefono = 58283694,
                        Date = DateTime.Now,
                        UserName = "josue",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        
                    };
                    await userManager.CreateAsync(newAdminUser, "Root12#");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }
            }
        }
    }
}
