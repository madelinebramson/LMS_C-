using Library_LMS_C_.Models;
using Library_LMS_C_.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_LMS_C_.ViewModels
{
    public class PersonDetailViewModel
    {
        public string Name { get; set; }
        public string ClassificationString{ get; set; }

        public void AddPerson()
        {
            PersonClassification classification = PersonClassification.Freshman;
            switch (ClassificationString)
            {
                case "S":
                    classification = PersonClassification.Senior;
                    break;
                case "J":
                    classification = PersonClassification.Junior;
                    break;
                case "O":
                    classification = PersonClassification.Sophomore;
                    break;
                case "F":
                    classification = PersonClassification.Freshman;
                    break;
            }
            StudentService.Current.Add(new Student { Name = Name, Classification = classification });
            Shell.Current.GoToAsync("//Instructor");
        }
    }
}
