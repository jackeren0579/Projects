using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Models {
    public class SeedProtocolData {
        public static void EnsurePopulated(IApplicationBuilder app) {
            FFDbContext context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<FFDbContext>();

            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }

            if (!context.Protocols.Any()) {
                context.Protocols.AddRange(
                    new Protocol { Date = DateTime.Parse("10-12-2020"), HoursTotal = 2, HoursPresent = 2, HoursVirtual = 0, StudentID = 1, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("10-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 2, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("10-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 3, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("10-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 4, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("10-12-2020"), HoursTotal = 2, HoursPresent = 2, HoursVirtual = 0, StudentID = 5, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("10-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 6, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("10-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 7, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("10-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 8, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("10-12-2020"), HoursTotal = 2, HoursPresent = 2, HoursVirtual = 0, StudentID = 9, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("10-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 10, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("10-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 11, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("10-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 12, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("10-12-2020"), HoursTotal = 2, HoursPresent = 2, HoursVirtual = 0, StudentID = 13, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("10-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 14, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("10-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 15, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("10-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 16, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("10-12-2020"), HoursTotal = 2, HoursPresent = 2, HoursVirtual = 0, StudentID = 17, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("10-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 18, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("10-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 19, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("10-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 20, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("10-12-2020"), HoursTotal = 2, HoursPresent = 2, HoursVirtual = 0, StudentID = 21, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("11-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 1, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("11-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 2, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("11-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 3, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("11-12-2020"), HoursTotal = 2, HoursPresent = 2, HoursVirtual = 0, StudentID = 4, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("11-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 5, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("11-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 6, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("11-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 7, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("11-12-2020"), HoursTotal = 2, HoursPresent = 2, HoursVirtual = 0, StudentID = 8, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("11-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 9, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("11-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 10, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("11-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 11, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("11-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 12, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("11-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 13, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("11-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 14, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("11-12-2020"), HoursTotal = 2, HoursPresent = 2, HoursVirtual = 0, StudentID = 15, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("11-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 16, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("11-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 17, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("11-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 18, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("11-12-2020"), HoursTotal = 2, HoursPresent = 2, HoursVirtual = 0, StudentID = 19, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("11-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 20, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 21, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 1, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 2, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 3, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 2, HoursVirtual = 0, StudentID = 4, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 5, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 6, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 7, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 2, HoursVirtual = 0, StudentID = 8, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 9, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 10, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 11, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 12, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 13, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 14, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 2, HoursVirtual = 0, StudentID = 15, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 16, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 17, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 18, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 2, HoursVirtual = 0, StudentID = 19, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 20, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("12-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 21, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("13-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 1, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("13-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 2, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("13-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 3, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("13-12-2020"), HoursTotal = 2, HoursPresent = 2, HoursVirtual = 0, StudentID = 4, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("13-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 5, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("13-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 6, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("13-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 7, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("13-12-2020"), HoursTotal = 2, HoursPresent = 2, HoursVirtual = 0, StudentID = 8, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("13-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 9, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("13-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 10, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("13-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 11, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("13-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 12, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("13-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 13, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("13-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 14, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("13-12-2020"), HoursTotal = 2, HoursPresent = 2, HoursVirtual = 0, StudentID = 15, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("13-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 16, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("13-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 17, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("13-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 18, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("13-12-2020"), HoursTotal = 2, HoursPresent = 2, HoursVirtual = 0, StudentID = 19, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("13-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 2, StudentID = 20, SubjectID = 1 },
                    new Protocol { Date = DateTime.Parse("13-12-2020"), HoursTotal = 2, HoursPresent = 0, HoursVirtual = 0, StudentID = 21, SubjectID = 1 }
                    );
            }
            context.SaveChanges();
        }
    }
}