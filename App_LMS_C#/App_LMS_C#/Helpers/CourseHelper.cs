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
        private CourseService courseService;
        private StudentService studentService;

        public CourseHelper()
        {
            studentService = StudentService.Current;
            courseService = CourseService.Current;
        }

        public void CreateCourseRecord(Course? selectedCourse = null)
        {
            Console.WriteLine("What is the course code?");
            var code = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the name of the course?");
            var name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the description of the course");
            var description = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Which students should be enrolled in this course('Q'to Quit)");
            var roster = new List<Person>();
            bool continueAdding = true;
            while (continueAdding)
            {
                studentService.Students.Where(s => !roster.Any(s2 => s2.Id == s.Id)).ToList().ForEach(Console.WriteLine);
                var selection = "Q";
                if (studentService.Students.Any(s => !roster.Any(s2 => s2.Id == s.Id)))
                {
                   selection = Console.ReadLine() ?? string.Empty;
                }
                if (selection.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    continueAdding = false;
                }
                else
                {
                    var selectedId = int.Parse(selection);
                    var selectedStudent = studentService.Students.FirstOrDefault(s => s.Id == selectedId);

                    if (selectedStudent != null) 
                    { 
                        roster.Add(selectedStudent);
                    }
                }
            }
            Console.WriteLine("Would you like to add assingments? (Y/N)");
            var assignResponse = Console.ReadLine() ?? "N";

            var assignments = new List<Assignment>();
            if (assignResponse.Equals("Y", StringComparison.InvariantCultureIgnoreCase)) 
            {
                continueAdding = true;
                while (continueAdding)
                {
                    Console.WriteLine("Name:");
                    var AssignName = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Description:");
                    var AssignDescription = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("TotalPoints: ");
                    var totalPoints = decimal.Parse(Console.ReadLine() ?? "100");
                    Console.WriteLine("DueDate:");
                    var dueDate = DateTime.Parse(Console.ReadLine() ?? "01/01/1900");

                    assignments.Add(new Assignment
                    {
                        Name = AssignName,Description = AssignDescription, TotalAvaliablePoints = totalPoints,DueDate = dueDate
                    });
                    Console.WriteLine("Add more courses? (Y/N)");
                    assignResponse = Console.ReadLine() ?? "N";
                    if (assignResponse.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                    {
                        continueAdding = false;
                    }
                }
            }

            bool isNewCourse = false;
            if (selectedCourse == null)
            {
                isNewCourse = true;
                selectedCourse = new Course();
            }

            selectedCourse.Name = name;
            selectedCourse.Code = code;
            selectedCourse.Description = description;
            selectedCourse.Roster = new List<Person>();
            selectedCourse.Roster.AddRange(roster);
            selectedCourse.Assignments = new List<Assignment>();
            selectedCourse.Assignments.AddRange(assignments);


            if (isNewCourse) 
            {
                courseService.Add(selectedCourse);
            }

        }
        public void UpdateCourseRecord()
        {
            Console.WriteLine("Enter the code for the course to update:");
            SearchCourses();

            var selection = Console.ReadLine();

            var selectedCourse = courseService.Courses.FirstOrDefault(c => c.Name == selection);
            if (selectedCourse != null)
            {
                CreateCourseRecord(selectedCourse);
            }
        }

        public void SearchCourses(string? query = null)
        {
            if (string.IsNullOrEmpty(query))
            {
                courseService.Courses.ForEach(Console.WriteLine);
            }
            else
            {
                courseService.Search(query).ToList().ForEach(Console.WriteLine);
            }

            Console.WriteLine("Select a course:");
            var code = Console.ReadLine() ?? string.Empty;

            var selectedCourse = courseService.Courses.FirstOrDefault(c => c.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));

            if (selectedCourse != null)
            {
                Console.WriteLine(selectedCourse.DetailDisplay);
            }
        }
    }
}
