using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat.BankUtils
{
    public class Client
    {
        private Account account;

        public Client(Account account)
        {
            this.account = account;
        }

        public void PerformOperation(char choice, double amount = 0)
        {
            switch (choice)
            {
                case 'a':
                    Console.WriteLine($"Баланс на счете {account.AccountNumber}: {account.Balance}");
                    break;
                case 'b':
                    Console.Write("Введите сумму для пополнения: ");
                    double depositAmount = double.Parse(Console.ReadLine());
                    account.Deposit(depositAmount);
                    break;
                case 'c':
                    Console.Write("Введите сумму для снятия: ");
                    double withdrawAmount = double.Parse(Console.ReadLine());
                    account.Withdraw(withdrawAmount);
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}
