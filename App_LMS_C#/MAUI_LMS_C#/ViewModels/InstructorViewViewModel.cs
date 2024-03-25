﻿using Library_LMS_C_.Models;
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
        public ObservableCollection<Person> People
        {
            get
            {
                return new ObservableCollection<Person>(StudentService.Current.Students);
            }
        }
        public Person SelectedPerson { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddClick(Shell s)
        {
            var idParam = SelectedPerson?.Id ?? 0;
            s.GoToAsync($"//PersonDetail?personId={idParam}");
        }
        
        public void RemoveClick() 
        { 
            if (SelectedPerson == null) { return; }

            StudentService.Current.Remove((Student)SelectedPerson);
            RefreshView();
        }

        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(People));
        }
    }
}
