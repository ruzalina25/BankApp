using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Services
{
    internal class Bank
    {
        private readonly List<BankAccount> account = new List<BankAccount>();
        public void AddAccount(BankAccount accounts)
        {
            account.Add(accounts);
        }

        public BankAccount GetAccountByNumber(int number)
        {
            return account.FirstOrDefault(a => a.accountNumber == number);
        }
        public List<BankAccount> GetAccountPositivBalance()
        {
            return account.Where(a => a.balance > 0).ToList();
        }

        public List<BankAccount> GetAllAccount()
        {
            return account;
        }


    }
}
