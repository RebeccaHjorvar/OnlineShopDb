using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Database_IndividualAssignment02.Models;
using System.Linq;

namespace Database_IndividualAssignment02
{
    class CustomerMethods
    {
        /// <summary>
        /// Displays the main menu for the address section. Includes the methods: 
        /// DisplayCustomers(), 
        /// AddCustomer(), 
        /// UpdateCustomer(), 
        /// DeleteCustomer(), 
        /// Program.MainMenuStart(), 
        /// and a TryCatch
        /// </summary>
        public static void MainMenuCustomers()
        {
            
            Console.WriteLine("\nWhat would you like to do?\n");
            Console.WriteLine("1. Show customers");
            Console.WriteLine("2. Add customer");
            Console.WriteLine("3. Update customer");
            Console.WriteLine("4. Delete customer");
            Console.WriteLine("5. Filter customers");
            Console.WriteLine("6. Go back to main menu");

            try
            {
                string input = Console.ReadLine();
                Console.Clear();

                if (input == "1")
                {
                    DisplayCustomers();
                    MainMenuCustomers();
                }

                else if (input == "2")
                {
                    AddCustomer();
                    MainMenuCustomers();
                }
                else if (input == "3")
                {
                    UpdateCustomer();
                    MainMenuCustomers();
                }

                else if (input == "4")
                {
                    DeleteCustomer();
                    MainMenuCustomers();
                }
                else if (input == "5")
                {
                    FilterCustomer();
                    MainMenuCustomers();
                }
                else if (input == "6")
                {
                    Program.MainMenuStart();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"\n{input} is not recognized. Try again!\n");
                    Console.WriteLine("\n----------------------------------------\n");
                    MainMenuCustomers();
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("\nSomething went wrong. Try again!\n");
                Console.WriteLine("\n----------------------------------------\n");
                MainMenuCustomers();
            }
        }

