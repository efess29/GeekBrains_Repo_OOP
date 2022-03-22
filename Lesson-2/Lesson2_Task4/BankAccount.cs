using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_Task4
{
    class BankAccount
    {
        private static Guid _accountNumber;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BankAccount">
        /// </summary>
        public BankAccount()
        {
            SetGeneratedAccountNumber();
            _accountNumber = GetGeneratedAccountNumber();
            this.AccountBalance = 562310.62m;
            this.AccountKind = (AccountType)1;
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
