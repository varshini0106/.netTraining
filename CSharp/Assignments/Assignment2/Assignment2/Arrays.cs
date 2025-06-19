using System;


namespace Assignment2
{
    class Arrays
    {
        public static void Main()
        {
            //question4
            question4 q4 = new question4();
            q4.Average_Min_Max();

            //question5
            question5 q5 = new question5();
            q5.Display();

            //question6
            question6 q6 = new question6();
            q6.copy_array();

            Console.Read();
        }
    }

    //Write a  Program to assign integer values to an array  and then print the following
    //a.Average value of Array elements
    //b.Minimum and Maximum value in an array
    class question4
    {
        public void Average_Min_Max()
        {
            //reading elements in to array and averaging
            Console.WriteLine("Enter size of array");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            int sum = 0;
            for (int i = 0; i<n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
                sum += arr[i];
            }
            float avg = sum / n;
            Console.WriteLine("Average is: {0}", avg);

            //min and max of an array
            Array.Sort(arr);
            int min = arr[0];
            int max = arr[n-1];

            Console.WriteLine($"Minimum value: {min}");
            Console.WriteLine($"Maximum value: {max}");
        }
    }

     //Write a program in C# to accept ten marks and display the following
     //a.Total
     //b.Average
     //c.Minimum marks
     //d.Maximum marks
     //e.Display marks in ascending order
     //f.Display marks in descending order
     class question5
     {
        public void Display()
        {
            Console.WriteLine("Enter ten marks:");
            int[] marks = new int[10];
            int sum = 0;
            for(int i = 0; i < 10; i++)
            {
                marks[i] = Convert.ToInt32(Console.ReadLine());
                sum += marks[i];
            }
            Console.WriteLine("Sum of the marks:{0}", sum);
            float avg = sum / 10;
            Console.WriteLine("Average of marks is: {0}", avg);

            //min marks and max marks
            Array.Sort(marks);
            int min = marks[0];
            int max = marks[10 - 1];
            Console.WriteLine($"Minimum value: {min}");
            Console.WriteLine($"Maximum value: {max}");

            //Ascending order
            Console.WriteLine("Ascending order of the marks:");
            foreach(int Marks in marks)
            {
                Console.Write(Marks + " ");
            }

            //Descending order
            Array.Reverse(marks);
            Console.WriteLine();
            Console.WriteLine("Descending order of the marks:");
            foreach (int Marks in marks)
            {
                Console.Write(Marks + " ");
            }
        }
    }

    //Write a C# Sharp program to copy the elements of one array into another array.(do not use any inbuilt functions)
    class question6
    {
        public void copy_array()
        {
            Console.WriteLine("Enter the size of array");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr1 = new int[n];
            Console.WriteLine("Enter array elements");
            for(int i=0; i < n; i++)
            {
                arr1[i] = Convert.ToInt32(Console.ReadLine());
            }
            int[] arr2 = new int[n];
            arr2 = arr1;
            for(int i = 0; i < n; i++)
            {
                //printing copied array
                Console.Write(arr2[i] + " ");
            }
        }
    }
}
