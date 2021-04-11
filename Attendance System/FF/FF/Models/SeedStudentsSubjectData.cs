using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Models {
    public class SeedStudentsSubjectData {
        public static void EnsurePopulated(IApplicationBuilder app) {
            FFDbContext context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<FFDbContext>();

            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }

            if (!context.StudentsSubjects.Any()) {
                context.StudentsSubjects.AddRange(
                    new StudentsSubjects { SubjectID = 1, StudentID = 1 },
                    new StudentsSubjects { SubjectID = 1, StudentID = 2 },
                    new StudentsSubjects { SubjectID = 1, StudentID = 3 },
                    new StudentsSubjects { SubjectID = 1, StudentID = 4 },
                    new StudentsSubjects { SubjectID = 1, StudentID = 5 },
                    new StudentsSubjects { SubjectID = 1, StudentID = 6 },
                    new StudentsSubjects { SubjectID = 1, StudentID = 7 },
                    new StudentsSubjects { SubjectID = 1, StudentID = 8 },
                    new StudentsSubjects { SubjectID = 1, StudentID = 9 },
                    new StudentsSubjects { SubjectID = 1, StudentID = 10 },
                    new StudentsSubjects { SubjectID = 1, StudentID = 11 },
                    new StudentsSubjects { SubjectID = 1, StudentID = 12 },
                    new StudentsSubjects { SubjectID = 1, StudentID = 13 },
                    new StudentsSubjects { SubjectID = 1, StudentID = 14 },
                    new StudentsSubjects { SubjectID = 1, StudentID = 15 },
                    new StudentsSubjects { SubjectID = 1, StudentID = 16 },
                    new StudentsSubjects { SubjectID = 1, StudentID = 17 },
                    new StudentsSubjects { SubjectID = 1, StudentID = 18 },
                    new StudentsSubjects { SubjectID = 1, StudentID = 19 },
                    new StudentsSubjects { SubjectID = 1, StudentID = 20 },
                    new StudentsSubjects { SubjectID = 1, StudentID = 21 }
                    );
            }
            context.SaveChanges();
        }
    }
}