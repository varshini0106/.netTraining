//1.Write a C# Sharp program to accept two integers and check whether they are equal or not. 

//Test Data :
//Input 1st number: 5
//Input 2nd number: 5
//Expected Output :
//5 and 5 are equal

using System;

namespace Assignment1
{
    class question1
    {
        public void Are_Equal()
        {
            int num1, num2;
            Console.WriteLine("Enter first integer");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second integer");
            num2 = Convert.ToInt32(Console.ReadLine());
            string str;
            str = ((num1 == num2) ? ($"{num1} and {num2} are equal") : ($"{num1} and {num2} are not equal"));
            Console.WriteLine(str);
            Console.Read();
        }
    }
}
