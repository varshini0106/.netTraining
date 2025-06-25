using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_1
{
    //3. Write a C# Sharp program to check the largest number among three given integers.
 
    //Sample Input:
    //1,2,3
    //1,3,2
    //1,1,1
    //1,2,2
    //Expected Output:
    //3
    //3
    //1
    //2
    class question3
    {
        static void Main()
        {
            int a, b, c;
            Console.WriteLine("Enter three integers:");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            c = Convert.ToInt32(Console.ReadLine());

            if(a == b && a == c)
            {
                Console.WriteLine($"The largest integer is: {a}");
            }
            else
            {
                if (a > b && a > c)
                {
                    Console.WriteLine($"The largest integer is: {a}");
                }
                else if (b > c)
                {
                    Console.WriteLine($"The largest integer is: {b}");
                }
                else
                {
                    Console.WriteLine($"The largest integer is: {c}");
                }
            }
            Console.Read();
        }
    }
}
