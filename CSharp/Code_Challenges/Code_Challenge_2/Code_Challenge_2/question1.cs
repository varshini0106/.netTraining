//1.Create an Abstract class Student with Name, StudentId, Grade as members and also an abstract method Boolean Ispassed(grade) which takes grade as an input and checks whether student passed the course or not.  
//Create 2 Sub classes Undergraduate and Graduate that inherits all members of the student and overrides Ispassed(grade) method

//For the UnderGrad class, if the grade is above 70.0, then isPassed returns true, otherwise it returns false. For the Grad class, if the grade is above 80.0, then isPassed returns true, otherwise returns false.
//Test the above by creating appropriate objects

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_2
{
    abstract public class Student
    {
        public string Name;
        public string StudentId;
        public Single grade;
        abstract public Boolean IsPassed(Single grade);
    }
    class Undergraduate : Student
    {
        override public Boolean IsPassed(Single grade)
        {
            if (grade > 70.0f)
                return true;
            else
                return false;
        }
    }
    class Graduate : Student
    {
        override public Boolean IsPassed(Single grade)
        {
            if (grade > 80.0f)
                return true;
            else
                return false;
        }
    }
    class question1
    {
        static void Main(string[] args)
        {
            Undergraduate ug = new Undergraduate();
            Graduate g = new Graduate();
            Console.WriteLine("Enter Student Name: ");
            ug.Name = Console.ReadLine();
            Console.WriteLine("Enter Student ID :");
            ug.StudentId = Console.ReadLine();
            Console.WriteLine("Enter grade marks for Under graduate: ");
            ug.grade = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine(ug.IsPassed(ug.grade));
            Console.WriteLine("Enter grade marks for graduate: ");
            Console.WriteLine(g.IsPassed(g.grade));
            bool b = ug.IsPassed(ug.grade);
            Console.Read();
        }
    }
}
