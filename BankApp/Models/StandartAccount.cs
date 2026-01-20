using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class StandartAccount : BankAccount
    {
        public StandartAccount(int accountNumber, string owner, decimal balance) 
            : base(accountNumber, owner, balance)
        {

        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Счет:{accountNumber},Владелец:{owner},Баланс:{balance}");
        }
    }
}
