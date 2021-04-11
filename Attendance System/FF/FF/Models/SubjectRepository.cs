using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Models {
    public class SubjectRepository : ISubjectRepository {
        private FFDbContext context;
        public SubjectRepository(FFDbContext ctx) {
            context = ctx;
        }

        public IQueryable<Subject> Subjects => context.Subjects;

        public void AddSubject(Subject subject) {
            context.Add(subject);
            context.SaveChanges();
        }

        public void EditSubject(Subject subject) {
            //Funktionen ligger i savesubject
            throw new NotImplementedException();
        }

        public void SaveSubject(Subject subject) {
            if(subject.SubjectID == 0) {
                context.Subjects.Add(subject);
            }
            Subject EFSubject = Subjects.FirstOrDefault(s => s.SubjectID == subject.SubjectID);
            EFSubject.Name = subject.Name;

            context.SaveChanges();
        }

    }
}
