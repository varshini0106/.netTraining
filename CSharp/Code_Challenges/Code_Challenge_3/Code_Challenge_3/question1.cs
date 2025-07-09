//1. Write a program to find the Sum and the Average points scored by the teams in the IPL. 
//Create a Class called CricketTeam that has a function called Pointscalculation(int no_of_matches) that takes no.of matches as input and accepts that many scores from the user. 
//The function should then return the Count of Matches, Average and Sum of the scores.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_3
{
    class CricketTeam
    {
        public void Pointscalculation(int no_of_matches)
        {
            int[] scores = new int[no_of_matches];
            int sum = 0;

            for (int i = 0; i < no_of_matches; i++)
            {
                Console.Write($"Enter the score for Match {i + 1}: ");
                scores[i] = Convert.ToInt32(Console.ReadLine());
                sum += scores[i];
            }

            double average = (double)sum / no_of_matches;

            Console.WriteLine($"\nCount of matches played    : {no_of_matches}");
            Console.WriteLine($"\nSum of the scores          : {sum}");
            Console.WriteLine($"\nAverage of all the scores  : {average}");
        }
    }
    
    class question1
    {
        static void Main(string[] args)
        {
            CricketTeam team = new CricketTeam();

            Console.Write("Enter the number of matches: ");
            int matches = Convert.ToInt32(Console.ReadLine());
            
            team.Pointscalculation(matches);

            Console.Read();
        }
    }
}
