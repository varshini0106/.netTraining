//2. Write a program in C# Sharp to create a file and write an array of strings to the file.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment6
{
    class question2
    {
        static void Main()
        {
            string[] data =
            {
                "Hello!",
                "This is assignment 6",
                "Question 2",
                "Writing an array of strings to the file example",
                "End of the file."
            };

            string filepath = "assign6_q2_file.txt";

            try
            {
                File.WriteAllLines(filepath, data);
                Console.WriteLine("File written Successfully \n");

                string[] fileData = File.ReadAllLines(filepath);

                Console.WriteLine("Reading data from the file {0}: " , filepath);
                foreach(string s in fileData)
                {
                    Console.WriteLine(s);
                }
            }

            catch(Exception e)
            {
                Console.WriteLine("Error writing to file: " + e.Message);
            }

            Console.Read();
        }
    }
}
