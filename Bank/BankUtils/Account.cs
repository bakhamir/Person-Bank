using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat.BankUtils
{
    public class Account
    {
        public string accountNumber;
        public double balance;
        public string password;

        public Account(string accountNumber, double initialBalance, string password)
        {
            this.accountNumber = accountNumber;
            this.balance = initialBalance;
            this.password = password;
        }

        public string AccountNumber
        {
            get { return accountNumber; }
        }

        public double Balance
        {
            get { return balance; }
        }

        public bool ValidatePassword(string inputPassword)
        {
            return password == inputPassword;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Сумма {amount} успешно зачислена на ваш счет. Новый баланс: {balance}");
            }
            else
            {
                Console.WriteLine("Неверная сумма для зачисления.");
            }
        }

        public bool Withdraw(double amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Сумма {amount} успешно снята со счета. Новый баланс: {balance}");
                return true;
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счете.");
                return false;
            }
        }
    }
}
