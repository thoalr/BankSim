using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSim
{
    class Account
    {
        int Amount;
        List<Transfer> Transfers;
        List<Transfer> ReapetedTransfers;
        double Interest_rate;
        public String Name;
        public String Menu =
            "1 [amount] [date] optinal [# of days until reapeted indefinately]: Choose account if it does not exist a new on will be created\n" +
            "2 [id]: Delete transfer\n" + 
            "3       : Show all transfer\n" +
            "4 [name]: Change account name";

        public Account(String n)
        {
            this.Name = n;
        }


        public void AddTransfer()
        {
            Transfer t = new Transfer();
            this.Transfers.Add(t);
        }

        public void WriteMenu()
        {

            Console.WriteLine(this.Menu);
        }

    }

}
