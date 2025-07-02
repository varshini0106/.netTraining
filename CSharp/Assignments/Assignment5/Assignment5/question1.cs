//Exception Handling :  
//1.
//•	You have a class which has methods for transaction for a banking system. (created earlier)
//•	Define your own methods for deposit money, withdraw money and balance in the account.
//•	Write your own new application Exception class called InsuffientBalanceException.
//•	This new Exception will be thrown in case of withdrawal of money from the account where customer doesn’t have sufficient balance.
//•	Identify and categorize all possible checked and unchecked exception.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }
    class Accounts
    {
        int AccountNo;
        string CustomerName, AccountType;
        float amount, balance;
        char TransactionType;

        public Accounts(int AccountNo, string CustomerName, string AccountType, float initialBalance, char TransactionType)
        {
            this.AccountNo = AccountNo;
            this.CustomerName = CustomerName;
            this.AccountType = AccountType;
            balance = initialBalance;
            this.TransactionType = TransactionType;

        }
        public void Deposit()
        {
            Console.WriteLine("Enter the amount to deposit:");
            amount = float.Parse(Console.ReadLine());
            if(amount<0) 
                throw new ArgumentException("Cannot deposite negative amount");
            this.balance = balance + amount;
            Console.WriteLine($"{amount} deposited successfully!");
        }

        public void Withdraw()
        {
            Console.WriteLine("Enter the amount to withdraw:");
            amount = float.Parse(Console.ReadLine());
            if (amount < 0)
                throw new ArgumentException("Cannot withdraw negative amount");
            if (amount > balance)
                throw new InsufficientBalanceException("Insufficient Balance!!");
            this.balance = balance - amount;
            Console.WriteLine($"{amount} withdrawn successfully!");
        }

        public void ShowData()
        {
            Console.WriteLine($"Account Number is: {AccountNo}");
            Console.WriteLine($"Account Type is: {AccountType}");
            Console.WriteLine($"Transaction Type is: {TransactionType}");
            Console.WriteLine($"Balance Amount is: {balance}");
        }


    }

    class question1
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine("Enter the account number :");
                int AccountNo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the customer name :");
                string CustomerName = Console.ReadLine();

                Console.WriteLine("Enter the account type :");
                string AccountType = Console.ReadLine();

                Console.Write("Enter account balance: ");
                float initialBalance = Convert.ToSingle(Console.ReadLine());

                Console.WriteLine("Enter Transaction Type as W for Withdraw or D for Deposit:");
                char TransactionType = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                Accounts account = new Accounts(AccountNo, CustomerName, AccountType, initialBalance, TransactionType); //object creation
                if (TransactionType == 'D')
                {
                    account.Deposit();
                }
                else if(TransactionType == 'W')
                {
                    account.Withdraw();
                }
                else
                {
                    Console.WriteLine("Invalid Transaction");
                }

                account.ShowData();
                Console.Read();
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                Console.Read();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
                Console.Read();
            }
        }
    }
}
