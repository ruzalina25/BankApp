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
        private readonly List<BankAccount> account =new List<BankAccount>();
        public void AddAccount(BankAccount accounts)
        {
            account.Add(accounts);
        }

        public bool RemoveAccount(int number)
        {
            for (int i = 0; i < account.Count; i++)
            {
                if (account[i].accountNumber == number)
                {
                    account.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public BankAccount GetAccountByNumber(int number)
        {
            foreach (var accounts in account)
            {
                if (accounts.accountNumber == number)
                {
                    return accounts;
                }
            }
            return null;
        }

        public List<BankAccount> GetAccounts()
        {
            return account;
        }

    }
}
