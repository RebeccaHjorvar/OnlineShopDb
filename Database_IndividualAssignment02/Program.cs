using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database_IndividualAssignment02.Methods;
using Database_IndividualAssignment02.Models;
using Database_IndividualAssignment02.EntityConfigurations;
using Figgle;

namespace Database_IndividualAssignment02
{
    class Program
    {

        static void Main(string[] args)
        {
            DisplayBanner();
            SetColor();
            MainMenuStart();

        }

        /// <summary>
        /// Main menu. Includes a TryCatch in case of wrong input.
        /// Also include references to the following methods
        /// newSeed.Seed(),
        /// AddressMethods.MainMenuAddresses(),
        /// CustomerMethods.MainMenuCustomers(),
        /// CombineMethods.DisplayCombined(),
        /// </summary>
        public static  void MainMenuStart()
        {
            Console.WriteLine("\nWhat would you like look at?\n");
            Console.WriteLine("0. Seed");
            Console.WriteLine("1. Addresses ");
            Console.WriteLine("2. Customers");
            Console.WriteLine("3. Customer and address");
            Console.WriteLine("4. Exit console app\n");

            try
            {
                var choice = Console.ReadLine();
                Console.Clear();

                if (choice == "0")
                {
                    var newSeed = new Seeds();
                    newSeed.Seed();
                }

                else if (choice == "1")
                {
                    AddressMethods.MainMenuAddresses();
                } 

                else if (choice == "2")
                {
                    CustomerMethods.MainMenuCustomers();
                } 

                else if (choice == "3")
                {
                    CombineMethods.DisplayCombined();
                } 
                else if (choice == "4")
                {
                    Environment.Exit(0);
                } 
                else
                {
                    Console.WriteLine($"{choice} is not recognized. Try again!");

                    MainMenuStart();
                } 

            }
            catch (Exception)
            {
                Console.WriteLine("\nSomething went wrong. Try again!\n");
                Console.WriteLine("\n----------------------------------------\n");
                MainMenuStart();
                
            } // In case the input is not a string this will prevent the app from shutting down
        }

        /// <summary>
        /// Displays the banner. Includes the methods SetColor()
        /// </summary>
        public static void DisplayBanner()
        {
            SetColor();
            Console.WriteLine();
            Console.WriteLine(FiggleFonts.Standard.Render(" - Online Shop - "));
            Console.WriteLine();
            Console.WriteLine("----------          Press any key to enter the application          ----------");
            Console.ReadKey(); 
           
        }
        
        /// <summary>
        /// Sets the back- and foregroundcolor
        /// </summary>
        public static void SetColor()
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
        }

    }
}
