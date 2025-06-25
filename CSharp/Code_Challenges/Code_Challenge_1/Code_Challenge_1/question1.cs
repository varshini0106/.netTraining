using System;


namespace Code_Challenge_1
{

    //1. Write a C# Sharp program to remove the character at a given position in the string. The given position will be in the range 0..(string length -1) inclusive.

    //Sample Input:
    //"Python", 1
    //"Python", 0
    //"Python", 4
    //Expected Output:
    //Pthon
    //ython
    //Pythn
    
    class question1
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the string: ");
            string str = Console.ReadLine();

            Console.Write("Enter the position of the character to remove from the string: ");
            if (int.TryParse(Console.ReadLine(), out int position))
            {

                if (position >= 0 && position < str.Length)
                {                    
                    string result = str.Remove(position, 1);
                    Console.WriteLine($"String after changes: {result}");
                }
                else
                {
                    Console.WriteLine("Position is out of range.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for position.");
            }
            Console.ReadLine();
        }
    }
}
