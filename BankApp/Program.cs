using BankApp.Models;
using BankApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            bank.AddAccount (new StandartAccount(1, "Рузалина", -500));
            bank.AddAccount (new SavingsAccount(2, "Анна", 2000,5));
            var ac = bank.GetAccountByNumber(1);
            var posbalance = bank.GetAccountPositivBalance();
            var savingsAccount=bank.GetSavingsAccounts();
            
            Console.WriteLine($"Счет:{ac.accountNumber},Владелец:{ac.owner},Баланс:{ac.balance}");
            Console.WriteLine("Счета с положительным балансом:");
            foreach(var acc in posbalance){
                Console.WriteLine($"Счет:{acc.accountNumber},Владелец:{acc.owner},Баланс:{acc.balance}");
            }
            Console.WriteLine("Сберегательные счета:");
            foreach (var acc in savingsAccount)
            {
                Console.WriteLine($"Счет:{acc.accountNumber},Владелец:{acc.owner},Баланс:{acc.balance}");
            }


        }
    }
}
