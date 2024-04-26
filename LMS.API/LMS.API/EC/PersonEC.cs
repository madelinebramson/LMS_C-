
using Library_LMS_C_.Models;
using Library_LMS_C_.Services;
using LMS.API.Database;

namespace LMS.API.EC
{
    public class PersonEC
    {

        public List<Student> Students
        {
            get 
            {
                return Filebase.Current.Students;
            }
        }

        public Person Add(Student student)
        {
            if (Filebase.Current.Students.Find(c => c.Id == student.Id) == null)
            {

                student.incrementId();
                Filebase.Current.AddOrUpdate(student);
            }
            else
            { 
                Filebase.Current.AddOrUpdate(student);
            }
            return student;
        }

        public Person Remove(int id)
        {
            Student removedPerson = Filebase.Current.Students.Where(c => c.Id == id).FirstOrDefault();
            Filebase.Current.Delete(removedPerson.Id.ToString());
            return removedPerson;
        }


        public Person GetById(int id)
        {
            return Filebase.Current.Students.Where(c => c.Id == id).FirstOrDefault();
        }

    }
}

