using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorLog.Data.Models
{
    public class Topic
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public Topic(int id, string description)
        {
            this.ID = id;
            this.Description = description;
        }

        public override string ToString()
        {
            return $"{this.Description}";
        }
    }
}
