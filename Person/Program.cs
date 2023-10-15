using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonLib;
using Bankomat;
using Bankomat.BankUtils;

namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            Account account = bank.OpenAccount("123456", 1000.0,"iwasbornintheusa");
            Console.WriteLine("Добро пожаловать в банк!");
            bank.StartATM();
            personTest();
        }
        static void personTest()
        {
            Person manone = new Person("John", "Doe", "Mad dog of shimano");
            PersonData.PersonGreet(manone);
        }
    }
}
