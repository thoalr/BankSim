using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSim
{
    class Client
    {
        enum MyEnum
        {
            Admin, Custumer
        }
        Account[] Accounts;

        public String Name;
        public String Menu =
            "1 [name]: Choose account if it does not exist a new on will be created\n" +
            "2 [name]: Delete account\n" + 
            "3       : Show all accounts\n" +
            "4 [name]: Change account name";

        public Client(String n)
        {
            this.Name = n;
        }

        public void WriteMenu()
        {

            Console.WriteLine(this.Menu);
        }

        public void ExcecuteMenu(String action)
        {
            String a = action.Substring(0, 1);
            switch(action)
            {
                case "1":
                    break;
                    
            }
        }
    }
}
