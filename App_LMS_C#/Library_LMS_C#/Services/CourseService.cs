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
        private List<Course> courseList = new List<Course>();
        public void Add(Course course)
        {
            courseList.Add(course);
        }
        public List<Course> Courses
        { 
            get 
            { 
                return courseList;
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
