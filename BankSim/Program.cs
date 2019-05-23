using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSim
{
    class Program
    {
        struct TransferS
        {
            int Amount;
            DateTime DateTime;
        };

        List<DateTime> datelist = new List<DateTime>();
        List<TimeSpan> timeSpans = new List<TimeSpan>();


        static void InterestCalc(double sum, double interest, double addedM, double takenW)
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
                    sum += addedM;
                    Added += addedM;
                    //month = (month == 30) ? 31 : 30;
                }

                if (i % 7 == 0)
                {
                    sum -= takenW;
                    takenOff -= takenW;
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

        static void Main(string[] args)
        {
            //Console.WriteLine("Welcome please enter the name of your preferred bank.");
            //String bankname = Console.ReadLine();
            //Console.WriteLine();

            // Find saved bank or create new if there is no saved bank

            //Bank bank = new Bank(bankname);

            // Load saved bank information


            // Display menu
            //bank.WriteMenu();

            //String val = Console.ReadLine();



            // Try it out

            //InterestCalc(4.3E6, 0.023, 220000, 14000);


            //InterestCalc(3.5E6, 0.039, 0, 0);


            //InterestCalc(8E5, 0.012, 220000, 14000);

            

            bool cont = true;

            while(cont) 
            {
                Console.Write("Write in the initial sum: ");
                double sum = 0;
                if (!Double.TryParse(Console.ReadLine(), out sum)) Console.WriteLine("Could not convert String to Double");

                Console.Write("Write in the interest rate: ");
                double interest = 0;
                if (!Double.TryParse(Console.ReadLine(), out interest)) Console.WriteLine("Could not convert String to Double");

                Console.Write("Write in the amount to be added monthly: ");
                double addedM = 0;
                if (!Double.TryParse(Console.ReadLine(), out addedM)) Console.WriteLine("Could not convert String to Double");

                Console.Write("Write in the amount to be subtracted weekly: ");
                double takenW = 0;
                if (!Double.TryParse(Console.ReadLine(), out takenW)) Console.WriteLine("Could not convert String to Double");

                InterestCalc(sum, interest, addedM, takenW);

                Console.Write("Do you want to go again? (True/False)");
                if (!bool.TryParse(Console.ReadLine(), out cont)) {
                    cont = false;
                    Console.WriteLine("Could not convert String to bool. Program will terminate.");
                }


                }

            Console.ReadLine();
            


        }
    }
}
