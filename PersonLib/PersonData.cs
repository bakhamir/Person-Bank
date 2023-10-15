using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    public static class PersonData
    {
        public static void PersonGreet(Person person) 
        {
            Console.WriteLine($"Hello {person.FirstName} {person.LastName} going by the title {person.Title}" );
            Console.WriteLine($"You are working in {person.workingCompany} and getting a wage of {person.personalWage} $");
        }
    }
}
