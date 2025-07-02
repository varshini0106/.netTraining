//2.Create a class called Scholarship which has a function Public void Merit() that takes marks and fees as an input. 
//If the given mark is >= 70 and <=80, then calculate scholarship amount as 20% of the fees
//If the given mark is > 80 and <=90, then calculate scholarship amount as 30% of the fees
//If the given mark is >90, then calculate scholarship amount as 50% of the fees.
//In all the cases return the Scholarship amount, else throw an user exception

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class InvalidMarksException : Exception
    {
        public InvalidMarksException(string message) : base(message) { }
    }
    class question2
    {
        
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter marks:");
                int marks = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter fees:");
                float fees = Convert.ToSingle(Console.ReadLine());
                Scholarship s = new Scholarship();
                s.merit(marks, fees);
                Console.WriteLine($"Scholarship amount is: {s.ScholarshipAmount}");
                Console.Read();
            }
            catch (InvalidMarksException e)
            {
                Console.WriteLine("Invalid Marks :" + e.Message);
                Console.Read();
            }
        }
    }
    class Scholarship
    {
        public float ScholarshipAmount;
        public void merit(int marks, float fees)
        {
            if (marks >= 70 && marks <= 80)
                ScholarshipAmount = 0.20f * fees;
            else if (marks <= 90 && marks > 80)
                ScholarshipAmount = 0.30f * fees;
            else if (marks > 90)
                ScholarshipAmount = 0.50f * fees;
            else
                throw new InvalidMarksException("Scholarship not applicable");
        }
    }
}
