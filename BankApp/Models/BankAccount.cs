using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public abstract class BankAccount
    {
        private int AccountNumber;
        private string Owner;
        private decimal Balance;

        public int accountNumber
        {
            get => AccountNumber;
            private set
            {
                if (value <=0)
                    throw new ArgumentException("Номер счета должен быть положительным");
                AccountNumber = value;
            }
        }
        
        public string owner
        {
            get => Owner;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Имя владельца не может быть пустым");
                Owner = value;
            }

        }
        public decimal balance
        {
            get => Balance;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Баланс не может быть отрицательным");
                balance = value;
            }
        }

        public BankAccount(int  accountNumber,string owner,decimal balance)
        {
            AccountNumber = accountNumber;
            Owner = owner;
            Balance = balance;
        }

        public abstract void DisplayInfo();
           
        



        
       

    }
}
