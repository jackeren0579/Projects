using FF.Models;
using FF.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Controllers {
    public class SubjectController : Controller {
        private readonly ISubjectRepository repository;
        private readonly IStudentRepository stuRepository;
        private readonly IStudentsSubjectsRepository subStuRepository;

        public SubjectController(ISubjectRepository repo, IStudentRepository repo2, IStudentsSubjectsRepository repo3) {
            repository = repo;
            stuRepository = repo2;
            subStuRepository = repo3;
        }

        public ViewResult Index() {
            return View(repository.Subjects);
        }

        [HttpGet]
        public ViewResult EditSubject(int subjectID) { 
            List<Student> studentsNot = new List<Student>();
            List<Student> students = new List<Student>();
            List<int> studentIDsInSubject = new List<int>();

            Subject subject = repository.Subjects.FirstOrDefault(s => s.SubjectID == subjectID);
            if (subjectID == 0) {
                subject = new Subject();
            }
            
            studentIDsInSubject = subStuRepository.StudentsBySubject(subjectID);

            
            foreach (int id in studentIDsInSubject) {
                students.Add(stuRepository.FindStudentByID(id));
            }

            
            StudentsSubjectsViewModel ssv = new StudentsSubjectsViewModel();
            ssv.Students = students;
            ssv.Subject = subject;
            ssv.StudentsNot = stuRepository.Students;
            studentsNot = ssv.StudentsNot.Except(students).ToList();
            ssv.StudentsNot = studentsNot;
            return View(ssv);
        }

        [HttpPost]
        public IActionResult EditSubject(StudentsSubjectsViewModel ssv) {
            if (ModelState.IsValid) {
                if (ssv.Subject.SubjectID == 0) {
                    repository.AddSubject(ssv.Subject);
                    TempData["updateMessage"] = "Oprettet!";
                } else {
                    repository.SaveSubject(ssv.Subject);
                    TempData["updateMessage"] = "Opdateret!";
                }
                
                return RedirectToAction("EditSubject", new { subjectID = ssv.Subject.SubjectID });
            } else {
                return View(ssv);
            }
        }

        [HttpPost]
        public IActionResult EditStudentSubjectState(StudentsSubjectsViewModel ssv) {
            subStuRepository.UpdateStudentSubjectState(ssv.StudentID, ssv.Subject.SubjectID);

            return RedirectToAction("EditSubject", new { subjectID = ssv.Subject.SubjectID });
        }
    }
}
