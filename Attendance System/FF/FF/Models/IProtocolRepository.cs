using System;
using System.Linq;

namespace FF.Models {

    public interface IProtocolRepository {

        IQueryable<Protocol> Protocols { get; }

        void AddProtocol(int studentID, string value, string hoursTotal, int SubjectID, DateTime date);

        void DeleteProtocol(Protocol p);

        void UpdateProtocol(int studentID, string hoursTotal, int subjectID, DateTime date);

        }
}
