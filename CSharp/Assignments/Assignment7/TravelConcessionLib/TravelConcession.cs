﻿//4.Create a class library with a function CalculateConcession()  that takes age as an input and calculates concession for travel as below:
//If age <= 5 then “Little Champs - Free Ticket” should be displayed
//If age > 60 then calculate 30% concession on the totalfare(Which is a constant Eg:500 / -) and Display “ Senior Citizen” + Calculated Fare
//Else “Print Ticket Booked” + Fare. 
//Create a Console application with a Class called Program which has TotalFare as Constant, Name, Age.  Accept Name, Age from the user and call the CalculateConcession() function to test the Classlibrary functionality

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelConcessionLib
{
    public class TravelConcession
    {
        public void CalculateConcession(string name, int age, double totalFare)
        {
            if (age <= 5)
            {
                Console.WriteLine($"{name}: Little Champ - Free Ticket");
            }
            else if (age > 60)
            {
                double discountedFare = totalFare - (totalFare * 0.30); // 30% discount
                Console.WriteLine($"{name}: Senior Citizen - Fare after 30% concession: {discountedFare}");
            }
            else
            {
                Console.WriteLine($"{name}: Ticket Booked - Fare: {totalFare}");
            }
        }
    }
}
