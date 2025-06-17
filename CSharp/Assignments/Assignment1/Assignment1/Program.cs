using System;

namespace Assignment1
{
    class Driver
    {
        static void Main(string[] args)
        {
            question1 q1 = new question1();
            q1.Are_Equal();
            Console.ReadLine();
            question2 q2 = new question2();
            q2.Is_Positive();
            Console.ReadLine();
            question3 q3 = new question3();
            q3.Arithmetic_Operations();
            Console.ReadLine();
            question4 q4 = new question4();
            q4.Table();
            Console.ReadLine();
            question5 q5 = new question5();
            q5.Summation();
        }
      
    }
}
