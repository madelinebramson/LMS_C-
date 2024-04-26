using Library_LMS_C_.Models;
using Library_LMS_C_.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_LMS_C_.ViewModels
{
    class CourseDetailViewModel
    {
        private Course _currentCourse;
        public Course CurrentCourse
        {
            get => _currentCourse;
            set
            {
                _currentCourse = value;
                NotifyPropertyChanged();
            }
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Prefix { get; set; }
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public ObservableCollection<Person> EnrolledStudents {
            get
            {
                return new ObservableCollection<Person>(CurrentCourse.Roster);
            }
        }
        public CourseDetailViewModel(int id = 0)
        {
            if (id > 0)
            {
                LoadById(id);
            }
        }
        public ObservableCollection<Student> NotEnrolledStudents
        {
            get
            {

                var filteredList = StudentService
                    .Current
                    .Students
                    .Where(
                    s => s.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty));

                return new ObservableCollection<Student>(filteredList);
            }
        }
        
        public Student SelectedStudent { get; set; }

        private string query;
        public string Query
        {
            get => query;
            set
            {
                query = value;
                NotifyPropertyChanged(nameof(NotEnrolledStudents));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void LoadById(int id)
        {
            if (id == 0) { return; }
            var course = CourseService.Current.GetById(id) as Course;
            if (course != null) 
            {
                CurrentCourse = course;
                Name = course.Name;
                Id = course.Id;
                Description = course.Description;
                Prefix = course.Prefix;
            }


            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(Description));
            NotifyPropertyChanged(nameof(Prefix));
        }

        public void AddCourse()
        {
            if (Id <= 0)
            {
                CourseService.Current.Add(new Course { Name = Name, Description = Description, Prefix = Prefix}) ;
            }
            else
            {
                var refToUpdate = CourseService.Current.GetById(Id) as Course;
                refToUpdate.Name = Name;
                refToUpdate.Description = Description;
                refToUpdate.Prefix = Prefix; 
            }
            Shell.Current.GoToAsync("//Instructor");
        }

        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(NotEnrolledStudents));
        }

        public void AddStudentToCourse()
        {
            var idParam = SelectedStudent?.Id ?? 0;
            CourseService.Current.AddStudent(SelectedStudent,CurrentCourse);
            RefreshView();
        }

        public void RemoveStudentFromCourse()
        {
            if (SelectedStudent != null) 
            { 
                CourseService.Current.RemoveStudent(SelectedStudent, CurrentCourse);
                RefreshView();
            }
        }
    }
}
