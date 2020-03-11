using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Threading.Tasks;
using TutorLog.Data.Models;
using TutorLog.Handlers.Requests;

namespace TutorLog.Handlers.Database
{
    abstract class BaseDatabaseCommand<T>
    {
        protected SQLiteConnection connection;

        protected BaseDatabaseCommand(SQLiteConnection connection)
        {
            this.connection = connection;
        }

        public abstract T Execute();

        protected virtual T Execute(Func<SQLiteCommand, T> func)
        {
            using (SQLiteCommand command = new SQLiteCommand(this.connection))
                return func(command);
        }
    }

    #region SelectCommands

    class GetSignInDataCommand : IDatabaseCommand<BindingList<SignInData>>
    {
        private readonly IRequestHandler<BindingList<SignInData>, RecordRequestData> requestHandler;
        private readonly RecordRequestData requestData;

        public GetSignInDataCommand(IRequestHandler<BindingList<SignInData>, RecordRequestData> requestHandler, string cookie, Campus campus)
        {
            this.requestHandler = requestHandler;
            this.requestData = new RecordRequestData(cookie, campus);
        }

        public BindingList<SignInData> Execute()
        {
            return this.requestHandler.MakeRequest(Constants.LogDataURL, this.requestData);
        }
    }

    class GetTutorsByCampus : BaseDatabaseCommand<IList<Tutor>>
    {
        private int campusID;
        private bool activeOnly;

        public GetTutorsByCampus(SQLiteConnection connection, int campusID, bool activeOnly = true) : base(connection)
        {
            this.campusID = campusID;
            this.activeOnly = activeOnly;
        }

