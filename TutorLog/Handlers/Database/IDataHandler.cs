using System.Collections.Generic;
using TutorLog.Data.Models;

namespace TutorLog.Handlers.Database
{
    public interface IDataHandler
    {
        IList<SignInData> GetSignInData(string cookie, Campus campus);
        IList<Tutor> GetTutors(int campusID);
        IList<Topic> GetTopics(int campusID, int courseID);
        IList<Campus> GetCampuses();
        int GetCourseID(string courseName);
        int GetCenterID(string centerName);
        bool InsertLogEntry(LogEntry logEntry, IList<Topic> topics);
    }
}
