using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    //2. Operator Overloading
    //Scenario:
    //You are creating a Box class that has a Length property.The team wants to be able to "add" two boxes by summing their lengths.
    //Question:
    //Create a simple Box class and overload the + operator so that adding two boxes returns a new box with the combined length.
    class question2
    {
        public static void Main()
        {
            Console.WriteLine("Enter the length of the box 1:");
            Box b1 = new Box();
            b1.length = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Enter the length of the box 2:");
            Box b2 = new Box();
            b2.length = Convert.ToSingle(Console.ReadLine());
            float b3 = b1 + b2;
            Console.WriteLine($"The new box length is : {b3}");
            Console.Read();
        }
    }
    class Box
    {
        public float length;
        public static float operator +(Box b1, Box b2)
        {
            return (b1.length + b2.length);
        }
    }
}

