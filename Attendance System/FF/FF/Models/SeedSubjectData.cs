using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Models {
    public class SeedSubjectData {
        public static void EnsurePopulated(IApplicationBuilder app) {
            FFDbContext context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<FFDbContext>();

            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }

            if (!context.Subjects.Any()) {
                context.Subjects.AddRange(
                    new Subject { Name = "DMU-19 ProTek3" },
                    new Subject { Name = "DMU-19 Sysudvikling3" },
                    new Subject { Name = "DMU-19 Databaser" },
                    new Subject { Name = "DMU-20 ProTek3" },
                    new Subject { Name = "DMU-20 Sysudvikling3" },
                    new Subject { Name = "DMU-20 Databaser" }
                    );
            }
            context.SaveChanges();
        }
    }
}