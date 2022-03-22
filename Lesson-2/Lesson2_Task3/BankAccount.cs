using System;

namespace Lesson2_Task3
{
    /// <summary>
    /// 
    /// </summary>
    class BankAccount
    {
        private static Guid _generatedAccountNumber;
        private decimal? _accountBalance;
        private AccountType? _accountType;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BankAccount">
        /// </summary>
        public BankAccount()
        {
            SetGeneratedAccountNumber();
            _generatedAccountNumber = GetGeneratedAccountNumber();
            _accountBalance = 415543.62m;
            _accountType = (AccountType)1;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BankAccount"> с заполненным балансом
        /// </summary>
        /// <param name="balance"></param>
        public BankAccount(decimal? balance)
        {
            SetGeneratedAccountNumber();
            _generatedAccountNumber = GetGeneratedAccountNumber();
            this._accountBalance = balance;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BankAccount"> с заполненным типом счета
        /// </summary>
        /// <param name="type"></param>
        public BankAccount(AccountType type)
        {
            SetGeneratedAccountNumber();
            _generatedAccountNumber = GetGeneratedAccountNumber();
            this._accountType = type;
        }

        /// <summary>
        /// Представляет метод генерации номера счета
        /// </summary>
        /// <returns></returns>
        public Guid GetGeneratedAccountNumber()
        {
            return _generatedAccountNumber;
        }

        /// <summary>
        /// Представляет метод получения сгенерированного номера счета
        /// </summary>
        public void SetGeneratedAccountNumber()
        {
            _generatedAccountNumber = Guid.NewGuid();
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
