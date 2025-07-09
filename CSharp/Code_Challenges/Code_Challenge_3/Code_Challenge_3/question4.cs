//4.  Write a console program that uses delegate object as an argument to call Calculator Functionalities like 1. Addition, 2. Subtraction and 3. Multiplication by taking 2 integers and returning the output to the user. 
//You should display all the return values accordingly.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_3
{
    public delegate int CalculatorDelegate(int a, int b);
    class question4
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static int Subtract(int x, int y)
        {
            return x - y;
        }

        public static int Multiply(int x, int y)
        {
            return x * y;
        }

        public static void PerformCalculation(int a, int b, CalculatorDelegate operation, string operationName)
        {
            int result = operation(a, b); 
            Console.WriteLine($"{operationName} of {a} and {b} = {result}");
        }

        static void Main(string[] args)
        {            
            Console.Write("Enter first integer: ");
            int i1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nEnter second integer: ");
            int i2 = Convert.ToInt32(Console.ReadLine());

            PerformCalculation(i1, i2, Add, "\nAddition");
            PerformCalculation(i1, i2, Subtract, "\nSubtraction");
            PerformCalculation(i1, i2, Multiply, "\nMultiplication");

            Console.Read();
        }
    }
}
