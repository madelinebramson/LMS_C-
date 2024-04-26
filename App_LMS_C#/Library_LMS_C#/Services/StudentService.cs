
using Library_LMS_C_.Models;
using System;
using System.Net;
using Library_LMS_C_.Library.Utilities;
using Newtonsoft.Json;

namespace Library_LMS_C_.Services
{
    public class StudentService
    {
        public List<Student> Students
        {
            get
            {
                var response = new WebRequestHandler()
                .Get("/Person")
                .Result;

                var students = JsonConvert.DeserializeObject < List<Student>>(response);
                return students;
            }
        }

        private static StudentService? instance;
        public static StudentService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new StudentService();
                }
                return instance;
            }
        }

        private StudentService()
        {
            //var response = new WebRequestHandler()
            //    .Get("/Person")
            //    .Result;

            //Students = JsonConvert.DeserializeObject<List<Student>>(response) ?? new List<Student>();
        }

        public void Remove(int id)
        {
            var handler = new WebRequestHandler().Delete($"/Person/DeleteStudent/{id}");
            var studentToDelete = Students.FirstOrDefault(s => s.Id == id);
            //if (studentToDelete != null)
            //{
            //    Students.Remove(studentToDelete);
            //}
        }

        public void Add(Student student)
        {
            var response = new WebRequestHandler().Post("/Person/AddOrUpdateStudent", student).Result;
            //var myUpdatedStudent = JsonConvert.DeserializeObject<Student>(response);
            //var existingStudent = Students.FirstOrDefault(s => s.Id == myUpdatedStudent.Id);
        }

        public Student? GetById(int id)
        {

            var response = new WebRequestHandler()
                .Get($"/Person/Student/{id}")
                .Result;
            var Student = JsonConvert.DeserializeObject<Student>(response);
            return Student;
        }

        public IEnumerable<Student> Search(string query)
        {
            return Students
                .Where(s => s.Name.ToUpper().Contains(query.ToUpper()));
        }
    }
}
