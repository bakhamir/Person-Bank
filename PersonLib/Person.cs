using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    public class Person
    {

        const int wage = 1000;
        const string company = "Dojima family";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string workingCompany { get; set; }
        public int personalWage { get; set; }


        public Person(string FirstName,string LastName,string Title)
        {
            Random random = new Random();
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Title = Title;
            personalWage = wage * random.Next(1,8);
            workingCompany = company.ToLower();
        }
    }
}
