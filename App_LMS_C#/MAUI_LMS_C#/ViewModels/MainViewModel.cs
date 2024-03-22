using Library_LMS_C_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_LMS_C_.ViewModels
{
    internal class MainViewModel
    {
       public List<Person> Students { get; set; } = new List<Person>();
    }
}
