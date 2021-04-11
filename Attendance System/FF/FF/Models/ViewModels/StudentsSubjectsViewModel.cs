using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Models.ViewModels {
    public class StudentsSubjectsViewModel {

        public IEnumerable<Student> StudentsNot { get; set; }

        public IEnumerable<Student> Students { get; set; }

        public int StudentID { get; set; }

        public Subject Subject { get; set; }
    }
}
