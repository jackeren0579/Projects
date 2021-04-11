using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Models {
    public class SubjectsUsers {
        [Key]
        public int SubjectsUsersID { get; set; }
        [ForeignKey("UserID")]
        public int UserID { get; set; }
        [ForeignKey("Subjects")]
        public int SubjectID { get; set; }
    }
}
