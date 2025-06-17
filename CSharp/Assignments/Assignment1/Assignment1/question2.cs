//2.Write a C# Sharp program to check whether a given number is positive or negative. 

//Test Data : 14
//Expected Output :
//14 is a positive number

using System;

namespace Assignment1
{
    class question2
    {
        public void Is_Positive()
        {
            Console.WriteLine("Enter a number");
            int num = int.Parse(Console.ReadLine());
            string s;
            s = (num >= 0) ? ($"{num} is positive") : ($"{num} is negative");
            Console.WriteLine(s);
            Console.Read();
        }
    }
}
