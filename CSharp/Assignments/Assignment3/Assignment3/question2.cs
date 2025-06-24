//2.Create a class called student which has data members like rollno, name, class, Semester, branch, int[] marks = new int marks [5](marks of 5 subjects )

//-Pass the details of student like rollno, name, class, SEM, branch in constructor

//- For marks write a method called GetMarks() and give marks for all 5 subjects

//-Write a method called displayresult, which should calculate the average marks

//-If marks of any one subject is less than 35 print result as failed
//-If marks of all subject is >35, but average is < 50 then also print result as failed
//-If avg > 50 then print result as passed.

//-Write a DisplayData() method to display all object members values.

using System;


namespace Assignment3
{
    class Student
    {
        string rollNo, result;
        int Class;
        string Name, Branch;
        int Semester;
        public int[] marks = new int[5];

        public Student(string rollNo, string Name, int Class, int Semester, string Branch)
        {
            this.rollNo = rollNo;
            this.Name = Name;
            this.Class = Class;
            this.Semester = Semester;
            this.Branch = Branch;

        }
        public void GetMarks()
        {
            for(int m = 0; m<5; m++)
            {
                Console.WriteLine("Enter {0}st subject marks :", m+1);
                marks[m] = Convert.ToInt32(Console.ReadLine());
            }
        }
        public double DisplayResult()
        {
            int sum = 0;
            double avg;
            for (int a = 0; a < 5; a++)
            {
                sum += marks[a];
            }
            avg = sum / 5;
            Console.WriteLine($"Average of marks: {avg}");
            return avg;
        }

        public void Result(int[] marks, double average)
        {
            for(int r = 0; r < 5; r++)
            {
                if(marks[r] < 35)
                {
                    result = "Failed";
                    Console.WriteLine(result);
                    return;
                }
            }
            if(average < 50)
            {
                result = "Failed";
                Console.WriteLine(result);                return;
            }
            else
            {
                result = "Passed";
                Console.WriteLine(result);      
            }
        }

        public void DisplayData()
        {
            Console.WriteLine("------Displaying student details------");
            Console.WriteLine($"Student Roll No: {rollNo}");
            Console.WriteLine($"Student Name: {Name}");
            Console.WriteLine($"Class: {Class}");
            Console.WriteLine($"Semester: {Semester}");
            Console.WriteLine($"Branch: {Branch}");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Subject {0} marks: {1}", i+1, marks[i]);
            }
            Console.WriteLine($"Result: {result}");
        }
    }
    class question2
    {
        public static void Main()
        {
            Console.WriteLine("Enter student roll number :");
            string rollNo = (Console.ReadLine());
            Console.WriteLine("Enter student name :");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter class :");
            int Class = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Semester :");
            int semester = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Branch :");
            string branch = (Console.ReadLine());
            Student s = new Student(rollNo, Name, Class, semester, branch);
            s.GetMarks();            
            double average = s.DisplayResult();
            s.Result(s.marks, average);
            s.DisplayData();
            Console.Read();
        }
    }
}
