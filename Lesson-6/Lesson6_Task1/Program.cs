using System;
using static Lesson6_Task1.BankAccount;

namespace Lesson6_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var accountA = new BankAccount()
            {
                AccountBalance = 50000.25m,
                AccountKind = (AccountType)0
            };

            var accountB = new BankAccount()
            {
                AccountBalance = 10000.50m,
                AccountKind = (AccountType)1
            };

            var s = accountA.ToString();
            var hashA = accountA.GetHashCode();
            var equals = accountB.Equals(accountA);
            var comparsionA = (accountB == accountA);
            var comparsionB = (accountB != accountA);
            var hashB = accountB.GetHashCode();
        }
    }
}
