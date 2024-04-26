using Library_LMS_C_.Models;
using LMS.API.Database;

namespace LMS.API.EC
{
    public class CourseEC
    {


        public List<Course?> Courses
        {
            get
            {
                return FakeDatabase.Courses;
            }
        }
        public Course Add(Course course)
        {
            FakeDatabase.Courses.Add(course);
            return FakeDatabase.Courses.Last();
        }

        public Course Delete(Course course)
        {
            FakeDatabase.Courses.Remove(course);
            return course;
        }

        public Course GetById(int id)
        {
            return FakeDatabase.Courses.FirstOrDefault(s => s.Id == id);
        }
        public Course AddStudent(Person student, Course course)
        {
            if (course != null && FakeDatabase.Courses.Contains(course))
            {
                course.Roster.Add(student);
            }
            return course;

        }

        public Course RemoveStudent(Person student, Course course)
        {
            if (course != null && FakeDatabase.Courses.Contains(course))
            {
                course.Roster.Remove(student);
            }
            return course;

        }
    }
}
