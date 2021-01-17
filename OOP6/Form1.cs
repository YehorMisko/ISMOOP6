using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP6
{
    public partial class StudentManager : Form
    {
        StudenList studentlist = new StudenList();
        
        public StudentManager()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            studentlist.Added += Show_Message;
            studentlist.Removed += Show_Message;
            TextBoxName.Enabled = false;
            textBoxSurName.Enabled = false;
            textBoxMiddleName.Enabled = false;
            textBoxGroup.Enabled = false;
            textBoxYear.Enabled = false;
            textBoxGrade.Enabled = false;
            buttonAddStudent.Enabled = false;
            buttonRemove.Enabled = false;
        }
       
        private static void Show_Message(object sender, StudentEventArgs e)
        {
            MessageBox.Show(e.Message);
        }
        private void buttonAddStudent_Click(object sender, EventArgs e)
        {

            if (Regex.IsMatch(textBoxYear.Text, @"^\d+$") == false) MessageBox.Show("Please input a number here");
            else
            if (Regex.IsMatch(textBoxGrade.Text, @"^\d+$") == false) MessageBox.Show("Please input a number here");
            else
            {
                Student student = new Student();
                student.Name = TextBoxName.Text;
                student.Surname = textBoxSurName.Text;
                student.MiddleName = textBoxMiddleName.Text;
                student.Group = textBoxGroup.Text;
                student.Year = Int32.Parse(textBoxYear.Text);
                student.Grade = Int32.Parse(textBoxGrade.Text);
                studentlist.AddStudent(student);
                string[] row = {student.Surname,
            student.MiddleName, student.Group, student.Year.ToString(), student.Grade.ToString()};
                listViewStudents.Items.Add(student.Name).SubItems.AddRange(row);
                TextBoxName.Enabled = false;
                textBoxSurName.Enabled = false;
                textBoxMiddleName.Enabled = false;
                textBoxGroup.Enabled = false;
                textBoxYear.Enabled = false;
                textBoxGrade.Enabled = false;
                buttonAddStudent.Enabled = false;
                buttonStartInput.Enabled = true;
                buttonRemove.Enabled = true;
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {

            
            
            if (listViewStudents.SelectedItems.Count == 1)
            {
                studentlist.DeleteStudent(listViewStudents.SelectedIndices[0]);
                listViewStudents.Items.RemoveAt(listViewStudents.SelectedIndices[0]);

                if (studentlist.IsEmpty() == true)
                    buttonRemove.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please select a student to Remove");
            }
        }

        private void buttonStartInput_Click(object sender, EventArgs e)
        {
            buttonAddStudent.Enabled = true;
            TextBoxName.Enabled = true;
            textBoxSurName.Enabled = true;
            textBoxMiddleName.Enabled = true;
            textBoxGroup.Enabled = true;
            textBoxYear.Enabled = true;
            textBoxGrade.Enabled = true;
            buttonStartInput.Enabled = false;
        }
    }
}
