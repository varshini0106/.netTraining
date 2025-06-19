using System;


namespace Assignment2
{
    class Strings
    {
        public static void Main()
        {
            //question7
            question7 q7 = new question7();
            q7.stringLength();

            //question8
            question8 q8 = new question8();
            q8.stringReverse();

            //question9
            question9 q9 = new question9();
            q9.stringSimilarity();

            Console.Read();
        }
    }

    //Write a program in C# to accept a word from the user and display the length of it.
    class question7
    {
        public void stringLength()
        {
            Console.WriteLine("Enter a string:");
            string str = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Length of the String is: {0} ", str.Length);
        }
    }

    //Write a program in C# to accept a word from the user and display the reverse of it. 
    class question8
    {
        public void stringReverse()
        {
            Console.WriteLine("Enter a string:");
            string str = Convert.ToString(Console.ReadLine());
            char[] stringArray = str.ToCharArray();
            Array.Reverse(stringArray);
            string reverseString = new string(stringArray);
            Console.WriteLine("Reverse of the String is: {0}", reverseString);
        }
    }

    //Write a program in C# to accept two words from user and find out if they are same. 
    class question9
    {
        public void stringSimilarity()
        {
            Console.WriteLine("Enter first string:");
            string str1 = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter second string:");
            string str2 = Convert.ToString(Console.ReadLine());
            if (str1.Length == str2.Length)
            {
                string s1 = str1.ToLower();
                string s2 = str2.ToLower();
                if(s1 == s2)
                    Console.WriteLine("Same");
                else
                    Console.WriteLine("Not Same");
            }
            else
            {
                Console.WriteLine("Not Same");
            }
        }
    }
}
