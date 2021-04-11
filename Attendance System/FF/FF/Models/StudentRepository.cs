using System.Linq;

namespace FF.Models {
    public class StudentRepository : IStudentRepository {
        private readonly FFDbContext context;

        public StudentRepository(FFDbContext ctx) {
            context = ctx;
        }


        public IQueryable<Student> Students => context.Students;

        public Student FindStudentByID(int id) {
            IQueryable<Student> students = Students.Where(s => id == s.StudentID);

            return students.FirstOrDefault();

        }
    }
}
