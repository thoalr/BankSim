using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSim
{
    class Transfer
    {
        public double Amount = 0;
        public DateTime DateTime;

        public enum Type
        {
            Single,
            Weekly,
            Monthly,
            ReapetInDays
        }
        public Type type;

        public int RepeatDays = 0;


        public Transfer(double amount, DateTime datetime, int repeatDays)
        {
            this.Amount = amount;
            this.DateTime = datetime;
            this.type = Type.ReapetInDays;
            this.RepeatDays = repeatDays;
        }

        public Transfer(double amount, DateTime datetime, Type type)
        {
            this.Amount = amount;
            this.DateTime = datetime;
            this.type = type;
        }

        public Transfer(double amount, DateTime datetime)
        {
            this.Amount = amount;
            this.DateTime = datetime;
            this.type = Type.Single;
        }


    }
}