        public override IList<Tutor> Execute()
        {
            return this.Execute((command) =>
            {
                IList<Tutor> tutors = new BindingList<Tutor>();

                if (activeOnly)
                    command.CommandText =
                    "select t.ID, t.FName, t.LName, t.IsActive " +
                    "from Tutor as t " +
                    "join CampusTutor as ct " +
                    "on t.ID = ct.TutorID " +
                    "join Campus as c " +
                    "on ct.CampusId = c.ID " +
                    "where t.IsActive = 1 and c.ID = @campusID;";
                else
                    command.CommandText =
                    "select t.ID, t.FName, t.LName, t.IsActive " +
                    "from Tutor as t join CampusTutor as ct " +
                    "on t.ID = ct.TutorID " +
                    "join Campus as c " +
                    "on ct.CampusId = c.ID " +
                    "where c.ID = @campusID;";

                command.Parameters.AddWithValue("@campusID", this.campusID);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tutor tutor = new Tutor(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetBoolean(3)
                        );

                        tutors.Add(tutor);
                    }
                }

                return tutors;
            });
        }
    }

    class GetTutorCommand : BaseDatabaseCommand<Tutor>
    {
        private int tutorID;

        public GetTutorCommand(SQLiteConnection connection, int tutorID) : base(connection)
        {
            this.tutorID = tutorID;
        }

        public override Tutor Execute()
        {
            return this.Execute((command) =>
            {
                Tutor tutor = null;

                command.CommandText = "select ID, FName, LName, IsActive from Tutor where ID = @tutorID";
                command.Parameters.AddWithValue("@tutorID", this.tutorID);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tutor = new Tutor(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetBoolean(3)
                        );
                    }
                }

                return tutor;

            });
        }
    }

    class GetCampusesCommand : BaseDatabaseCommand<IList<Campus>>
    {
        public GetCampusesCommand(SQLiteConnection connection) : base(connection)
        {
        }

        public override IList<Campus> Execute()
        {
            return this.Execute((command) =>
            {
                BindingList<Campus> campuses = new BindingList<Campus>();

                command.CommandText = "select ID, Name from Campus";

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Campus campus = new Campus(
                            reader.GetInt32(0),
                            reader.GetString(1)
                        );

                        campuses.Add(campus);
                    }
                }

                return campuses;
            });
        }
    }

    class GetTopicsCommand : BaseDatabaseCommand<IList<Topic>>
    {
        private readonly int campusID;
        private readonly int courseID;

        public GetTopicsCommand(SQLiteConnection connection, int campusID, int courseID) : base(connection)
        {
            this.campusID = campusID;
            this.courseID = courseID;
        }

        public override IList<Topic> Execute()
        {
            return this.Execute((command) =>
            {
                IList<Topic> topics = new BindingList<Topic>();

                command.CommandText =
                "select t.ID, t.Description " +
                "from Course as co " +
                "join CourseTopic as coto " +
                "on co.ID = coto.CourseID " +
                "join Topic as t " +
                "on coto.TopicID = t.ID " +
                "join CampusTopic as cato " +
                "on t.ID = cato.TopicID " +
                "join Campus as ca " +
                "on cato.CampusID = ca.ID " +
                "where co.ID = @courseID and ca.ID = @campusID;";

                command.Parameters.AddWithValue("@courseID", courseID);
                command.Parameters.AddWithValue("@campusID", campusID);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Topic topic = new Topic(reader.GetInt32(0), reader.GetString(1));
                        topics.Add(topic);
                    }
                }

                return topics;
            });
        }
    }

    class GetCourseIDCommand : BaseDatabaseCommand<int>
    {
        private readonly string courseName;

        public GetCourseIDCommand(SQLiteConnection connection, string courseName) : base(connection)
        {
            this.courseName = courseName;
        }

        public override int Execute()
        {
            int courseID = 0;

            return this.Execute((command) =>
            {
                command.CommandText = "select ID from Course where Name = @courseName;";
                command.Parameters.AddWithValue("@courseName", this.courseName);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        courseID = reader.GetInt32(0);
                }

                return courseID;

            });
        }
    }

    class GetCenterIDCommand : BaseDatabaseCommand<int>
    {
        private readonly string centerName;

        public GetCenterIDCommand(SQLiteConnection connection, string centerName) : base(connection)
        {
            this.centerName = centerName;
        }

        public override int Execute()
        {
            int centerID = 0;

            return this.Execute((command) =>
            {
                command.CommandText = "select ID from Center where Name = @centerName;";
                command.Parameters.AddWithValue("@centerName", this.centerName);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        centerID = reader.GetInt32(0);
                }

                return centerID;

            });
        }
    }


    #endregion


    #region InsertCommands

    class InsertLogEntryCommand : BaseDatabaseCommand<bool>
    {
        private LogEntry logEntry;
        private IList<Topic> topics;

        public InsertLogEntryCommand(SQLiteConnection connection, LogEntry logEntry, IList<Topic> topics) : base(connection)
        {
            this.logEntry = logEntry;
            this.topics = topics;
        }

        public override bool Execute()
        {
            return this.Execute((command) =>
            {
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        command.CommandText =
                            "insert into LogEntry values " +
                            "(@centerID, @campusID, @studentID, @fname, @lname, @courseID, @tutorID);";

                        command.Parameters.AddWithValue("@centerID", logEntry.CenterID);
                        command.Parameters.AddWithValue("@campusID", logEntry.CampusID);
                        command.Parameters.AddWithValue("@studentID", logEntry.StudentID);
                        command.Parameters.AddWithValue("@fname", logEntry.FName);
                        command.Parameters.AddWithValue("@lname", logEntry.LName);
                        command.Parameters.AddWithValue("@courseID", logEntry.CourseID);
                        command.Parameters.AddWithValue("@tutorID", logEntry.TutorID);

                        if (command.ExecuteNonQuery() > 0)
                        {
                            long lastLogEntryID = connection.LastInsertRowId;

                            foreach (var topic in topics)
                            {
                                command.CommandText = "insert into LogEntryTopic values (@logEntryID, @topicID);";

                                command.Parameters.AddWithValue("@logEntryID", lastLogEntryID);
                                command.Parameters.AddWithValue("@topicID", topic.ID);

                                if (command.ExecuteNonQuery() <= 0)
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }

                            return true;
                        }

                        transaction.Rollback();
                        return false;
                    }
                    catch (SQLiteException)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            });
        }
    }

    #endregion
}
