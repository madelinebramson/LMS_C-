﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_LMS_C_.Models
{
    public class Student : Person
    {
        public Dictionary<int, double> Grades { get; set; }
        public PersonClassification Classification { get; set; }

        public Student()
        {
            Grades = new Dictionary<int, double>();
        }
        public override string ToString()
        {
            return $"[{Id}] {Name} - {Classification}";
        }
    }

}
