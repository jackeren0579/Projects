using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Models {
    public class SeedStudentsSubjects {
        public static void EnsurePopulated(IApplicationBuilder app) {
            FFDbContext context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<FFDbContext>();

            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }

            if (!context.StudentsSubjects.Any()) {
                context.StudentsSubjects.AddRange(
                    new StudentsSubjects { StudentID = 1, SubjectID = 1 },
                    new StudentsSubjects { StudentID = 2, SubjectID = 1 },
                    new StudentsSubjects { StudentID = 3, SubjectID = 2 }
                    );
            }
            context.SaveChanges();
        }
    }
}
