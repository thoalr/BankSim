using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace BankSim
{
    class Transfer : IComparable
    {
        public double Amount = 0;
        public DateTime DateTime;

        public Transfer(double amount, DateTime datetime)
        {
            this.Amount = amount;
            this.DateTime = datetime;
        }


        public static void CalculateInterest(List<Transfer> transfers, double interest, DateTime endDate, String filepath)
        {
            List<String> log = new List<string>();

            double perDay = interest / 365;
            double Money = 0;

            transfers.Sort();  // sort list by date

            Console.WriteLine("The interest is: \n" + interest);
            log.Add("The interest is: \n" + interest);
            Console.WriteLine("\nThe interest per day is:\n" + perDay);
            log.Add("\nThe interest per day is:\n" + perDay);


            double accInterest = 0;  // accumulated interest

            // Earliest date
            DateTime prevDate = transfers[0].DateTime;
            DateTime newYear = new DateTime(prevDate.Year + 1, 1, 1);

            foreach(Transfer t in transfers)
            {
                if (t.DateTime >= newYear)
                {
                    TimeSpan d2 = newYear - prevDate;
                    accInterest += Money * perDay * (int)d2.TotalDays;

                    Console.WriteLine("Interest at end of year: " + accInterest);
                    log.Add("Interest at end of year: " + accInterest);

                    Money += accInterest;
                    Console.WriteLine("Toatal money at end of year: " + Money);
                    log.Add("Toatal money at end of year: " + Money);

                    d2 = t.DateTime - newYear;
                    accInterest = Money * perDay * (int)d2.TotalDays;
                    Money += t.Amount;
                    newYear.AddYears(1);
                }
                else
                {
                    TimeSpan d1 = t.DateTime - prevDate;
                    accInterest += Money * perDay * (int)d1.TotalDays;
                    Money += t.Amount;

                    prevDate = t.DateTime;
                }
                Console.WriteLine("Date: " + t.DateTime + "  Money: " +  Money);
                log.Add("Date: " + t.DateTime + "  Money: " + Money);
            }

            TimeSpan d = endDate - prevDate;
            accInterest = Money * perDay * (int)d.TotalDays;
            Money += accInterest;

            Console.WriteLine("Total Money: " + Money);
            log.Add("Total Money: " + Money);
            //saveInterestFile(log,filepath);
            //return log;
        }


        public static void loadTransferFile(string[] args, out List<Transfer> items)
        {
            items = new List<Transfer>();

            if (args.Length == 0) return;

            if (File.Exists(args[0]))
            {
                using (StreamReader r = new StreamReader(args[0]))
                {
                    string json = r.ReadToEnd();
                    items = JsonConvert.DeserializeObject<List<Transfer>>(json);
                }
            }
        }

        public static void saveTransferFile(List<Transfer> list, String filePath)
        {

            //StringBuilder sb = new StringBuilder();
            //StringWriter sw = new StringWriter(sb);
            //JsonTextWriter jw = new JsonTextWriter(sw);

            using (StreamWriter wr = File.CreateText(filePath))
            {
                JsonSerializer js = new JsonSerializer();
                js.Serialize(wr, list);
            }

        }

        public static void saveInterestFile(List<String> log, String filepath)
        {

        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Transfer objT = obj as Transfer;
            if ( objT != null)
                return this.DateTime.CompareTo(objT.DateTime);
            else
                throw new ArgumentException("Object is not a Transfer");
        }

        public override String ToString()
        {
            return "Date: " + this.DateTime.ToString() + "  Money:" + this.Amount.ToString();
        }

    }
}
