using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Database_IndividualAssignment02.Models;
using System.Linq;

namespace Database_IndividualAssignment02
{
     class CombineMethods
     {

        /// <summary>
        /// Lets the user input the customer id - guid - to fetch the relevant address information. Includes a TryCatch and the method CustomerMethods.DisplayCustomers()
        /// </summary>
        public static void DisplayCombined()
        {
            using (var context = new OnlineShopDbContext())
            {
                
                CustomerMethods.DisplayCustomers();


                while (true)
                {
                    Console.WriteLine("\nEnter the GUID that belongs to the customer you want the address to: \n");
                    try
                    {
                        var customerId = Guid.Parse(Console.ReadLine());
                        Console.Clear();
                        var customer = context.Customers.Find(customerId);

                        var address = context.Addresses.Find(customer.AddressID);

                        if (customer != null)
                        {
                            Console.Clear();
                            Console.WriteLine("\nThe customer you have selected is:\n" +
                                $"{customer.FirstName} {customer.LastName}\n" +
                                $"\nand their home address is\n" +
                                $"\n{address.StreetName}\n{address.PostalCode} {address.City}\n");

                            Console.WriteLine("\n----------------------------------------\n");
                            
                            

                            Console.WriteLine("\nWhat would you like to do next?\n" +
                                    "\n1. Choose another customer" +
                                    "\n2. Go back to the main menu\n");

                            var choice = Console.ReadLine();
                            Console.Clear();
                            if (choice == "2")
                            {
                                
                                Program.MainMenuStart();
                            }

                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"\n{customerId} is not recognized. Try again!\n");
                            Console.WriteLine("\n----------------------------------------\n");
                        }
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("\nSomething went wrong. Try again!\n");
                        Console.WriteLine("\n----------------------------------------\n");
                        CustomerMethods.DisplayCustomers();
                    }
                }
            }   
        }
     }
}

