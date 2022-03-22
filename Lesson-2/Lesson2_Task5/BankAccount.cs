using System;

namespace Lesson2_Task5
{
    /// <summary>
    /// Представляет класс банковского счета
    /// </summary>
    class BankAccount
    {
        private static Guid _accountNumber;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BankAccount">
        /// </summary>
        public BankAccount(decimal? balance, AccountType type)
        {
            SetGeneratedAccountNumber();
            _accountNumber = GetGeneratedAccountNumber();
            this.AccountBalance = balance; //562310.62m;
            this.AccountKind = type; //(AccountType)1;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BankAccount"> с заполненным балансом
        /// </summary>
        /// <param name="balance"></param>
        public BankAccount(decimal? balance)
        {
            SetGeneratedAccountNumber();
            _accountNumber = GetGeneratedAccountNumber();
            this.AccountBalance = balance;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BankAccount"> с заполненным типом счета
        /// </summary>
        /// <param name="type"></param>
        public BankAccount(AccountType type)
        {
            SetGeneratedAccountNumber();
            _accountNumber = GetGeneratedAccountNumber();
            this.AccountKind = type;
        }

        /// <summary>
        /// Получает или задает номер счета
        /// </summary>
        public Guid AccountNumber
        {
            get
            {
                return _accountNumber;
            }

            set
            {
                SetGeneratedAccountNumber();
            }
        }

        /// <summary>
        /// Получает или задает баланс на счете
        /// </summary>
        public decimal? AccountBalance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AccountType? AccountKind { get; set; }

        /// <summary>
        /// Представляет метод генерации номера счета
        /// </summary>
        /// <returns></returns>
        public Guid GetGeneratedAccountNumber()
        {
            return _accountNumber;
        }

        /// <summary>
        /// Представляет метод получения сгенерированного номера счета
        /// </summary>
        public void SetGeneratedAccountNumber()
        {
            _accountNumber = Guid.NewGuid();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void WithdrawMoney(decimal value)
        {
            try
            {
                if (value <= 0)
                    throw new Exception("Unable to withdraw the specified amount. Enter another amount.");

                var checkAmount = (this.AccountBalance >= value) ? true : false;

                if (checkAmount)
                {
                    this.AccountBalance -= value;
                    Console.WriteLine($"Operation successfull! You withdrawed: {value}.");
                    Console.WriteLine($"Your current account balance: {this.AccountBalance}.");
                }
                    
                else
                {
                    throw new Exception("Unable to withdraw the specified amount. Insufficient funds.");
                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine("Exception information: {0}", e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void DepositMoney(decimal value)
        {
            try
            {
                if (value <= 0)
                    throw new Exception("Unable to deposit the specified amount. Enter another amount.");

                this.AccountBalance += value;
                Console.WriteLine($"Operation successfull! You deposited: {value}.");
                Console.WriteLine($"Your current account balance: {this.AccountBalance}.");
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception information: {0}", e.Message);
            }
        }

        /// <summary>
        /// Представляет перечисление типов счетов
        /// </summary>
        [Flags]
        public enum AccountType
        {
            Credit = 0,
            Debit = 1
        }
    }
}
