using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace FF.Models {
    public class SeedStudentData {
        public static void EnsurePopulated(IApplicationBuilder app) {
            FFDbContext context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<FFDbContext>();

            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }

            if (!context.Students.Any()) {
                context.Students.AddRange(
                    new Student { Name = "Bjarke Villadsen", Email = "bjarke@eamv.dk", IsActive = true },
                    new Student { Name = "Casper Nielsen", Email = "casper@eamv.dk", IsActive = true },
                    new Student { Name = "Christian Nygaard Pedersen", Email = "christian@eamv.dk", IsActive = true },
                    new Student { Name = "Claus Jørgensen", Email = "claus@eamv.dk", IsActive = true },
                    new Student { Name = "Daniel Bjerre Madsen", Email = "daniel@eamv.dk", IsActive = true },
                    new Student { Name = "Dean Marco Dalager Birch Nielsen", Email = "dean@eamv.dk", IsActive = true },
                    new Student { Name = "Emil Overgaard Jensen", Email = "emil@eamv.dk", IsActive = true },
                    new Student { Name = "Jack Jakobsen", Email = "jack@eamv.dk", IsActive = true },
                    new Student { Name = "Jakob Rasmussen", Email = "jakob@eamv.dk", IsActive = true },
                    new Student { Name = "Mads Brandt", Email = "mads@eamv.dk", IsActive = true },
                    new Student { Name = "Mark Enggaard", Email = "mark@eamv.dk", IsActive = true },
                    new Student { Name = "Mark Pearson", Email = "mark@eamv.dk", IsActive = true },
                    new Student { Name = "Martin Godthaab Larsen", Email = "martin@eamv.dk", IsActive = true },
                    new Student { Name = "Mathias Jensen", Email = "mathias@eamv.dk", IsActive = true },
                    new Student { Name = "Pia Degn Eriksen", Email = "pia@eamv.dk", IsActive = true },
                    new Student { Name = "Sabine Amtkjær", Email = "sabine@eamv.dk", IsActive = true },
                    new Student { Name = "Simon Markussen", Email = "simon@eamv.dk", IsActive = true },
                    new Student { Name = "Søren Kaalund", Email = "søren@eamv.dk", IsActive = true },
                    new Student { Name = "Victor Eriksen Siig", Email = "victor@eamv.dk", IsActive = true },
                    new Student { Name = "Viktor Juul", Email = "viktor@eamv.dk", IsActive = true },
                    new Student { Name = "Yasin Güler", Email = "yasin@eamv.dk", IsActive = true }
                    );
            }
            context.SaveChanges();
        }
    }
}