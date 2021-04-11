using System;
using System.Linq;

namespace FF.Models {

    public class ProtocolRepository : IProtocolRepository {

        private readonly FFDbContext context;

        public ProtocolRepository(FFDbContext ctx) {
            context = ctx;
        }

        public IQueryable<Protocol> Protocols => context.Protocols;

        public void AddProtocol(int studentID, string value, string hoursTotal, int subjectID, DateTime date) {
            int hours = Int32.Parse(hoursTotal);
            Protocol protocol = new Protocol();
            protocol.StudentID = studentID;
            protocol.HoursTotal = hours;

            switch (value) {
                case "Present":
                    protocol.HoursPresent = hours;
                    protocol.HoursVirtual = 0;
                    break;
                case "Virtual":
                    protocol.HoursPresent = 0;
                    protocol.HoursVirtual = hours;
                    break;
                case "Absent":
                    protocol.HoursPresent = 0;
                    protocol.HoursVirtual = 0;
                    break;
            }

            if (date == DateTime.Now.Date) {
                protocol.Date = DateTime.Now.Date;
            } else {
                protocol.Date = date;
            }


            protocol.SubjectID = subjectID;
            Protocol protocolobj;
            protocolobj = context.Protocols.FirstOrDefault(p => p.Date == date && p.SubjectID == subjectID && p.StudentID == studentID);
            // && p.HoursPresent == protocol.HoursPresent && p.HoursVirtual == protocol.HoursVirtual
            if (protocolobj == null) {
                context.Add(protocol);
                context.SaveChanges();
            } else if(protocolobj != null) {
                DeleteProtocol(protocolobj);
                context.Add(protocol);
                context.SaveChanges();
            }
        }
        public void DeleteProtocol(Protocol p) {
            context.Remove(p);
            context.SaveChanges();
        }

        public void UpdateProtocol(int studentID, string hoursTotal, int subjectID, DateTime date) {
            Protocol protocol = context.Protocols.FirstOrDefault(p => p.Date == date && p.SubjectID == subjectID && p.StudentID == studentID);
            if(protocol != null) {
                if(protocol.HoursPresent > 0) {
                    protocol.HoursPresent = Int32.Parse(hoursTotal);
                } else if(protocol.HoursVirtual > 0) {
                    protocol.HoursVirtual = Int32.Parse(hoursTotal);
                }
                protocol.HoursTotal = Int32.Parse(hoursTotal);
                context.SaveChanges();
            }
            
        }
    }
}
