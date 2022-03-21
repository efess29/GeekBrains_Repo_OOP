using System;
using static Lesson2_Task1.BankAccount;

namespace Lesson2_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount();
            account.AccountNumber = "1232-ZZ-4300";
            account.AccountBalance = 342009.432m;
            account.AccountType = (AccType)1;

            Console.WriteLine("BANK ACCOUNT INFO");
            Console.WriteLine("=============================");
            Console.WriteLine($"Account number: {account.AccountNumber}");
            Console.WriteLine($"Account balance: {account.AccountBalance}");
            Console.WriteLine($"Account type: {account.AccountType}");

            Console.ReadLine();
        }
    }
}
