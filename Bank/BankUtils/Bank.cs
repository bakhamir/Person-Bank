using Bankomat.BankUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat.BankUtils
{
    public class Bank
    {
        private Dictionary<string, Account> accounts;


        public Bank()
        {
            accounts = new Dictionary<string, Account>();
        }

        public Account OpenAccount(string accountNumber, double initialBalance,string password)
        {
            Account account = new Account(accountNumber, initialBalance,password);
            accounts[accountNumber] = account;
            return account;
        }

        public bool ValidateAccount(string accountNumber)
        {
            return accounts.ContainsKey(accountNumber);
        }

        public bool ValidateLogin(string accountNumber, string password)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                Account account = accounts[accountNumber];
                return account.ValidatePassword(password);
            }
            return false;
        }

        public void DisplayBalance(Account account)
        {
            Console.WriteLine($"Баланс на счете {account.AccountNumber}: {account.Balance}");
        }

        public void Deposit(Account account, double amount)
        {
            account.Deposit(amount);
        }

        public bool Withdraw(Account account, double amount)
        {
            return account.Withdraw(amount);
        }

        public void StartATM()
        {
            int attempts = 3;
            bool loggedIn = false;

            while (attempts > 0)
            {
                Console.Write("Введите номер счета: ");
                string accountNumber = Console.ReadLine();

                Console.Write("Введите пароль: ");
                string password = Console.ReadLine();

                if (ValidateLogin(accountNumber, password))
                {
                    loggedIn = true;
                    LoggedIn(accountNumber, password, loggedIn);
                    break;
                }

                attempts--;
                
                
                Console.WriteLine($"Неправильный номер счета или пароль. Осталось попыток: {attempts}");
            }
        }
        public void LoggedIn(string accountNumber,string password,bool loggedIn)
        {

            if (loggedIn)
            {
                Account clientAccount = accounts[accountNumber];

                while (true)
                {
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("a. Вывести баланс на экран");
                    Console.WriteLine("b. Пополнить счет");
                    Console.WriteLine("c. Снять деньги со счета");
                    Console.WriteLine("d. Выйти");

                    char choice = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    switch (choice)
                    {
                        case 'a':
                            DisplayBalance(clientAccount);
                            break;
                        case 'b':
                            Console.Write("Введите сумму для пополнения: ");
                            double depositAmount = double.Parse(Console.ReadLine());
                            Deposit(clientAccount, depositAmount);
                            break;
                        case 'c':
                            Console.Write("Введите сумму для снятия: ");
                            double withdrawAmount = double.Parse(Console.ReadLine());
                            if (Withdraw(clientAccount, withdrawAmount))
                            {
                                Console.WriteLine($"Сумма {withdrawAmount} успешно снята со счета.");
                            }
                            else
                            {
                                Console.WriteLine("Недостаточно средств на счете.");
                            }
                            break;
                        case 'd':
                            Console.WriteLine("До свидания!");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте снова.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Превышено количество попыток входа. Попробуйте позже.");
            }
        }
    }
}
    