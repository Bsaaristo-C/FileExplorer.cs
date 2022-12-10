using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SaarstoAsg11.Form1;
using static System.Net.Mime.MediaTypeNames;

namespace SaarstoAsg11
{
    public partial class Form1 : Form
    {
        // Create a stack to store the student data
        Stack<Course> Courses = new Stack<Course>();
        Stack<Course> CoursesNext = new Stack<Course>();
        public Form1()
        {
            InitializeComponent();
            Course newCourse = new Course();

            newCourse = new Course(10152100, "Database Concepts and SQL", 3, "NA");
            Courses.Push(newCourse);
            newCourse = new Course(10152101, "Web Design and Development", 3, "NA");
            Courses.Push(newCourse);
            newCourse = new Course(10152102, "Advanced Web Site Development", 3, "NA");
            Courses.Push(newCourse);
            newCourse = new Course(10152106, "Java Programming - Beginning", 3, "NA");
            Courses.Push(newCourse);
            newCourse = new Course(10152107, "Java Programming - Advanced", 2, "NA");
            Courses.Push(newCourse);
            newCourse = new Course(10152108, "Enterprise Java Programming", 2, "NA");
            Courses.Push(newCourse);
            newCourse = new Course(10152110, "Programming in SQL", 3, "NA");
            Courses.Push(newCourse);
            newCourse = new Course(10152111, "Systems Analysis and Design", 3, "NA");
            Courses.Push(newCourse);
            newCourse = new Course(10152112, "Server - Side Web Development", 3, "NA");
            Courses.Push(newCourse);
            newCourse = new Course(10152113, "Applications Development", 3, "NA");
            Courses.Push(newCourse);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int number = 0;
            string name = "" ;
            double gpa = 0.0;
            string grade = "";
            Course newCourse = new Course();



            try
            { 
            // Get the student data from the user
            number = int.Parse(textBoxNumber.Text);
                }
            catch (Exception) {
                textBoxNumber.Text = "Enter valid input";
                    }
            /////////////////////////////////////////////////////////////
            try { 
            name = textBoxName.Text;
                }
            catch (Exception) { 
                textBoxName.Text = "Enter valid input";
                }
            /////////////////////////////////////////////////////////////
            try { 
            gpa = double.Parse(textBoxCredits.Text);
                }
            catch (Exception)
            {
                textBoxCredits.Text = "Enter a valid input";
            }
            /////////////////////////////////////////////////////////////
            try { 
            grade = textBoxGrade.Text;               
                }
            catch (Exception)
            {
                textBoxGrade.Text = "Enter a valid input";
            }
            if (textBoxGrade.Text == "")
                textBoxGrade.Text = "Enter a valid input";
            if (textBoxName.Text == "")
                textBoxName.Text = "Enter a valid input";


            // Create a new Student structure with the input data
            newCourse = new Course(number, name, gpa, grade);

            // Push the student onto the stack
            Courses.Push(newCourse);


        }
        public struct Course
        {
            public int number;
            public string name;
            public double gpa;
            public string grade;

            // Constructor that takes four parameters
            public Course(int number, string name, double gpa, string grade)
            {
                this.number = number;
                this.name = name;
                this.gpa = gpa;
                this.grade = grade;
            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {

           if (Courses.Count > 0)
    {
        // Use the Peek() method to get the top item in the stack
        Course top = Courses.Peek();

        // Print the previous item in the stack
        textBoxNumber.Text = Courses.Peek().number.ToString();
        textBoxName.Text = Courses.Peek().name;
        textBoxCredits.Text = Courses.Peek().gpa.ToString();
        textBoxGrade.Text = Courses.Peek().grade;

        // Push the top item back onto the stack
        CoursesNext.Push(top);

        // Use the Pop() method to remove the top item from the stack
        Courses.Pop();
    }

        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
           if (CoursesNext.Count > 0)
    {
        // Print the next item in the stack
        textBoxNumber.Text = CoursesNext.Peek().number.ToString();
        textBoxName.Text = CoursesNext.Peek().name;
        textBoxCredits.Text = CoursesNext.Peek().gpa.ToString();
        textBoxGrade.Text = CoursesNext.Peek().grade;

        // Push the top item from the CoursesNext stack onto the Courses stack
        Courses.Push(CoursesNext.Peek());

        // Use the Pop() method to remove the top item from the CoursesNext stack
        CoursesNext.Pop();
    }


        }
    }
}

