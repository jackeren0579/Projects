using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FF.Models {
    public interface IStudentsSubjectsRepository {

        IQueryable<StudentsSubjects> StudentsSubjects { get; }

        public List<int> StudentsBySubject(int subjectID);

        public void UpdateStudentSubjectState(int studentID, int subjectID);
    }
}
