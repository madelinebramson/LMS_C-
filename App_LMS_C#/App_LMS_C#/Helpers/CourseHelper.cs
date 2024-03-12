using Library_LMS_C_.Services;
using Library_LMS_C_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_LMS_C_.Helpers
{
    public class CourseHelper
    {
        private CourseService courseService = new CourseService();

        public void CreateCourseRecord(Course? selectedCourse = null)
        {
            Console.WriteLine("What is the course code?");
            var code = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the name of the course?");
            var name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the description of the course");
            var description = Console.ReadLine() ?? string.Empty;

            bool isNewCourse = false;
            if (selectedCourse == null)
            {
                isNewCourse = true;
                selectedCourse = new Course();
            }

            selectedCourse.Name = name;
            selectedCourse.Code = code;
            selectedCourse.Description = description;

            if (isNewCourse) 
            {
                courseService.Add(selectedCourse);
            }

        }
        public void UpdateCourseRecord()
        {
            Console.WriteLine("Enter the code for the course to update:");
            ListCourses();

            var selection = Console.ReadLine();

            var selectedCourse = courseService.Courses.FirstOrDefault(c => c.Name == selection);
            if (selectedCourse != null)
            {
                CreateCourseRecord(selectedCourse);
            }
        }
        public void ListCourses()
        {
            courseService.Courses.ForEach(Console.WriteLine);
        }
    }
}
