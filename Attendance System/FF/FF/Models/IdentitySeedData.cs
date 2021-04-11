using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FF.Models {

    public static class IdentitySeedData {

        private const string adminEmail = "fkj@eamv.dk";
        private const string adminPassword = "Secret123$";

        public static async void EnsurePopulated(IApplicationBuilder app) {
            FFIdentityDbContext context =
                app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<FFIdentityDbContext>();

            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager =
                app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user = await userManager.FindByEmailAsync(adminEmail);

            if (user == null) {
                user = new IdentityUser("Flemming") {
                    Email = "fkj@eamv.dk"
                };
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}