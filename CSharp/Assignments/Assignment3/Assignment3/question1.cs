//   1. Create a class called Accounts which has data members/fields like Account no, Customer name, Account type, Transaction type (d/w), amount, balance
//   D->Deposit
//   W->Withdrawal
//   -write a function that updates the balance depending upon the transaction type
//   -If transaction type is deposit call the function credit by passing the amount to be deposited and update the balance
//   function Credit(int amount)
//   -If transaction type is withdraw call the function debit by passing the amount to be withdrawn and update the balance
//   Debit(int amt) function
//   -Pass the other information like Account no, customer name, acc type through constructor
//   -write and call the show data method to display the values.


using System;

namespace Assignment3
{

    class Accounts
    {
        int AccountNo;
        string CustomerName, AccountType;
        float amount,balance;
        char TransactionType;

        public Accounts(int AccountNo, string CustomerName, string AccountType, char TransactionType)
        {
            this.AccountNo = AccountNo;
            this.CustomerName = CustomerName;
            this.AccountType = AccountType;
            this.TransactionType = TransactionType;

        }
        public void Credit(float balance)
        {
            Console.WriteLine("Enter the amount to deposit:");
            amount = float.Parse(Console.ReadLine());
            this.balance = balance + amount;
        }

        public void Debit(float balance)
        {
            Console.WriteLine("Enter the amount to withdraw:");
            amount = float.Parse(Console.ReadLine());
            this.balance = balance - amount;
        }

        public void ShowData()
        {
            Console.WriteLine($"Account Number is: {AccountNo}" );
            Console.WriteLine($"Account Type is: {AccountType}");
            Console.WriteLine($"Transaction Type is: {TransactionType}");
            Console.WriteLine($"Balance Amount is: {balance}");
        }


    }

    class question1
    {
        public static void Main()
        {
            Console.WriteLine("Enter the account number :");
            int AccountNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the customer name :");
            string CustomerName = Console.ReadLine();
            Console.WriteLine("Enter the account type :");
            string AccountType = Console.ReadLine();
            Console.WriteLine("Enter account bakance:");
            float balance = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Enter Transaction Type as W for Withdraw or D for Deposit:");
            char TransactionType = char.ToUpper(Convert.ToChar(Console.ReadLine()));
            Accounts account = new Accounts(AccountNo, CustomerName, AccountType, TransactionType); //object creation
            if (TransactionType == 'D')
            {
                account.Credit(balance);
            }
            else
            {
                account.Debit(balance);
            }

            account.ShowData();
            Console.Read();
        }
    }

}