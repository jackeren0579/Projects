using System.Collections.Generic;
using System.Linq;

namespace FF.Models {
    public class StudentsSubjectsRepository : IStudentsSubjectsRepository {
        private readonly FFDbContext context;

        public StudentsSubjectsRepository(FFDbContext ctx) {
            context = ctx;
        }


        public IQueryable<StudentsSubjects> StudentsSubjects => context.StudentsSubjects;

        public void DeleteStudentSubject(StudentsSubjects ss) {
            context.Remove(ss);
            context.SaveChanges();
        }

        public void AddStudentSubject(StudentsSubjects ss) {
            context.Add(ss);
            context.SaveChanges();
        }

        public List<int> StudentsBySubject(int subjectID) {
            List<int> students = new List<int>();
            IQueryable<StudentsSubjects> studentsSubjects;
            studentsSubjects = context.StudentsSubjects.Where(s => s.SubjectID == subjectID);
            foreach (StudentsSubjects ss in studentsSubjects) {
                students.Add(ss.StudentID);
            }
            return students;
        }


        public void UpdateStudentSubjectState(int studentID, int subjectID) {
            StudentsSubjects studentSubject = context.StudentsSubjects.FirstOrDefault
                (ss => ss.SubjectID == subjectID && ss.StudentID == studentID);

            if (studentSubject == null) {
                studentSubject = new StudentsSubjects();
                studentSubject.StudentID = studentID;
                studentSubject.SubjectID = subjectID;
                AddStudentSubject(studentSubject);
            }
            else {
                DeleteStudentSubject(studentSubject);
            }
        }
    }
}
