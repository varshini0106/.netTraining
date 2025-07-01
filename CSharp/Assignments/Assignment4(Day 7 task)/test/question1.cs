
using System;


namespace test
{
//Scenario:
//A company is developing a billing system.A developer is asked to calculate the total cost of 5 items, each priced at ₹200, and then apply a 10% discount.
//Question:
//Write a simple C# code snippet using arithmetic operators to:
//Calculate the total price
//Apply the 10% discount
//Print the final amount to be paid
    class question1
    {
        public void Amount()
        {
            Console.WriteLine("Enter the number of items :");
            int noofItems = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the price per item:");
            int price = Convert.ToInt32(Console.ReadLine());
            int TotalPrice = noofItems * price;
            Console.WriteLine("Total Price is : " + TotalPrice);
            double finalAmount = TotalPrice - (0.1 * TotalPrice);
            Console.WriteLine($"Total price after discount is : {finalAmount} ");
            Console.Read();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            question1 q1 = new question1();
            q1.Amount();

            Console.Read();
        }
    }
}
