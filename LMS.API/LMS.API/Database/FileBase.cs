using Library_LMS_C_.Models;
using Newtonsoft.Json;
using LMS.API.EC;
using Library_LMS_C_.Services;
using Microsoft.AspNetCore.SignalR;
namespace LMS.API.Database
{
    public class Filebase
    {
        private string _root;
        private string _studentRoot;
        private string _courseRoot;
        private static Filebase _instance;


        public static Filebase Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Filebase();
                }

                return _instance;
            }
        }

        private Filebase()
        {
            _root = "C:\\temp";
            _studentRoot = $"{_root}\\Student";
            _courseRoot = $"{_root}\\Course";

            if (!Directory.Exists(_studentRoot)) 
            {
                Directory.CreateDirectory(_studentRoot);
            }
            if (!Directory.Exists(_courseRoot))
            {
                Directory.CreateDirectory(_courseRoot);
            }
                    
        }

        private int lastStudentId => Students.Any() ? Students.Select(c => c.Id).Max() : 0;

        public Student AddOrUpdate(Student s)
        {

            var path = $"{_studentRoot}\\{s.Id}.json";

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            else
            {
                s.Id = lastStudentId + 1;
                path = $"{_studentRoot}\\{s.Id}.json";
            }
            File.WriteAllText(path, JsonConvert.SerializeObject(s));

            return s;
        }


        public List<Student> Students
        {
            get
            {
                var root = new DirectoryInfo(_studentRoot);
                var _students = new List<Student>();
                foreach (var todoFile in root.GetFiles())
                {
                    var todo = JsonConvert.DeserializeObject<Student>(File.ReadAllText(todoFile.FullName));
                    if (todo != null)
                        _students.Add(todo);
                }
                return _students;
            }
        }

        public List<Course> Courses
        {
            get
            {
                var root = new DirectoryInfo(_courseRoot);
                var _course = new List<Course>();
                foreach (var appFile in root.GetFiles())
                {
                    var app = JsonConvert.DeserializeObject<Course>(File.ReadAllText(appFile.FullName));
                    _course.Add(app);
                }
                return _course;
            }
        }

        public bool Delete(string id)
        {
            var path = $"{_studentRoot}\\{id}.json";
            if (File.Exists(path)) { File.Delete(path); }
            return true;
        }
    }

}
