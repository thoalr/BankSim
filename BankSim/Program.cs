using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace BankSim
{
    class Program
    {
        //struct TransferS
        //{
        //    public double Amount;
        //    public DateTime DateTime;

        //    public TransferS(double a, DateTime d)
        //    {
        //        this.Amount = a;
        //        this.DateTime = d;
        //    }
        //    public override String ToString()
        //    {
        //        return this.Amount.ToString() + this.DateTime.ToString();
        //    }
        //};

        //static List<TransferS> transferlist = new List<TransferS>();
        static List<Transfer> transfers = new List<Transfer>();
        static String defaultPath = @"C:\Users\thors\Documents\Test\";

        static void InterestCalc(double sum, double interest)
        {
            Console.WriteLine("\n\n-----------------------------------------------------------\n\n");

            double perDay = interest / 365;

            double takenOff = 0;
            double Added = 0;

            Console.WriteLine("The interest is: \n" + interest);
            Console.WriteLine("\nThe interest per day is:\n" + perDay);

            double accInterest = 0;  // accumulated interest

            Console.WriteLine("\nThe inital sum is:\n" + sum);
            Console.WriteLine("\nInterest of the initial sum is:\n" + (sum * (interest)));

            int month = 30;
            for (int i = 0; i < 365; i++)
            {
                if (i % month == 0)
                {
                    //month = (month == 30) ? 31 : 30;
                }

                if (i % 7 == 0)
                {
                }

                accInterest += sum * perDay;
            }


            Console.WriteLine("\nThe final sum is: \n" + sum);

            Console.WriteLine("\nThe accumulated interest is:\n" + accInterest);

            Console.WriteLine("\nAfter adding interest everyday the sum is:\n" + (sum + accInterest));
            Console.WriteLine("\nInterest of the final sum is:\n" + (sum * (interest)));

            Console.WriteLine("\nThe amount added to the initial sum is:\n" + Added);

            Console.WriteLine("\nThe amount takem from the initial sum is:\n\n" + takenOff);
            Console.WriteLine("\n\n-----------------------------------------------------------\n\n");
        }

        static void AddTransfer()
        {
            try
            {
                Console.WriteLine("Add a transfer: [amount dd.mm.yyy]");
                String[] s = Console.ReadLine().Split(' ');
                double a;
                Double.TryParse(s[0], out a);
                String[] d = (s[1]).Split('.');
                int[] di = new int[] { int.Parse(d[0]), int.Parse(d[1]), int.Parse(d[2]) };
                DateTime dt = new DateTime(di[2], di[1], di[0]);

                transfers.Add(new Transfer(a, dt));

                Console.WriteLine("Transfer added\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("An error occured try again.\n");
            }
        }

        static void AddWeeklyTransfer()
        {
            try
            {
                DateTime dt;
                DateTime edt;
                double am;

                Console.WriteLine("Add a weekly transfer: [amount (starting date dd.mm.yyy) (ending date)]");

                String[] s = Console.ReadLine().Split(' ');
                Double.TryParse(s[0], out am);
                // starting date
                String[] d = (s[1]).Split('.');
                int[] di = new int[] { int.Parse(d[0]), int.Parse(d[1]), int.Parse(d[2]) };
                dt = new DateTime(di[2], di[1], di[0]);
                // ending date
                d = (s[2]).Split('.');
                di = new int[] { int.Parse(d[0]), int.Parse(d[1]), int.Parse(d[2]) };
                edt = new DateTime(di[2], di[1], di[0]);

                // Add weekly
                do
                {
                    transfers.Add(new Transfer(am, dt));
                    dt = dt.AddDays(7);
                } while (dt <= edt);

                Console.WriteLine("Transfers added\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("An error occured try again.\n");
            }
        }

        static void AddMonthlyTransfer()
        {
            try
            {
                DateTime dt;
                DateTime edt;
                double am;

                Console.WriteLine("Add a monthly transfer: [amount (starting date dd.mm.yyy) (ending date)]");

                String[] s = Console.ReadLine().Split(' ');
                Double.TryParse(s[0], out am);
                // starting date
                String[] d = (s[1]).Split('.');
                int[] di = new int[] { int.Parse(d[0]), int.Parse(d[1]), int.Parse(d[2]) };
                dt = new DateTime(di[2], di[1], di[0]);
                // ending date
                d = (s[2]).Split('.');
                di = new int[] { int.Parse(d[0]), int.Parse(d[1]), int.Parse(d[2]) };
                edt = new DateTime(di[2], di[1], di[0]);


                // Add monthly 
                do
                {
                    transfers.Add(new Transfer(am, dt));
                    dt = dt.AddMonths(1);
                } while (dt <= edt);

                Console.WriteLine("Transfers added\n");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("An error occured try again.\n");
            }
        }

        static void DisplayTransfers()
        {
            Console.WriteLine("\n\n----------------------");
            foreach (Transfer item in transfers) Console.WriteLine(item);
            Console.WriteLine("----------------------\n");
        }



        static void Main(string[] args)
        {
            //bank.Menu();

            Transfer.loadTransferFile(args, out transfers);

            bool cont = true;

            while (cont)
            {
                Console.WriteLine("                              ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("    Select your choice        ");
                Console.WriteLine("------------------------------");
                Console.WriteLine(" 1: Add Transfer              ");
                Console.WriteLine(" 2: Add Weekly Transfer       ");
                Console.WriteLine(" 3: Add Monthly Transfer      ");
                Console.WriteLine("-4: Add Time Interval Transfer");
                Console.WriteLine(" 5: List Transfers            ");
                Console.WriteLine("-6: Delete Transfer           ");
                Console.WriteLine(" 7: Calculate Interest        ");
                Console.WriteLine(" 8: Save Transfers            ");
                Console.WriteLine("-9: Load Transfers            ");
                Console.WriteLine("------------------------------");
                Console.WriteLine("-a: Calculate Basic Interest  ");
                Console.WriteLine(" x: Exit                      ");
                Console.WriteLine("                              ");
                Console.Write("Select: ");

                Char c;

                try
                {
                    c = Char.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    c = '0';
                }

                switch (c)
                {
                    case '1':
                        AddTransfer();
                        break;
                    case '2':
                        AddWeeklyTransfer();
                        break;
                    case '3':
                        AddMonthlyTransfer();
                        break;

                    case '5':
                        DisplayTransfers();
                        Console.ReadLine();
                        break;

                    case '8':
                        Console.WriteLine("Enter the name of the file to save to:");
                        String name = Console.ReadLine();
                        Transfer.saveTransferFile(transfers, defaultPath + name);
                        break;
                    
                    case 'x':
                        cont = false;
                        break;
                }

            }

        }
    }
}
