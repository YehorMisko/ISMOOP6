using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP6
{
    class StudentEventArgs : EventArgs
    {
        public string Message { get; }
        public int Grade { get; }
        public StudentEventArgs(string mes, int grade)
        {
            Message = mes;
            Grade = grade;
        }
    }
}
