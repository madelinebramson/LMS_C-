using Library_LMS_C_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_LMS_C_.DataBase
{
    public static class FakeDatabase
    {
        public static List<Person> People
        {
            get { return new List<Person>(); }
        }

        public static List <Course> Courses
        { 
            get { return new List<Course>(); } 
        }


    }
}
