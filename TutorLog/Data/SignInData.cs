using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TutorLog
{
    public class SignInData : INotifyPropertyChanged
    {
        private string center;
        private string campus;
        private string studentName;
        private string studentID;
        private string course;
        private bool isLogged;

        public string Center
        {
            get => this.center;
            set
            {
                this.center = value;
                NotifyPropertyChanged();
            }
        }

        public string Campus
        {
            get => this.campus;
            set
            {
                this.campus = value;
                NotifyPropertyChanged();
            }
        }

        public string StudentName
        {
            get => this.studentName;
            set
            {
                this.studentName = value;
                NotifyPropertyChanged();
            }
        }

        public string StudentID
        {
            get => this.studentID;
            set
            {
                this.studentID = value;
                NotifyPropertyChanged();
            }
        }

        public string Course
        {
            get => this.course;
            set
            {
                this.course = value;
                NotifyPropertyChanged();
            }
        }

        public bool IsLogged
        {
            get => this.isLogged;
            set
            {
                this.isLogged = value;
                NotifyPropertyChanged();
            }
        }

        public SignInData(string center, string campus, string id, string name, string course, bool isLogged = false)
        {
            this.Center = center;
            this.Campus = campus;
            this.StudentName = name;
            this.Course = course;
            this.StudentID = id;
            this.IsLogged = isLogged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static bool operator==(SignInData a, SignInData b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(SignInData a, SignInData b)
        {
            return !a.Equals(b);
        }

        public override int GetHashCode()
        {
            return this.StudentID.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            SignInData data = (SignInData)obj;

            return this.StudentID == data.studentID &&
                this.StudentName == data.StudentName &&
                this.Course == data.Course;
        }
    }
}
