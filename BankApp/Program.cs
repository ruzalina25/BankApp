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
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("БАНК");
                Console.WriteLine("1.Создать счет");
                Console.WriteLine("2.Пополнить счет");
                Console.WriteLine("3.Снять деньги");
                Console.WriteLine("4.Показать информацию о счёте");
                Console.WriteLine("5.Показать все счета");
                Console.WriteLine("0.Выйти");
                Console.Write("Выбор: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": CreateAccount(bank); break;
                    case "2": Deposit(bank); break;

                    case "3": Withdraw(bank); break;

                    case "4": ShowAccount(bank); break;

                    case "5": Show(bank); break;

                    case "0": running = false; break;

                    default: Console.WriteLine("Неверный выбор. Нажмите любую клавишу..."); Console.ReadKey(); break;
                }
            }
        }
        static void CreateAccount(Bank bank)
        {
            Console.Write("Номер счета: ");
            if (!int.TryParse(Console.ReadLine(), out int number) || number <= 0)
            {
                Console.WriteLine("Ошибка:номер счета должен быть числом.");
                Console.ReadKey();
                return;
            }

            Console.Write("Владелец: ");
            string owner = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(owner))
            {
                Console.WriteLine("Ошибка:владелец не может быть пустым.");
                Console.ReadKey();
                return;
            }

            Console.Write("Тип (1 — обычный, 2 — сберегательный): ");
            string t = Console.ReadLine();

            if (t != "1" && t != "2")
            {
                Console.WriteLine("Ошибка:выберите 1 или 2.");
                Console.ReadKey();
                return;
            }

            Console.Write("Баланс: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal bal) || bal < 0)
            {
                Console.WriteLine("Ошибка:баланс должен быть числом и не отрицательным.");
                Console.ReadKey();
                return;
            }

            if (t == "1")
            {
                bank.AddAccount(new StandartAccount(number, owner, bal));
            }
            else 
            {
                decimal procent = 10;

                bank.AddAccount(new SavingsAccount(number, owner, bal, procent));
            }

            Console.WriteLine("Счет создан.");
            Console.ReadKey();
        }


         static void Deposit(Bank bank)
        {
            Console.Write("Введите номер счета: ");
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("Ошибка:номер счета должен быть числом.");
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
                return;
            }

            var account = bank.GetAccountByNumber(n);
            if (account == null)
            {
                Console.WriteLine("Счет не найден.");
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
                return;
            }

            Console.Write("Введите сумму: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal sum))
            {
                Console.WriteLine("Ошибка:сумма должна быть числом.");
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
                return;
            }

            if (sum <= 0)
            {
                Console.WriteLine("Ошибка:сумма должна быть положительной.");
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
                return;
            }

            try
            {
                account.Deposit(sum);
                Console.WriteLine("Операция выполнена.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
         }
         static void Withdraw(Bank bank)
         {
             Console.Write("Введите номер счета: ");
             if (!int.TryParse(Console.ReadLine(), out int n))
             {
                Console.WriteLine("Ошибка:номер счета должен быть числом.");
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
                return;
             }

             var account = bank.GetAccountByNumber(n);
             if (account == null)
             {
                Console.WriteLine("Счет не найден.");
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
                return;
             }

              Console.Write("Введите сумму: ");
             if (!decimal.TryParse(Console.ReadLine(), out decimal sum))
             {
                Console.WriteLine("Ошибка:сумма должна быть числом.");
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
                return;
             }

             if (sum <= 0)
             {
                Console.WriteLine("Ошибка:сумма должна быть больше нуля.");
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
                return;
             }

             try
             {
                account.Withdraw(sum);
                Console.WriteLine("Операция выполнена.");
             }
             catch (Exception ex)
             {
                Console.WriteLine($"Ошибка: {ex.Message}");
             }

             Console.WriteLine("Нажмите любую клавишу...");
             Console.ReadKey();
         }
          static void ShowAccount(Bank bank)
          {
            Console.Write("Введите номер счета: ");

            if (!int.TryParse(Console.ReadLine(), out int num) || num <= 0)
            {
               Console.WriteLine("Некорректный номер счета.");
               Console.ReadKey();
               return;
            }
            var account = bank.GetAccountByNumber(num);

            if (account == null)
            {
               Console.WriteLine("Счет не найден.");
               Console.ReadKey();
               return;
            }

            Console.WriteLine("Информация о счете:");
            account.DisplayInfo();

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
          }

           static void Show(Bank bank)
           {
            var accounts = bank.GetAllAccount();

            if (accounts == null || accounts.Count == 0)
            {
              Console.WriteLine("Счетов нет.");
              Console.WriteLine("Нажмите любую клавишу...");
              Console.ReadKey();
                return;
            }

            Console.WriteLine("Список счетов:");

            foreach (var acc in accounts)
            {
                acc.DisplayInfo();
            }

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();

           }





    }
}
