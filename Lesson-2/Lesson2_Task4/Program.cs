using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lesson2_Task4.BankAccount;

namespace Lesson2_Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var balance = 765321.35m;
            var type = (AccountType)0;

            var accountDefault = new BankAccount();
            var accountBalance = new BankAccount(balance);
            var accountType = new BankAccount(type);

            Console.WriteLine("DEFAULT BANK ACCOUNT INFO");
            Console.WriteLine("==========================================");
            Console.WriteLine($"Account number: {accountDefault.AccountNumber}");
            Console.WriteLine($"Account balance: {accountDefault.AccountBalance}");
            Console.WriteLine($"Account balance: {accountDefault.AccountKind}");

            Console.WriteLine("\n\n");

            Console.WriteLine("BANK ACCOUNT INFO (WITH GENERATED BALANCE)");
            Console.WriteLine("==========================================");
            Console.WriteLine($"Account number: {accountBalance.AccountNumber}");
            Console.WriteLine($"Account balance: {accountBalance.AccountBalance}");
            Console.WriteLine($"Account balance: {accountBalance.AccountKind}");

            Console.WriteLine("\n\n");

            Console.WriteLine("BANK ACCOUNT INFO (WITH GENERATED TYPE)");
            Console.WriteLine("==========================================");
            Console.WriteLine($"Account number: {accountType.AccountNumber}");
            Console.WriteLine($"Account balance: {accountType.AccountBalance}");
            Console.WriteLine($"Account balance: {accountType.AccountKind}");

            Console.ReadLine();
        }
    }
}
