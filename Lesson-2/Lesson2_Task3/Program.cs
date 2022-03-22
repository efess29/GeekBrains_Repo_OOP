using System;
using static Lesson2_Task3.BankAccount;

namespace Lesson2_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal? balance = 5553221.12m;
            AccountType type = 0;

            var accountDefault = new BankAccount();
            var account1Balance = new BankAccount(balance);
            var accountType = new BankAccount(type);

        }
    }
}
