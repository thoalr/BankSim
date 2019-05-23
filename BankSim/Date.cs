using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSim
{
    class Date
    {
        int Day;
        int Month;
        int Year;

        public Date()
        {

        }

        // Return days that year
        public int DaysThisYear()
        {
            return this.Day + this.DaysTillMonth();
        }

        // Return days up to the month
        public int DaysTillMonth()
        {
            int leap = 0;
            if (this.IsLeapYear()) leap = 1;
            int days = 0;
            for (int i = 1; i < this.Month; i++)
            {
                switch (i)
                {
                    case 1:
                        days += 31;
                        break;
                    case 2:
                        days += 28 + leap;
                        break;
                    case 3:
                        days += 31;
                        break;
                    case 4:
                        days += 30;
                        break;
                    case 5:
                        days += 31;
                        break;
                    case 6:
                        days += 30;
                        break;
                    case 7:
                        days += 31;
                        break;
                    case 8:
                        days += 31;
                        break;
                    case 9:
                        days += 30;
                        break;
                    case 10:
                        days += 31;
                        break;
                    case 11:
                        days += 30;
                        break;
                    default:
                        days += 0;
                        break;
                }
            }
            return days;
        }

        public bool IsLeapYear()
        {
            if (this.Year % 4 == 0)
            {
                if (this.Year % 400 == 0)
                {
                    return true;
                }
                if (this.Year % 100 == 0)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public static string CurrentDay()
        {
            return Date.CurrentDay();
        }

        public override string ToString()
        {
            return String.Format("{0}.{1}.{2}", this.Day, this.Month, this.Year);
        }

    }
}
