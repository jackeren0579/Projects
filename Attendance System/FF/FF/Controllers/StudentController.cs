using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FF.Models;
using Microsoft.AspNetCore.Mvc;

namespace FF.Controllers {
    public class StudentController : Controller {
        private readonly ISubjectRepository SubRepository;
        private readonly IStudentRepository StuRepository;
        private readonly IStudentsSubjectsRepository SubStuRepository;
        private readonly IProtocolRepository ProtoRepository;

        public StudentController(ISubjectRepository subRepo, IStudentRepository stuRepo, IStudentsSubjectsRepository stuSubRepo, IProtocolRepository protoRepo) {
            SubRepository = subRepo;
            StuRepository = stuRepo;
            SubStuRepository = stuSubRepo;
            ProtoRepository = protoRepo;
        }

        [HttpGet]
        public IActionResult StudentStatistics(int subjectID) {
            Subject localSubject = SubRepository.Subjects.FirstOrDefault(s => s.SubjectID == subjectID);
            var studentsSubjects = SubStuRepository.StudentsSubjects;
            var protocols = ProtoRepository.Protocols;

            List<int> studentIDsInSubject = SubStuRepository.StudentsBySubject(subjectID);
            List<Student> students = new List<Student>();

            foreach (int id in studentIDsInSubject) {
                students.Add(StuRepository.FindStudentByID(id));
            }

            var attendanceList = new Dictionary<int, List<double>>();

            foreach (Student student in students.OrderBy(o => o.Name)) {
                double TimerTotal = 0, TimerPresent = 0, TimerVirtual = 0, TimerPresentProcent = 0, TimerVirtualProcent = 0, TimerAbsentProcent = 0;
                var doubleList = new List<double>();

                foreach (Protocol protocol in protocols.Where(p => p.SubjectID == localSubject.SubjectID && p.StudentID == student.StudentID)) {
                    TimerTotal += protocol.HoursTotal;
                    TimerPresent += protocol.HoursPresent;
                    TimerVirtual += protocol.HoursVirtual;

                    TimerPresentProcent = (TimerPresent / TimerTotal * 100);
                    TimerVirtualProcent = (TimerVirtual / TimerTotal * 100);
                    TimerAbsentProcent = ((TimerTotal - (TimerPresent + TimerVirtual)) / TimerTotal * 100);
                }

                doubleList.Add(TimerPresentProcent);
                doubleList.Add(TimerVirtualProcent);
                doubleList.Add(TimerAbsentProcent);

                attendanceList.Add(student.StudentID, doubleList);
            }

            return View(new ProtocolsListViewModel {
                Subject = localSubject, Students = students, StudentsSubjects = studentsSubjects, Protocols = protocols,
                AttendanceList = attendanceList
            });

        }
    }
}
