using Library_LMS_C_.Models;
using Library_LMS_C_.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_LMS_C_.ViewModels
{
    public class InstructorViewViewModel : INotifyPropertyChanged
    {
        public InstructorViewViewModel()
        {
            IsEnrollmentsVisible= true;
            IsCoursesVisible= false;

        }
        public ObservableCollection<Person> People
        {
            get
            {
                var filteredList = StudentService
                    .Current
                    .Students
                    .Where(
                    s => s.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty));

                return new ObservableCollection<Person>(filteredList);
            }
        }
        
        public ObservableCollection<Course> Courses
        {
            get
            {
                var filteredList = CourseService
                    .Current
                    .Courses
                    .Where(
                    s => s.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty));

                return new ObservableCollection<Course>(filteredList);
            }
        }

        public string Title { get => "Instructor / Administrator Menu"; }

        public bool IsEnrollmentsVisible
        { get; set; }

        public bool IsCoursesVisible
        { get; set; }

        public void ShowEnrollments()
        {
            IsEnrollmentsVisible = true;
            IsCoursesVisible = false;
            NotifyPropertyChanged("IsEnrollmentsVisible");
            NotifyPropertyChanged("IsCoursesVisible");
        }

        public void ShowCourses()
        {
            IsEnrollmentsVisible = false;
            IsCoursesVisible = true;
            NotifyPropertyChanged("IsEnrollmentsVisible");
            NotifyPropertyChanged("IsCoursesVisible");
        }
        public Student SelectedPerson { get; set; }

        public Course SelectedCourse { get; set; }
       
        private string query;

        public string Query
        {
            get => query;
            set
            {
                query = value;
                NotifyPropertyChanged(nameof(People));
                NotifyPropertyChanged(nameof(Courses));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddEnrollmentClick(Shell s)
        {
            s.GoToAsync($"//PersonDetail");
        }

        public void EditEnrollmentClick(Shell s)
        {
            if(SelectedPerson == null)
            {
                return;
            }
            var idParam = SelectedPerson?.Id ?? 0;
            s.GoToAsync($"//PersonDetail?personId={idParam}");
        }

        public void AddCourseClick(Shell s)
        {
            var idParam = SelectedCourse?.Id ?? 0;
            s.GoToAsync($"//CourseDetail?courseId={idParam}");
        }
        
        public void RemoveEnrollmentClick() 
        { 
            if (SelectedPerson == null) { return; }

            StudentService.Current.Remove(SelectedPerson.Id);
            RefreshView();
        }

        public void RemoveCourseClick()
        {
            if (SelectedCourse == null) { return;}
            CourseService.Current.Remove(SelectedCourse);
            RefreshView();
        }

        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(People));
            NotifyPropertyChanged(nameof(Courses));
        }
    }
}
