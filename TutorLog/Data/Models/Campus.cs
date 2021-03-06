﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorLog.Data.Models
{
    public class Campus
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Campus(int id, string name)
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
