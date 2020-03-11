using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorLog
{
    static class Constants
    {
        public static readonly string JsonDataKey = "aaData";
        public static readonly string LoginToken = "Login";
        public static readonly string LoginURL = @"https://ilctimetrk.waketech.edu/login";
        public static readonly string LogDataURL = @"https://ilctimetrk.waketech.edu/admin/live-status?_=";
        public static readonly int DataRequestInterval = 30000;

        public enum JsonDataIndex
        {
            Center = 0,
            Campus = 1,
            StudentID = 2,
            StudentName = 3,
            Course = 4,
            Instructor = 5,
            SignInTime = 6,
            Duration = 7,
            Referal = 8

        }
    }
}
