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
        struct TransferS
        {
            public double Amount;
            public DateTime DateTime;

            public TransferS(double a, DateTime d)
            {
                this.Amount = a;
                this.DateTime = d;
            }
            public override String ToString()
            {
                return this.Amount.ToString() + this.DateTime.ToString();
            }
        };

        static List<TransferS> transferlist = new List<TransferS>();

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


        static void loadTransferFile(string[] args)
        {
            if (args.Length == 0) return;

            if(File.Exists(args[0]))
            {
                String file = File.ReadAllText(args[0]);

                JsonConvert.SerializeObject

                transferlist = JsonConvert.DeserializeObject<List<TransferS>>(file);
            }
        }

        static void saveTransferFile()
        {

        }

        static void saveInterestFile()
        {

        }

        static int MainMenu()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("   Select your choice        ");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1: Add Transfer              ");
            Console.WriteLine("2: Add Weekly Transfer       ");
            Console.WriteLine("3: Add Monthly Transfer      ");
            Console.WriteLine("4: Add Time Interval Transfer");
            Console.WriteLine("5: List Transfers            ");
            Console.WriteLine("6: Delete Transfer           ");
            Console.WriteLine("7: Calculate Interest        ");

            int s = 0;
            try
            {
                s = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            } Console.ReadLine();


            return 0;
        }

        static void TransferMenu()
        {
            Console.WriteLine("Write in the format [Amount dd.mm.yyyy]");
        }
        

        static void Main(string[] args)
        {
            //bank.Menu();

            loadTransferFile(args);

            bool cont = true;

            while (cont)
            {
                Console.Write("Write in the initial sum: ");
                double sum = 0;
                if (!Double.TryParse(Console.ReadLine(), out sum)) Console.WriteLine("Could not convert String to Double");
                transferlist.Add(new TransferS(sum, new DateTime(2019, 1, 1)));

                Console.Write("Write in the interest rate: ");
                double interest = 0;
                if (!Double.TryParse(Console.ReadLine(), out interest)) Console.WriteLine("Could not convert String to Double");

                bool addTransfer = true;
                // Add Monthly transfers
                Console.Write("Do you want to add a monthly transfer? [Y/N] ");
                addTransfer = (Console.ReadLine().ToUpper() == "Y");
                while (addTransfer)
                {
                    TransferS t = new TransferS();
                    int day = 1;
                    try
                    {
                        Console.Write("Add a monthly transfer: [amount (day of month (max 28))]");

                        String[] s = Console.ReadLine().Split(' ');
                        Double.TryParse(s[0], out t.Amount);
                        day = int.Parse(s[0]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("An error occured try again.");
                        continue;
                    }
                    // Add monthly 
                    for(int i = 1; i <= 12; i++)
                    {
                        t.DateTime = new DateTime(2019, i, day);
                        transferlist.Add(t);
                    }
                    foreach (TransferS item in transferlist) Console.WriteLine(item);

                    Console.Write("Do you want to add another transfer? [Y/N] ");
                    addTransfer = (Console.ReadLine().ToUpper() == "Y");

                }

                // Add weekly transfer
                addTransfer = true;
                Console.Write("Do you want to add a weekly transfer? [Y/N] ");
                addTransfer = (Console.ReadLine().ToUpper() == "Y");
                while (addTransfer)
                {
                    TransferS t = new TransferS();
                    DateTime date;
                    try
                    {
                        Console.Write("Add a weekly transfer: [amount (starting date dd.mm)]");

                        String[] s = Console.ReadLine().Split(' ');
                        Double.TryParse(s[0], out t.Amount);
                        String[] d = (s[1]).Split('.');
                        int[] di = new int[] { int.Parse(d[0]), int.Parse(d[1]) };
                        date = new DateTime(2019, di[1], di[0]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("An error occured try again.");
                        continue;
                    }
                    // Add weekly
                    do
                    {
                        t.DateTime = date;
                        transferlist.Add(t);
                        date = date.AddDays(7);
                    } while (date.DayOfYear < 365);

                    foreach (TransferS item in transferlist) Console.WriteLine(item);

                    Console.Write("Do you want to add another transfer? [Y/N] ");
                    addTransfer = (Console.ReadLine().ToUpper() == "Y");

                }

                // Add miscealleanious transfers
                addTransfer = true;
                Console.Write("Do you want to add a one time transfer? [Y/N] ");
                addTransfer = (Console.ReadLine().ToUpper() == "Y");
                while (addTransfer)
                {
                    TransferS t = new TransferS();
                    try
                    {
                        Console.Write("Add a transfer: [amount dd.mm]");
                        String[] s = Console.ReadLine().Split(' ');
                        Double.TryParse(s[0], out t.Amount);
                        String[] d = (s[1]).Split('.');
                        int[] di = new int[] { int.Parse(d[0]), int.Parse(d[1]) };
                        t.DateTime = new DateTime(2019, di[1], di[0]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("An error occured try again.");
                        continue;
                    }
                    transferlist.Add(t);

                    foreach (TransferS item in transferlist) Console.WriteLine(item);

                    Console.Write("Do you want to add another transfer? (Y/N) ");
                    addTransfer = (Console.ReadLine().ToUpper() == "Y");

                }

                Console.Write("Do you want to save the entered transfesr? (Y/N) ");
                if (Console.ReadLine().ToUpper() == "Y") saveTransferFile();

                InterestCalc(sum, interest);

                Console.Write("Do you want to save the calculated interest? (Y/N) ");
                if (Console.ReadLine().ToUpper() == "Y") saveInterestFile();


                Console.Write("Do you want to go again? (Y/N)");
                cont = (Console.ReadLine().ToUpper() == "Y");
            }

            Console.ReadLine();



        }
    }
}
