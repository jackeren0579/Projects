using Microsoft.EntityFrameworkCore;

namespace FF.Models {
    public class FFDbContext : DbContext {
        public FFDbContext(DbContextOptions<FFDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Protocol> Protocols { get; set; }
        public DbSet<SubjectsUsers> SubjectsUsers { get; set; }
        public DbSet<StudentsSubjects> StudentsSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<StudentsSubjects>().
                HasKey(c => new { c.StudentID, c.SubjectID });
        }
    }


}
