using Library_LMS_C_.DataBase;
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

        private static StudentService? _instance;

        public IEnumerable<Student?> Students
        {
            get { return FakeDatabase.People.Where(p => p is Student).Select(p => p as Student); }
        }
        private StudentService()
        {
        }

        public static StudentService Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StudentService();
                }

                return _instance;
            }
        }
        public void Add(Student student)
        {
            FakeDatabase.People.Add(student);
        }

        public void Remove(Student student)
        {
            FakeDatabase.People.Remove(student);
        }
   
        public IEnumerable<Student?> Search(string query)
        {
            return Students.Where(s => (s != null) && s.Name.ToUpper().Contains(query.ToUpper()));
        }
    }
}
