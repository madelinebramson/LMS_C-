using Library_LMS_C_.DataBase;
using Library_LMS_C_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_LMS_C_.Services
{
    public class CourseService
    {
        private static CourseService? _instance;
        private CourseService() 
        { 
        }
        public static CourseService Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CourseService();
                }
                return _instance;
            }
        }
        public void Add(Course course)
        {
            FakeDatabase.Courses.Add(course);
        }
        public List<Course> Courses
        { 
            get 
            { 
                return FakeDatabase.Courses;
            } 
        }
        public IEnumerable<Course> Search(string query)
        {
            return Courses.Where(s => s.Name.ToUpper().Contains(query.ToUpper())
               || s.Description.ToUpper().Contains(query.ToUpper())
               || s.Code.ToUpper().Contains(query.ToUpper()));
        }

    }
}
