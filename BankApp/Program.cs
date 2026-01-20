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
            var a = new BankAccount(1, "Рузалина", 1000);
            a.DisplayInfo();
        }
    }
}
