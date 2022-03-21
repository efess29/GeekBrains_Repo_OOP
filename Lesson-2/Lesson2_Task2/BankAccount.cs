using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_Task2
{
    /// <summary>
    /// Представляет класс банковского счета
    /// </summary>
    class BankAccount
    {
        private static Guid _generatedAccountNumber;
        private decimal? _accountBalance;
        private AccountType _accountType;

        /// <summary>
        /// Представляет метод генерации номера счета
        /// </summary>
        /// <returns></returns>
        public string GetGeneratedAccountNumber()
        {
            return _generatedAccountNumber.ToString();
        }

        /// <summary>
        /// Представляет метод получения сгенерированного номера счета
        /// </summary>
        public void SetGeneratedAccountNumber()
        {
            _generatedAccountNumber = Guid.NewGuid();
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
