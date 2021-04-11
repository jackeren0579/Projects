using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FF.Models {
    public interface IStudentRepository {

        public IQueryable<Student> Students { get; }
        public Student FindStudentByID(int id);

    }
}
