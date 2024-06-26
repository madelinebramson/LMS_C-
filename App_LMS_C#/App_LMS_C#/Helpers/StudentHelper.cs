﻿using Library_LMS_C_.Models;
using Library_LMS_C_.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_LMS_C_.Helpers
{
    internal class StudentHelper
    {
        private StudentService studentService;
        private CourseService courseService;

        public StudentHelper()
        {
            studentService= StudentService.Current;
            courseService= CourseService.Current;
        }
        public void CreateStudentRecord(Student? selectedStudent = null)
        {
            Console.WriteLine("What is the student's ID?");
            var ID = Console.ReadLine();
            Console.WriteLine("What is the name of the student?");
            var name = Console.ReadLine();
            Console.WriteLine("What is the student's classification? [(F)reshman, S(O)phomore, (J)unior, (S)enior]");
            var classification = Console.ReadLine() ?? string.Empty;

            PersonClassification classEnum = PersonClassification.Freshman;

            if (classification.Equals("O", StringComparison.InvariantCultureIgnoreCase))
            {
                classEnum = PersonClassification.Sophomore;
            }
            else if (classification.Equals("J", StringComparison.InvariantCultureIgnoreCase))
            {
                classEnum = PersonClassification.Junior;
            }
            else if (classification.Equals("S", StringComparison.InvariantCultureIgnoreCase))
            {
                classEnum = PersonClassification.Senior;
            }

            bool isCreate = false;
            if (selectedStudent == null)
            {
                isCreate = true;
                selectedStudent = new Student();
            }

            selectedStudent.Id = int.Parse(ID ?? "0");
            selectedStudent.Name = name ?? string.Empty;
            selectedStudent.Classification = classEnum;

            if (isCreate)
            {
                studentService.Add(selectedStudent);
            }
        }   

        public void UpdateStudentRecord()
        {
            Console.WriteLine("Select a student to update: (Use ID)");
            ListStudents();

            var selectionStr = Console.ReadLine();
            if (int.TryParse (selectionStr, out var selectionInt)) 
            {
                var selectedStudent = studentService.Students.FirstOrDefault(s => s.Id == selectionInt);
                if (selectedStudent != null) 
                {
                    CreateStudentRecord(selectedStudent);
                }
            }
        }

        public void ListStudents()
        {
            Console.WriteLine("Select a student:");
            var selectionStr = Console.ReadLine ();
            var selectionInt = int.Parse(selectionStr ?? "0");

            Console.WriteLine("Student Course List: ");
            courseService.Courses.Where(c => c.Roster.Any(s => s.Id == selectionInt)).ToList().ForEach(Console.WriteLine);
        }

        public void SearchStudents()
        {
            Console.WriteLine("Enter a query:");
            var query = Console.ReadLine() ?? string.Empty;

            studentService.Search(query).ToList().ForEach(Console.WriteLine);
            var selectionStr = Console.ReadLine();
            var selectionInt = int.Parse(selectionStr ?? "0");

            Console.WriteLine("Student Course List: ");
            courseService.Courses.Where(c => c.Roster.Any(s => s.Id == selectionInt)).ToList().ForEach(Console.WriteLine);

        }
    }

}
