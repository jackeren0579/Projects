using FF.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FF.Controllers {
    public class RegistrationController : Controller {

        private readonly ISubjectRepository subjectRepository;
        private readonly IStudentRepository studentRepository;
        private readonly IStudentsSubjectsRepository studentsSubjectsRepository;
        private readonly IProtocolRepository protocolRepository;



        public RegistrationController(ISubjectRepository subjRepo, IStudentRepository studRepo, IProtocolRepository protRepo, IStudentsSubjectsRepository ssRepo) {
            subjectRepository = subjRepo;
            studentRepository = studRepo;
            studentsSubjectsRepository = ssRepo;
            protocolRepository = protRepo;
        }

        public ViewResult Index() {
            var subjects = subjectRepository.Subjects;
            var students = studentRepository.Students;
            var protocols = protocolRepository.Protocols.OrderByDescending(p => p.Date);


            return View(new ProtocolsListViewModel { Students = students, Subjects = subjects, Protocols = protocols });
        }

        [HttpGet]
        public ViewResult RegisterAttendance(int subjectID, DateTime date) {
            Subject localSubject = subjectRepository.Subjects.FirstOrDefault(s => s.SubjectID == subjectID);
            var studentsSubjects = studentsSubjectsRepository.StudentsSubjects.Where(ss => ss.SubjectID == subjectID);
            var students = studentRepository.Students;
            var protocols = protocolRepository.Protocols;

            TempData["HoursTotal"] = 2;

            return View(new ProtocolsListViewModel { Students = students, Subject = localSubject, StudentsSubjects = studentsSubjects, Protocols = protocols, Date = date });
        }

        [HttpPost]
        public IActionResult SaveAttendance(int StudentID, string Value, string HoursTotal, int SubjectID, DateTime date) {
            Subject localSubject = subjectRepository.Subjects.FirstOrDefault(s => s.SubjectID == SubjectID);
            var students = studentRepository.Students;
            var studentsSubjects = studentsSubjectsRepository.StudentsSubjects;
            var protocols = protocolRepository.Protocols;

            TempData["HoursTotal"] = HoursTotal;

            protocolRepository.AddProtocol(StudentID, Value, HoursTotal, SubjectID, date);


            return View("RegisterAttendance", new ProtocolsListViewModel { Students = students, Subject = localSubject, StudentsSubjects = studentsSubjects, Protocols = protocols, Date = date });
        }

        [HttpPost]
        public IActionResult SaveHours(string HoursTotal, int SubjectID, DateTime date) {
            Subject localSubject = subjectRepository.Subjects.FirstOrDefault(s => s.SubjectID == SubjectID);
            var students = new List<Student>();
            var studentsSubjects = studentsSubjectsRepository.StudentsSubjects;
            var protocols = protocolRepository.Protocols;
            List<int> studentIDsInSubject = new List<int>();

            studentIDsInSubject = studentsSubjectsRepository.StudentsBySubject(SubjectID);


            foreach (int id in studentIDsInSubject) {
                students.Add(studentRepository.FindStudentByID(id));
            }


            TempData["HoursTotal"] = HoursTotal;
            foreach (Student student in students) {
                protocolRepository.UpdateProtocol(student.StudentID, HoursTotal, SubjectID, date);
            }




            return View("RegisterAttendance", new ProtocolsListViewModel { Students = students, StudentsSubjects = studentsSubjects, Protocols = protocols, Date = date, Subject = localSubject });
        }
    }
}