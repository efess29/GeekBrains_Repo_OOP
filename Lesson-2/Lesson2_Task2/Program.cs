using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lesson2_Task2.BankAccount;

namespace Lesson2_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount();

            account.SetAccountBalance();
            account.SetAccountType();
            account.SetGeneratedAccountNumber();

            string number = account.GetGeneratedAccountNumber();
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
