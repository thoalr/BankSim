using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSim
{
    class Transfer
    {
        double Amount;
        DateTime DateTime;

        bool Repeat;
        int RepeatInDays;


        public Transfer()
        {

        }

        public Transfer(double a, DateTime t)
        {
            this.Amount = a;
            this.DateTime = t;
        }


    }
}
