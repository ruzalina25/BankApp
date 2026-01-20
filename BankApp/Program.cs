using BankApp.Models;
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
            var a = new StandartAccount(1, "Рузалина", 1000);
            var b = new SavingsAccount(2, "Анна", 2000, 5);
            a.DisplayInfo();
            b.DisplayInfo();
        }
    }
}