        /// <summary>
        /// Displays all the customers currently in the database
        /// </summary>
        public static void DisplayCustomers()
        {

            using (var context = new OnlineShopDbContext())
            {
                
                Console.WriteLine("\nThe customers currently in the table are:\n");
                var customers = context.Customers.ToList();
                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.CustomerId);
                    Console.WriteLine(customer.FirstName);
                    Console.WriteLine(customer.LastName);
                    Console.WriteLine(customer.PhoneNr);
                    Console.WriteLine(customer.Email);
                    Console.WriteLine("\n----------------------------------------\n");
                }


            }

        }

        /// <summary>
        /// Makes it possible for the user to add a new customer to the database
        /// It has a TryCatch in case something goes wrong and redirects the user to the main menu for the address section
        /// </summary>
        public static void AddCustomer()
        {

            using (var context = new OnlineShopDbContext())
            {
                
                
                Console.WriteLine("\nThis is where you add a new customer. Please fill out the form.\n");
                Console.WriteLine("First name: ");
                var firstName = Console.ReadLine();
                Console.WriteLine("Last name: ");
                var lastName = Console.ReadLine();
                Console.WriteLine("Phonenumber: ");
                var phoneNr = Console.ReadLine();
                Console.WriteLine("Email: ");
                var email = Console.ReadLine();
                Console.Clear();
                
                Console.WriteLine("\nTime to add an address ID.\n");

                AddressMethods.DisplayAddresses();
                Console.WriteLine("\nAddressId(GUID): ");
                var address = Guid.Parse(Console.ReadLine()); 
                
                Console.Clear();

                Console.WriteLine($"\nA customer has been added.\n " +
            $"\nFollowing information has been saved in the database:\n" +
            $"\nFirst name: {firstName}\n" +
            $"\nLast name: {lastName}\n" +
            $"\nPhone number: {phoneNr}\n" +
            $"\nEmail: {email}\n" +
            $"\nAddressId: {address}\n");
                Console.WriteLine("\n----------------------------------------\n"); 
                

               
                try
                {
                    var customer = new Customer()
                    {
                        CustomerId = new Guid(),
                        FirstName = firstName,
                        LastName = lastName,
                        PhoneNr = phoneNr,
                        Email = email,
                        AddressID = address
                    };

                    context.Customers.Add(customer);
                    context.SaveChanges();
                }
                
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("\nSomething went wrong. The info you have inserted has not been saved.\n");
                    Console.WriteLine("\n----------------------------------------\n");
                    MainMenuCustomers();
                } 
                
            }

        }

        /// <summary>
        /// Makes it possible for the user to delete a customer from the database and includes a TryCatch - in case the input does not work - and a failsafe if the user has chosen the wrong customer
        /// </summary>
        public static void DeleteCustomer()
        {

            using (var context = new OnlineShopDbContext())
            {
                while (true)
                {
                    
                    DisplayCustomers();
                    Console.WriteLine("Type the GUID of the customer you want to remove from the table:\n");
                    try
                    {
                        var customerId = Guid.Parse(Console.ReadLine());
                        Console.Clear();

                        var customer = context.Customers.Find(customerId);

                        if (customer != null)
                        {
                            Console.WriteLine("\nThe customer you have selected is:\n" +
                                $"{customer.FirstName} {customer.LastName}\n ");
                            Console.WriteLine("Do you really want to delete?");
                            Console.WriteLine("Type Y for yes and N for no\n");
                            var yesNo = Console.ReadLine();
                            if (yesNo == "y" || yesNo == "Y")
                            {

                                context.Remove(customer);
                                context.SaveChanges();
                                Console.WriteLine("\nThe customer is now removed\n");
                                Console.WriteLine("\n----------------------------------------\n");

                                
                                Console.WriteLine("Ok then, What would you like to do next?\n" +
                                    "\n1. Choose another customer to delete" +
                                    "\n2. Go back to the customer menu\n");

                                var choice = Console.ReadLine();
                                Console.Clear();
                                if (choice == "2")
                                {
                                    MainMenuCustomers();
                                }
                            }

                            else if (yesNo == "n" || yesNo == "N")
                            {                                
                                Console.WriteLine("Ok then, What would you like to do next?\n" +
                                    "\n1. Choose another customer to delete" +
                                    "\n2. Go back to the customer menu");

                                var choice = Console.ReadLine();
                                Console.Clear();
                                if (choice == "2")
                                {
                                    MainMenuCustomers();
                                }
                            }

                            else 
                            {
                                Console.WriteLine($"\n{customerId} is not recognized. Try again!\n");
                                Console.WriteLine("----------------------------------------");
                                MainMenuCustomers();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Something went wrong. Try again!");
                        Console.WriteLine("\n----------------------------------------\n");
                        MainMenuCustomers();
                    }
                }

            }

        }



        /// <summary>
        /// Makes it possible for the user to update an address from the database and includes a TryCatch - in case the input does not work - and a failsafe in case the user has chosen the wrong address
        /// </summary>
        public static void UpdateCustomer()
        {

            using (var context = new OnlineShopDbContext())
            {
                while (true)
                {
                    DisplayCustomers();
                    Console.WriteLine("\nType the GUID of the customer you want to update:\n");
                    try
                    {
                        var input = Guid.Parse(Console.ReadLine());
                        
                        Console.Clear();

                        var a = context.Customers.Find(input);

                        if (a != null)
                        {
                            Console.Clear();
                            Console.WriteLine("\nThe customer you have selected is:\n" +
                                $"{a.FirstName} " +
                                $"{a.LastName}\n" +
                                $"{a.Email}\n");

                            Console.WriteLine("\nDo you really want to update this customer?\n");
                            Console.WriteLine("\nType Y for yes and N for no\n");

                            var yesNo = Console.ReadLine();
                            if (yesNo == "y" || yesNo == "Y")
                            {
                                Console.Clear();
                                Console.WriteLine("\nInput the new info\n");

                                Console.WriteLine("First name: ");
                                var firstName = Console.ReadLine();

                                Console.WriteLine("Last name: ");
                                var lastName = Console.ReadLine();

                                Console.WriteLine("\nPostal code: ");
                                var postalCode = Console.ReadLine();

                                Console.WriteLine("\nEmail: ");
                                var email = Console.ReadLine();

                                Console.WriteLine("\nPhonenumber: ");
                                var phoneNr = Console.ReadLine();


                                a.FirstName = firstName;
                                a.LastName = lastName;
                                a.Email = email;
                                a.PhoneNr = phoneNr;

                                context.Update(a);
                                context.SaveChanges();
                                Console.WriteLine("\nThe customer has been updated\n");
                                Console.WriteLine("\n----------------------------------------\n");

                                Console.WriteLine("\nWhat would you like to do next?\n" +
                                    "\n1. Choose another customer to update" +
                                    "\n2. Go back to the cusomers menu\n");

                                var choice = Console.ReadLine();
                                
                                Console.Clear();

                                if (choice == "2")
                                {
                                    MainMenuCustomers();
                                }

                            }

                            else if (yesNo == "n" || yesNo == "N")
                            {
                                Console.Clear();
                                Console.WriteLine("\nOk then, What would you like to do next?\n" +
                                    "\n1. Choose another customer to update" +
                                    "\n2. Go back to the cusomers menu\n");

                                var choice = Console.ReadLine();
                                Console.Clear();
                                if (choice == "2")
                                {
                                    MainMenuCustomers();
                                }
                            }

                            else // In case of unknown input
                            {
                                Console.Clear();
                                Console.WriteLine($"\n{input} is not recognized. Try again!\n");
                                Console.WriteLine("\n----------------------------------------\n");
                                MainMenuCustomers();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("\nSomething went wrong. Try again!\n");
                        Console.WriteLine("\n----------------------------------------\n");
                        MainMenuCustomers();
                    }
                }
            }
        }

        /// <summary>
        /// Makes it possible for the user to filter the customers by their first name that is returned as a list (includes a TryCatch)
        /// </summary>
        public static void FilterCustomer()
        {
            using (var context = new OnlineShopDbContext())
            {
                while (true)
                {

                    
                    Console.WriteLine("Type the the first name of the customer/customers you want to display:\n");
                    try
                    {

                        var input = Console.ReadLine();
                        var convertedFirstLetter = "";
                        var convertedRemainingLetters = "";
                        for (var i = 0; i< input.Length; i++)
                        {
                            if (i == 0)
                            {
                                convertedFirstLetter = Convert.ToString(input[i]).ToUpper();
                            }
                            else
                            {
                                convertedRemainingLetters += Convert.ToString(input[i]).ToLower();
                            }
                            

                        }
                        input = convertedFirstLetter + convertedRemainingLetters;
                        
                        Console.Clear();
                        var customers = context.Customers.Where(x => x.FirstName == input).ToList();

                        if (customers.Count != 0)
                        {
                            Console.WriteLine($"The following customer/customers have {input} as their first name");
                            Console.WriteLine("\n----------------------------------------\n");
                            foreach (var customer in customers)
                            {
                                Console.WriteLine(customer.CustomerId);
                                Console.WriteLine(customer.FirstName);
                                Console.WriteLine(customer.LastName);
                            
                                Console.WriteLine("\n----------------------------------------\n");
                            }
                            Console.WriteLine("What would you like to do next?" +
                                    "\n1. Choose another first name to filter by" +
                                    "\n2. Go back to the customer menu");

                                var choice = Console.ReadLine();
                                Console.Clear();


                                if (choice == "1")
                                {
                                    FilterCustomer();
                                }
                                else if (choice == "2")
                                {
                                    MainMenuCustomers();
                                }
                                else
                                {
                                    Console.WriteLine($"{choice} is not recognized, you will be sent to the customer main menu.");
                                    MainMenuCustomers();
                                }
                            }
                        

                        else if (customers.Count == 0)
                        { 
                                Console.WriteLine($"There is no customer that has {input} as their first name\n" +
                                    "\nWhat would you like to do?" +
                                    "\n1. Choose another first name to filter by" +
                                    "\n2. Go back to the customer menu");

                                var choice = Console.ReadLine();
                                Console.Clear();

                            
                            if (choice == "1")
                            {
                                FilterCustomer();
                            }
                                else if (choice == "2")
                                {
                                    MainMenuCustomers();
                                }
                            else
                            {
                                Console.WriteLine($"{choice} is not recognized, you will be sent to the customer main menu.");
                                MainMenuCustomers();
                            }
                        }

                            else
                            {
                                Console.WriteLine($"\n{input} is not recognized. Try again!\n");
                                Console.WriteLine("----------------------------------------");
                                FilterCustomer();
                            }
                        
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("Something went wrong. Try again!");
                        Console.WriteLine("\n----------------------------------------\n");
                        MainMenuCustomers();
                    }
                }

            }
        }
    }
}
