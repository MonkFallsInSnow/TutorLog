using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using TutorLog.Data.Models;
using TutorLog.Handlers.Requests;

namespace TutorLog.Handlers.Database
{
    public class DataHandler : IDataHandler 
    {
        private readonly SQLiteConnection connection;
        private readonly IRequestHandler<BindingList<SignInData>, RecordRequestData> requestHandler;

        public DataHandler(SQLiteConnection connection, IRequestHandler<BindingList<SignInData>, RecordRequestData> requestHandler)
        {
            this.connection = connection;
            this.requestHandler = requestHandler;
        }

        public IList<SignInData> GetSignInData(string cookie, Campus campus)
        {
            return new GetSignInDataCommand(this.requestHandler, cookie, campus).Execute();
        }

        public IList<Topic> GetTopics(int campusID, int courseID)
        {
            return new GetTopicsCommand(this.connection, campusID, courseID).Execute();
        }

        public IList<Tutor> GetTutors(int campusID)
        {
            return new GetTutorsByCampus(this.connection, campusID).Execute();
        }

        public IList<Campus> GetCampuses()
        {
            return new GetCampusesCommand(this.connection).Execute();
        }

        public int GetCourseID(string courseName)
        {
            return new GetCourseIDCommand(this.connection, courseName).Execute();
        }

        public int GetCenterID(string centerName)
        {
            return new GetCenterIDCommand(this.connection, centerName).Execute();
        }

        public bool InsertLogEntry(LogEntry logEntry, IList<Topic> topics)
        {
            return new InsertLogEntryCommand(this.connection, logEntry, topics).Execute();
        }
    }
}
