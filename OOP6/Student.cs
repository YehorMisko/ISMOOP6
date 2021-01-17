using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP6
{
    class Student
    {
        public string Surname { set; get; }
        public string Name { set; get; }
        public string MiddleName { set; get; }
        public string Group { set; get; }
        public int Year { set; get; }
        public int Grade { set; get; }
        public Student()
        {
            Surname = "";
            Name = "";
            MiddleName = "";
            Group = "";
            Year = 0;
            Grade = 0;
        }
        public string GetSurname()
        {
            return Surname;
        }
        public string GetName()
        {
            return Name;
        }
        public string GetMiddleName()
        {
            return MiddleName;
        }

    }
}
