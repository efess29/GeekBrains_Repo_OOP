using System;

namespace Lesson2_Task1
{
    public class BankAccount
    {
        private string _accountNumber;
        private decimal? _accountBalance;
        private AccType _accountType;

        /// <summary>
        /// 
        /// </summary>
        public string AccountNumber
        {
            get
            {
                return _accountNumber;
            }

            set
            {
                this._accountNumber = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal? AccountBalance
        {
            get
            {
                return _accountBalance;
            }

            set
            {
                this._accountBalance = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public AccType AccountType
        {
            get
            {
                return _accountType;
            }

            set
            {
                this._accountType = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Flags]
        public enum AccType
        {
            Credit = 0,
            Debit = 1
        }
    }
}
