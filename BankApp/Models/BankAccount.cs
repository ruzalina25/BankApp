using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class BankAccount
    {
        public int AccountNumber;
        public string Owner;
        public decimal Balance;
        
        public BankAccount(int accountNumber, string owner, decimal balance)
        {
            AccountNumber = accountNumber;
            Owner = owner;
            Balance= balance;

        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Cчет:{AccountNumber},Владелец:{Owner},Баланс:{Balance}");
        }

    }
}
