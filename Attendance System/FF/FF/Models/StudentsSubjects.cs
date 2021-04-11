using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FF.Models {
    public class StudentsSubjects {



        //[ForeignKey("Students")]
        [Key, Column(Order = 0)]
        public int StudentID { get; set; }
        //[ForeignKey("Subjects")]
        [Key, Column(Order = 1)]
        public int SubjectID { get; set; }
    }
}
