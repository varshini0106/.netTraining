//5.Write a C# program to compute the sum of two given integers. If two values are the same, return the triple of their sum.

using System;

namespace Assignment1
{
    class question5
    {
        public void Summation()
        {
            int num1, num2;
            Console.WriteLine("Enter first integer");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second integer");
            num2 = Convert.ToInt32(Console.ReadLine());
            if (num1 == num2)
                Console.WriteLine(6 * num1);
            else
                Console.WriteLine(num1 + num2);
            Console.Read();
        }
    }
}
