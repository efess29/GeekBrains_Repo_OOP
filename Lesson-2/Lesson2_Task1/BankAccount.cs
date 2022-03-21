using System;

namespace Lesson2_Task1
{
    /// <summary>
    /// Представляет класс банковского счета
    /// </summary>
    class BankAccount
    {
        private string _accountNumber;
        private decimal? _accountBalance;
        private AccountType _accountType;

        /// <summary>
        /// Представляет метод получения номера счета
        /// </summary>
        /// <returns></returns>
        public string GetAccountNumber()
        {
            return _accountNumber;
        }

        /// <summary>
        /// Представляет метод заполнения номера счета
        /// </summary>
        public void SetAccountNumber()
        {
            _accountNumber = "44/VBSD-09092";
        }

        /// <summary>
        /// Представляет метод получения баланса
        /// </summary>
        /// <returns></returns>
        public decimal? GetAccountBalance()
        {
            return _accountBalance;
        }

        /// <summary>
        /// Представляет метод заполнения баланса
        /// </summary>
        public void SetAccountBalance()
        {
            _accountBalance = 455532.19m;
        }

        /// <summary>
        /// Представляет метод получения типа счета
        /// </summary>
        /// <returns></returns>
        public AccountType GetAccountType()
        {
            return _accountType;
        }

        /// <summary>
        /// Представляет метод заполнения типа счета
        /// </summary>
        public void SetAccountType()
        {
            _accountType = (AccountType)1;
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
