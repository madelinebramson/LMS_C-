using Library_LMS_C_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_LMS_C_.Services
{
    public class StudentService
    {
        public List<Person> studentList = new List<Person>();

        public void Add(Person student)
        {
            studentList.Add(student);
        }
    }
}
