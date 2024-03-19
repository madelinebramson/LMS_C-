﻿using System;
using App_LMS_C_.Helpers;
namespace App_LMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studentHelper = new StudentHelper();
            var courseHelper = new CourseHelper();

            bool cont = true;
            while (cont)
            {
                Console.WriteLine("1. Maintain Students");
                Console.WriteLine("2. Maintin Courses");
                Console.WriteLine("3. Exit");
                var input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    if (result == 1)
                    {
                        ShowStudentMenu(studentHelper);
                    }
                    else if (result == 2)
                    {
                        ShowCourseMenu(courseHelper);
                    }
                    else if (result == 3)
                    {
                        cont = false;
                    }
                }
            }
        }

        static void ShowStudentMenu(StudentHelper studentHelper)
        {

            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Add a student enrollment");
            Console.WriteLine("2. Update a student enrollment");
            Console.WriteLine("3. List all enrolled students");
            Console.WriteLine("4. Search for a student");

            var input = Console.ReadLine();

            if (int.TryParse(input, out int result))
            {
                if (result == 1)
                {
                    studentHelper.CreateStudentRecord();
                }
                else if (result == 2)
                {
                    studentHelper.UpdateStudentRecord();
                }
                else if (result == 3)
                {
                    studentHelper.ListStudents();
                }
                else if (result == 4)
                {
                    studentHelper.SearchStudents();
                }
            }
        }

        static void ShowCourseMenu(CourseHelper courseHelper)
        {
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Add a new course");
            Console.WriteLine("2. Update a course");
            Console.WriteLine("3. List all courses");
            Console.WriteLine("4. Search for a course");

            var input = Console.ReadLine();

            if (int.TryParse(input, out int result))
            {
                if (result == 1)
                {
                    courseHelper.CreateCourseRecord();
                }
                else if (result == 2)
                {
                    courseHelper.UpdateCourseRecord();
                }
                else if (result == 3)
                {
                    courseHelper.SearchCourses();
                }
                else if (result == 4)
                {
                    Console.WriteLine("Enter a query:");
                    var query = Console.ReadLine() ?? string.Empty;
                    courseHelper.SearchCourses(query);
                }
            }
        }
    }
}