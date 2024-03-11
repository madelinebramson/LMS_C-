using System;
using App_LMS_C_.Helpers;
using Library_LMS_C_.Models;
namespace App_LMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studentHelper = new StudentHelper();
            Console.WriteLine("Choose an acion:");
            Console.WriteLine("1. Add a student enrollment");
            Console.WriteLine("2. Exit");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                while (result != 2)
                { 
                    if (result == 1)
                    {
                        studentHelper.CreateStudentRecord();
                    }
                    input = Console.ReadLine();
                    int.TryParse(input, out result);
                }
            }
        }

    }
}