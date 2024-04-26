
using Library_LMS_C_.Library.Utilities;
using Library_LMS_C_.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Library_LMS_C_.Library.Utilities;
using Library_LMS_C_.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Library_LMS_C_.Services
{
    public class CourseService
    {
        public List<Course> Courses;
        private static CourseService? _instance;

        private CourseService()
        {
            var response = new WebRequestHandler().Get("/Course").Result;
            Courses = JsonConvert.DeserializeObject<List<Course>>(response) ?? new List<Course>();
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
            var response = new WebRequestHandler().Post("/Course/AddOrUpdateCourse", course).Result;
            var myUpdatedCourse = JsonConvert.DeserializeObject<Course>(response);
            if (myUpdatedCourse != null) 
            {
                var existingcourse = Courses.FirstOrDefault(c => c.Id == myUpdatedCourse.Id);
                if (existingcourse != null)
                {
                    Courses.Add(myUpdatedCourse);
                }
                else
                {
                    var index = Courses.IndexOf(existingcourse);
                    Courses.RemoveAt(index);
                    Courses.Insert(index, myUpdatedCourse);
                }
            }
        }

        public void Remove(Course course)
        {
            var handler = new WebRequestHandler().Delete($"/Course/DeleteCourse/{course.Id}");
            var courseToDelete = Courses.FirstOrDefault(c => c.Id == course.Id);
            if (courseToDelete != null)
            {
                Courses.Remove(courseToDelete);
            }

        }

        public IEnumerable<Course?> Search(string query)
        {
            return Courses.Where(s => (s != null) && s.Name.ToUpper().Contains(query.ToUpper())
               || s.Description.ToUpper().Contains(query.ToUpper())
               || s.Code.ToUpper().Contains(query.ToUpper()));
        }

        public Course GetById(int id)
        {
            var response = new WebRequestHandler()
                .Get("$/Course/Course/{id}")
                .Result;
            var Course = JsonConvert.DeserializeObject<Course>(response);
            return Course;
        }

        public void AddStudent(Student student, Course course)
        {
            var response = new WebRequestHandler()
                .Post($"/Course/{course.Id}/AddStudent", student).Result;
            var StudentToAdd = JsonConvert.DeserializeObject<Student>(response);
            if (StudentToAdd != null && !course.Roster.Contains(student))
            {
                course.Roster.Add(StudentToAdd);
            }
        }

        public void RemoveStudent(Student student, Course course)
        {
            var response = new WebRequestHandler().Post($"/Course/{course.Id}/RemoveStudent", student).Result;
            var studentToRemove = JsonConvert.DeserializeObject<Student>(response);
            if (studentToRemove != null &&  course.Roster.Contains(studentToRemove))
            {
                course.Roster.Remove(studentToRemove);
            }
        }

        public void AddStudentToCourse(Student student, Course course)
        {
            StudentService.Current.Add(student);
            AddStudent(student, course);
        }

    
        public void RemoveStudentFromCourse(Student student, Course course)
        {
            RemoveStudent(student, course);
            StudentService.Current.Remove(student.Id);
        }
    }
}

