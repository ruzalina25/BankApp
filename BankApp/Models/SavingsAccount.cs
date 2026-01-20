using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class SavingsAccount : BankAccount
    {
        private readonly decimal Procent;
        public SavingsAccount(int accountNumber,string owner,decimal balance,decimal procent)
            :base(accountNumber, owner, balance)
        {
            if (procent <= 0)
                throw new ArgumentException("Процентная ставка должна быть положительной");
            Procent = procent;
        }

        public override void DisplayInfo()
        {
            decimal calc = balance + (balance * Procent / 100);
            Console.WriteLine($"Сберегательный счет:{accountNumber},Владелец:{owner},Баланс:{balance},"+$"Баланс с процентами:{calc}({Procent}%)");
        }

    }
}
