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

        public IEnumerable<Course?> Courses
        {
            get { return FakeDatabase.Courses.Where(p => p is Course).Select(p => p as Course); }
        }
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
        public void Remove(Course course)
        {
            FakeDatabase.Courses.Remove(course);
        }
        public IEnumerable<Course?> Search(string query)
        {
            return Courses.Where(s => (s != null) && s.Name.ToUpper().Contains(query.ToUpper())
               || s.Description.ToUpper().Contains(query.ToUpper())
               || s.Code.ToUpper().Contains(query.ToUpper()));
        }

        public Course GetById(int id)
        {
            return FakeDatabase.Courses.FirstOrDefault(s => s.Id == id);
        }
        public void AddStudent (Person student, Course course)
        {
            if (course != null && FakeDatabase.Courses.Contains(course))
            {
                course.Roster.Add(student);
            }
        }
        
        public void RemoveStudent(Person student, Course course)
        {
            if (course != null && FakeDatabase.Courses.Contains (course)) 
            { 
                course.Roster.Remove(student);
            }
        }

    }
}
