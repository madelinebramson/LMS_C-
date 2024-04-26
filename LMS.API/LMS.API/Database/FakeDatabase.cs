using Library_LMS_C_.Models;

namespace LMS.API.Database
{
    public class FakeDatabase
    {
            private static List<Student> people = new List<Student>();
            private static List<Course> courses = new List<Course>();
            public static List<Student> People
            {
                get { return people; }
            }

            public static List<Course> Courses
            {
                get { return courses; }
            }

    }
}
