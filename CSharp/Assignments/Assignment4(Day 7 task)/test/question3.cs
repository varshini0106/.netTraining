using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6CSharp
{
    //3.Scenario:
    //You are building a leaderboard and want to compare player scores.
    //Question:
    //Write a class Player with a Score property and implement a method that:
    //Compares two Player objects using ==
    //Uses.Equals()
    //Uses.CompareTo() for sorting logic
    //Explain what each comparison is checking.
    class question3
    {
        public static void Main()
        {
            Player player1 = new Player();
            Console.WriteLine("Enter player1 score :");
            player1.Score = Convert.ToInt32(Console.ReadLine());
            Player player2 = new Player();
            Console.WriteLine("Enter Player2 score:");
            player2.Score = Convert.ToInt32(Console.ReadLine());
            Player.IsEqual(player1, player2);
            player1.sort(player1.Score, player2.Score);
            Console.Read();
        }
    }
    class Player
    {
        public int Score { get; set; }
        public static void IsEqual(Player score1, Player score2)
        {
            Console.WriteLine(score1 == score2); //using ==
            Console.WriteLine(score1.Equals(score2)); //using equals
        }
        public void sort(int score1, int score2)
        {
            if (score1.CompareTo(score2) > 0)
                Console.WriteLine("Player 1 scored more runs when compared");
            else if (score2.CompareTo(score1) > 0)
                Console.WriteLine("Player 2 scored more runs when compared");
        }

    }
}
