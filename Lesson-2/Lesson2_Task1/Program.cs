using System;
using static Lesson2_Task1.BankAccount;

namespace Lesson2_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount();

            account.SetAccountNumber();
            account.SetAccountBalance();
            account.SetAccountType();
            string number = account.GetAccountNumber();
            decimal? balance = account.GetAccountBalance();
            AccountType type = account.GetAccountType();

            Console.WriteLine("BANK ACCOUNT INFO");
            Console.WriteLine("=====================");
            Console.WriteLine($"Account number: {number}");
            Console.WriteLine($"Account balance: {balance}");
            Console.WriteLine($"Account balance: {type}");

            Console.ReadLine();
        }
    }
}
