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
            protected set
            {
                if (value <=0)
                    throw new ArgumentException("Номер счета должен быть положительным");
                AccountNumber = value;
            }
        }
        
        public string owner
        {
            get => Owner;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Имя владельца не может быть пустым");
                Owner = value;
            }

        }
        public decimal balance
        {
            get => Balance;
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Баланс не может быть отрицательным");
                Balance = value;
            }
        }

        protected BankAccount(int accountNumber, string owner, decimal balance)
        {
            this.accountNumber = accountNumber;
            this.owner = owner;
            this.balance = balance;
          
        }

        public virtual void Deposit(decimal sum)
        {
            if (sum <= 0)
                throw new ArgumentException("Сумма пополнени должна быть положительной.");
            sum += balance;
            
        }

        public virtual void Withdraw(decimal sum)
        {
            if (sum <= 0)
                throw new Exception("Сумма должна быть положительной");

            if (sum > balance)
                throw new Exception("Недостаточно средств");

            balance -= sum;
        }

        public abstract void DisplayInfo();
           
        



        
       

    }
}
