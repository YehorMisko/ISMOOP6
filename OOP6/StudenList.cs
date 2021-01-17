using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP6
{
    class StudenList
    {
        public delegate void StudentListHandler(object sender, StudentEventArgs e);
        public event StudentListHandler Added;
        public event StudentListHandler Removed;
        protected List<Student> Students;
        public StudenList()
        {
        Students = new List<Student>();
        }
        public void AddStudent(Student student)
        {
            Students.Add(student);
            if (Added != null && student.Grade < 60)
            {
                Added(this, new StudentEventArgs(
                    $"You have enrolled a substandard student, whose score is " +
                    $"{student.Grade}", student.Grade));
            }
            else
            if(Added != null && student.Grade >= 90)
            {
                Added(this, new StudentEventArgs(
                    $"You have enrolled an excellent student, whose score is " +
                    $"{student.Grade}", student.Grade));
            }
            else
            if(Added != null)
            {
                Added(this, new StudentEventArgs(
                    $"You have enrolled a student, whose score is " +
                    $"{student.Grade}", student.Grade));
            }
        }
        public void DeleteStudent(int a)
        {
            if (Removed != null && Students[a].Grade < 60)
            {
                Removed(this, new StudentEventArgs(
                    $"You have expelled a substandard student, whose score was " +
                    $"{Students[a].Grade}", Students[a].Grade));
            }
            else
            if (Removed != null && Students[a].Grade >= 90)
            {
                Removed(this, new StudentEventArgs(
                    $"You have expelled an excellent student, whose score was " +
                    $"{Students[a].Grade}", Students[a].Grade));
            }
            else
            if (Removed != null)
            {
                Removed(this, new StudentEventArgs(
                    $"You have expelled a student, whose score was " +
                    $"{Students[a].Grade}", Students[a].Grade));
            }
            Students.RemoveAt(a);
           
        }
        public bool IsEmpty()
        {
            if (Students.Count == 0) return true;
            else
                return false;
        }
    }
}
