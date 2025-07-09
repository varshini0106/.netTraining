//3. Write a program in C# Sharp to append some text to an existing file.
//If file is not available, then create one in the same workspace.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Code_Challenge_3
{
    class question3
    {
        static void Main()
        {
            string filepath = "cc3_q3_textfile.txt";
            Console.WriteLine("Enter text to append");
            string text = Console.ReadLine();
            StreamWriter writetext = new StreamWriter(filepath, true);
            writetext.WriteLine(text);
            Console.WriteLine("Text appended successfully!!");
            writetext.Close();

            Console.Read();
        }
    }
}
