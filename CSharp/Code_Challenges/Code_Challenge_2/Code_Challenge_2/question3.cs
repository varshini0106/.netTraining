//3.Write a C# program to implement a method that takes an integer as input and throws an exception if the number is negative. Handle the exception in the calling code.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_2
{
    class question3
    {
        static void CheckForNegative(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Negative numbers are not allowed.");
            }
        }
        static void Main()
        {
            try
            {
                Console.Write("Enter an integer: ");
                int userInput = int.Parse(Console.ReadLine());
                CheckForNegative(userInput);
                Console.WriteLine("The number is valid.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid integer.");
            }

            Console.Read();
        }
    }
}
