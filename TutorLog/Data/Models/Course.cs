using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorLog.Data.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Course(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
