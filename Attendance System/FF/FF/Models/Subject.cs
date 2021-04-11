using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Models {
    public class Subject {

        //[Key]
        public int SubjectID { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
