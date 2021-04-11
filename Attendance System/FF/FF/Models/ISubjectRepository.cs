using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Models {
    public interface ISubjectRepository {

        public IQueryable<Subject> Subjects { get; }
        public void AddSubject(Subject subject);
        public void EditSubject(Subject subject);
        public void SaveSubject(Subject subject);

    }
}