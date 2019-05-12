using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSim
{
    class Bank
    {
        public String Name;
        public String Menu = 
            "1 [name]: Choose client if it does not exist a new on will be created\n" + 
            "2 [name]: Delete client\n" + 
            "3       : Show all clients" +
            "4 [name]: Change bank name";

        List<Client> Clients;

        public Bank(String n)
        {
            this.Name = n;
        }

        public void WriteMenu()
        {

            Console.WriteLine(this.Menu);
        }

    }
}
