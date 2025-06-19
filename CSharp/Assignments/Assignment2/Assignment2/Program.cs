using System;


namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            // question1
            Console.WriteLine("Enter two numbers:");
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Before Swapping first number {0} and second number {1}", num1, num2);
            question1 q1 = new question1();
            q1.swapnumbers(num1, num2);

            //question2
            question2 q2 = new question2();
            q2.display();

            //question3
            question3 q3 = new question3();
            q3.days();

            Console.Read();

        }
    }
    // 1. Write a C# Sharp program to swap two numbers.
    class question1
    {
        public void swapnumbers(int n1, int n2)
        {
            // using XOR (bitwise operator)
            n1 = n1 ^ n2;
            n2 = n1 ^ n2;
            n1 = n1 ^ n2;
            Console.WriteLine("After Swapping first number {0} and second number {1}", n1, n2);

            /*using temp
            int temp;
            temp = n1;
            n1 = n2;
            n2 = temp; */
        }
    }

        //2. Write a C# program that takes a number as input and displays it four times in a row (separated by blank spaces), and then four times in the next row, with no separation. You should do it twice: Use the console. Write and use {0}.

        //Test Data:
        //Enter a digit: 25

        //Expected Output:
        //25 25 25 25
        //25252525
        //25 25 25 25
        //25252525
    class question2
    {
        public void display()
        {
            Console.WriteLine("Enter a number");
            int x = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("{0} {0} {0} {0}", x);
                Console.WriteLine("{0}{0}{0}{0}", x);
            }
        }
    }

    //3. Write a C# Sharp program to read any day number as an integer and display the name of the day as a word.

    //Test Data / input: 2

    //Expected Output :
    //Tuesday

    public enum Days { Monday=1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday}
    class question3
    {
        public void days()
        {
            Console.WriteLine("Enter a number less than 8");
            int x = Convert.ToInt32(Console.ReadLine());
            if (x > 7)
            {
                Console.WriteLine("Invalid Number");
            }
            foreach (int y in Enum.GetValues(typeof(Days)))
            {
                if (y == x)
                {
                    Console.WriteLine(Enum.GetName(typeof(Days), y));
                }
            }
        }
    }
}
