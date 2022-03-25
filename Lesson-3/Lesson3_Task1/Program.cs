using System;
using static Lesson3_Task1.BankAccount;

namespace Lesson3_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var accountSource = new BankAccount()
                {
                    AccountBalance = 10000.50m,
                    AccountKind = (AccountType)1
                };

                var accountTarget = new BankAccount()
                {
                    AccountBalance = 50000.25m,
                    AccountKind = (AccountType)0
                };

                Console.WriteLine("================================");
                Console.WriteLine("Welcome to BANK ACCOUNT MANAGER!");
                Console.WriteLine("================================");
                Console.WriteLine();

                Console.WriteLine("Your bank account info: ");
                Console.WriteLine("================================");
                Console.WriteLine($"Account number: {accountSource.AccountNumber}");
                Console.WriteLine($"Account balance: {accountSource.AccountBalance}");
                Console.WriteLine($"Account type: {accountSource.AccountKind}");
                Console.WriteLine("================================");
                Console.WriteLine();

                Console.WriteLine("Destination bank account info: ");
                Console.WriteLine("================================");
                Console.WriteLine($"Account number: {accountTarget.AccountNumber}");
                Console.WriteLine($"Account balance: {accountTarget.AccountBalance}");
                Console.WriteLine($"Account type: {accountTarget.AccountKind}");
                Console.WriteLine("================================");
                Console.WriteLine();

                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Withdraw amount");
                Console.WriteLine("2. Deposit amount");
                Console.WriteLine("3. Transfer amount");
                Console.WriteLine("4. Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Enter amount you want to withdraw: ");
                        var amountWithdraw = Decimal.Parse(Console.ReadLine());
                        accountSource.WithdrawMoney(amountWithdraw);

                        break;
                    case "2":
                        Console.Write("Enter amount you want to deposit: ");
                        var amountDeposit = Decimal.Parse(Console.ReadLine());
                        accountSource.DepositMoney(amountDeposit);

                        break;
                    case "3":
                        Console.Write("Enter amount you want to transfer: ");
                        var amountTransfer = Decimal.Parse(Console.ReadLine());
                        accountTarget.TransferMoney(ref accountSource, amountTransfer);
                        break;
                    case "4":
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
