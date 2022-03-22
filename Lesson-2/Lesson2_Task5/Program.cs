using System;
using static Lesson2_Task5.BankAccount;

namespace Lesson2_Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("================================");
                Console.WriteLine("Welcome to BANK ACCOUNT MANAGER!");
                Console.WriteLine("================================");
                Console.WriteLine();

                Console.WriteLine("Please, enter your bank account params - balance and type.");
                Console.Write("Account balance: ");
                var balance = Decimal.Parse(Console.ReadLine());
                Console.Write("Account type (0 - Credit, 1 - Debit): ");
                var type = (AccountType)Int32.Parse(Console.ReadLine());

                var accountDefault = new BankAccount(balance, type);

                Console.WriteLine();
                Console.WriteLine("Your bank account info: ");
                Console.WriteLine("================================");
                Console.WriteLine($"Account number: {accountDefault.AccountNumber}");
                Console.WriteLine($"Account balance: {accountDefault.AccountBalance}");
                Console.WriteLine($"Account type: {accountDefault.AccountKind}");
                Console.WriteLine("================================");

                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Withdraw amount");
                Console.WriteLine("2. Deposit amount");
                Console.WriteLine("3. Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Enter amount you want to withdraw: ");
                        var amountWithdraw = Decimal.Parse(Console.ReadLine());
                        accountDefault.WithdrawMoney(amountWithdraw);

                        break;
                    case "2":
                        Console.Write("Enter amount you want to deposit: ");
                        var amountDeposit = Decimal.Parse(Console.ReadLine());
                        accountDefault.DepositMoney(amountDeposit);

                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Enter valid option!");
                        break;
                }

                Console.ReadLine();
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception information: {0}", e.Message);
                Console.ReadLine();
            }
        }
    }
}
