using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Models {

    public class Protocol {

        [Key]
        public int ProtocolID { get; set; }

        public DateTime Date { get; set; }

        public int HoursTotal { get; set; }
        public int HoursPresent { get; set; }
        public int HoursVirtual { get; set; }

        [ForeignKey("StudentID")]
        public int StudentID { get; set; }

        [ForeignKey("SubjectID")]
        public int SubjectID { get; set; }

    }
}
