using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Models {
    public class ProtocolsListViewModel {

        public IEnumerable<Protocol> Protocols { get; set; }

        public IEnumerable<Subject> Subjects { get; set; }

        public Subject Subject { get; set; }

        public IEnumerable<Student> Students { get; set; }
        
        public Student Student { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<StudentsSubjects> StudentsSubjects { get; set; }
        

        public Dictionary<int, double> AttendanceInPercentage { get; set; }

        public Dictionary<int, List<double>> AttendanceList { get; set; }

        public Dictionary<int, double> PresentPercentage { get; set; }
        public Dictionary<int, double> VirtualPercentage { get; set; }
        public Dictionary<int, double> AbsentPercentage { get; set; }
    }
}