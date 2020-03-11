using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorLog.Data.Models
{
    public class LogEntry
    {
        public int CenterID { get; private set; }
        public int CampusID { get; private set; }
        public string StudentID { get; private set; }
        public string FName { get; private set; }
        public string LName { get; private set; }
        public int CourseID { get; private set; }
        public int TutorID { get; private set; }
        public DateTime Timestamp { get; private set; }

        public LogEntry()
        {
        }

        public LogEntry(int centerID, int campusID, string studentID, string fname, string lname, int courseID, int tutorID)
        {
            this.CenterID = centerID;
            this.CampusID = campusID;
            this.StudentID = studentID;
            this.FName = fname;
            this.LName = lname;
            this.CourseID = courseID;
            this.TutorID = tutorID;
            this.Timestamp = DateTime.Now;
        }
    }
}
