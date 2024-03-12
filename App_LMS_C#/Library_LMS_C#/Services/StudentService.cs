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
        private List<Person> studentList = new List<Person>();

        public void Add(Person student)
        {
            studentList.Add(student);
        }
        public List<Person> Students
        {
           get
           { 
               return studentList; 
           }
        }   
        public IEnumerable<Person> Search(string query)
        {
            return studentList.Where(s => s.Name.ToUpper().Contains(query.ToUpper()));
        }
    }
}
