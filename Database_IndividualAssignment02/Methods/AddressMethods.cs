using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Database_IndividualAssignment02.Models;
using System.Linq;

namespace Database_IndividualAssignment02
{
    class AddressMethods
    {

        /// <summary>
        /// Displays the main menu for the address section. Includes the methods: 
        /// DisplayAddresses(), 
        /// AddAddress(), 
        /// UpdateAddress(), 
        /// DeleteAddress(), 
        /// Program.MainMenuStart(), 
        /// and a TryCatch
        /// </summary>
        public static void MainMenuAddresses()
        {
            
            Console.WriteLine("\nWhat would you like to do?\n");
            Console.WriteLine("1. Show addresses");
            Console.WriteLine("2. Add address");
            Console.WriteLine("3. Update data");
            Console.WriteLine("4. Delete data");
            Console.WriteLine("5. Go back to main menu\n");

            try
            {
                string choice = Console.ReadLine();
                Console.Clear();

                if (choice == "1")
                {
                    DisplayAddresses();
                    MainMenuAddresses();
                }

                else if (choice == "2")
                {
                    AddAddress();
                    MainMenuAddresses();
                }
                else if (choice == "3")
                {
                    UpdateAddress();
                    MainMenuAddresses();
                }

                else if (choice == "4")
                {
                    DeleteAddress();
                    MainMenuAddresses();
                }
                else if (choice == "5")
                {
                    Program.MainMenuStart();
                }
                else
                {
                    Console.WriteLine($"\n{choice} is not recognized. Try again!\n");
                    Console.WriteLine("----------------------------------------");
                    MainMenuAddresses();
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Something went wrong. Try again!\n");
                Console.WriteLine("----------------------------------------");
                MainMenuAddresses();
            }
        } 

        /// <summary>
        /// Displays all the addresses currently in the database
        /// </summary>
        public static void DisplayAddresses()
        {

            using (var context = new OnlineShopDbContext())
            {
                
                Console.WriteLine("The addresses currently in the table are:\n");
                var addresses = context.Addresses.ToList();
                foreach (var address in addresses)
                {
                    Console.WriteLine(address.AddressId);
                    Console.WriteLine(address.StreetName);
                    Console.WriteLine(address.PostalCode);
                    Console.WriteLine(address.City);
                    Console.WriteLine("----------------------------------------");
                }


            }

        }

        /// <summary>
        /// Makes it possible for the user to add a new address to the database
        /// It has a TryCatch in case something goes wrong and redirects the user to the main menu for the address section
        /// </summary>
        public static void AddAddress()
        {

            using (var context = new OnlineShopDbContext())
            {
                Console.WriteLine("\nThis is where you add a new adress. Please fill out the form.\n");
                try
                {
                    Console.WriteLine("Street name: ");
                var streetName = Console.ReadLine();
                Console.WriteLine("Postal code: ");
                var postalCode = Console.ReadLine();
                Console.WriteLine("City: ");
                var city = Console.ReadLine();
                    Console.Clear();
                Console.WriteLine($"Your new address has been added.\n " +
                    $"\nFollowing information has been saved in the database:\n" +
                    $"\nStreet name: {streetName}\n" +
                    $"\nPostal code: {postalCode}\n" +
                    $"\nCity: {city}\n");
                Console.WriteLine("\n----------------------------------------\n");

                
                
                    var address = new Address()
                    {
                        AddressId = new Guid(),
                        StreetName = streetName,
                        PostalCode = postalCode,
                        City = city,
                    };

                    context.Addresses.Add(address);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("\nSomething went wrong. The info you have inserted has not been saved.\n");
                    Console.WriteLine("\n----------------------------------------\n");
                    MainMenuAddresses();
                }
            }

        }
        
        /// <summary>
        /// Makes it possible for the user to delete an address from the database and includes a TryCatch - in case the input does not work - and a failsafe if the user has chosen the wrong address
        /// </summary>
        public static void DeleteAddress()
        {

            using (var context = new OnlineShopDbContext())
            {
                while (true)
                {
                    DisplayAddresses();
                    Console.WriteLine("\nType the GUID of the adress you want to remove from the table:\n");
                    var addressId = Guid.Parse(Console.ReadLine());

                    Console.Clear();

                    var address = context.Addresses.Find(addressId);

                    if (address != null)
                    {
                        Console.WriteLine($"\nThe adress you have selected is:\n{address.StreetName}\n{address.PostalCode} {address.City}\n");
                        Console.WriteLine("\nDo you really want to delete?\n");
                        Console.WriteLine("\nType Y for yes and N for no\n");
                        try
                        {
                            var yesNo = Console.ReadLine();
                            Console.Clear();

                            if (yesNo == "y" || yesNo == "Y")
                            {

                                context.Remove(address);
                                context.SaveChanges();
                                Console.WriteLine("\nThe address is now removed\n");
                                Console.WriteLine("\n----------------------------------------\n");
                                
                                Console.WriteLine("\nWhat would you like to do next?\n" +
                                    "\n1. Choose another address to delete" +
                                    "\n2. Go back to the main menu\n");

                                var choice = Console.ReadLine();
                                Console.Clear();
                                if (choice == "2")
                                {
                                    MainMenuAddresses();
                                }
                            }

                            else if (yesNo == "n" || yesNo == "N")
                            {
                                
                                Console.WriteLine("\nOk then, What would you like to do next?\n" +
                                    "\n1. Choose another address to delete" +
                                    "\n2. Go back to the main menu\n");

                                var choice = Console.ReadLine();
                                Console.Clear();

                                if (choice == "2")
                                {
                                    MainMenuAddresses();
                                }
                            }

                        }
                        catch (Exception)
                        {
                            Console.Clear();
                            Console.WriteLine("\nSomething went wrong. Try again!\n");
                            Console.WriteLine("\n----------------------------------------\n");
                            MainMenuAddresses();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\nThe Guid is not recognized. Try again!\n");
                        Console.WriteLine("\n----------------------------------------\n");
                    }
                }
            }
        }

        /// <summary>
        /// Makes it possible for the user to update an address from the database and includes a TryCatch - in case the input does not work - and a failsafe in case the user has chosen the wrong address
        /// </summary>
        public static void UpdateAddress()
        {

            using (var context = new OnlineShopDbContext())
            {
                while (true)
                {
                    
                    DisplayAddresses();
                    Console.WriteLine("\nType the Guid of the adress you want to update:\n");
                    try
                    {
                        var addressId = Guid.Parse(Console.ReadLine());

                        var address = context.Addresses.Find(addressId);

                        if (address != null)
                        {
                            Console.Clear();
                            Console.WriteLine("\nThe adress you have selected is:\n" +
                                $"{address.StreetName}\n" +
                                $"{address.PostalCode} " +
                                $"{address.City}\n");

                            
                            Console.WriteLine("\nDo you really want to update this address?\n");
                            Console.WriteLine("\nType Y for yes and N for no\n");

                            var yesNo = Console.ReadLine();
                            if (yesNo == "y" || yesNo == "Y")
                            {
                                try
                                {
                                    Console.WriteLine("\nInput the new info\n");

                                    Console.WriteLine("Street name: ");
                                    var streetName = Console.ReadLine();

                                    Console.WriteLine("\nPostal code: ");
                                    var postalCode = Console.ReadLine();

                                    Console.WriteLine("\nCity: ");
                                    var city = Console.ReadLine();


                                    address.StreetName = streetName;
                                    address.PostalCode = postalCode;
                                    address.City = city;

                                    context.Update(address);
                                    context.SaveChanges();
                                    Console.WriteLine("\nThe address has been updated\n");
                                    Console.WriteLine("\n----------------------------------------\n");
                                    
                                    Console.WriteLine("\nWhat would you like to do next?\n" +
                                        "\n1. Choose another address to update" +
                                        "\n2. Go back to the main menu\n");

                                    var choice = Console.ReadLine();
                                    Console.Clear();
                                    if (choice == "2")
                                    {
                                        MainMenuAddresses();
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.Clear();
                                    Console.WriteLine("\nSomething went wrong. The info you have inserted has not been saved.\n");
                                    Console.WriteLine("\n----------------------------------------\n");
                                    MainMenuAddresses();
                                }
                            }

                            else if (yesNo == "n" || yesNo == "N")
                            {
                                Console.Clear();
                                Console.WriteLine("\nOk then, What would you like to do next?\n" +
                                    "\n1. Choose another address to update" +
                                    "\n2. Go back to the main menu\n");

                                var choice = Console.ReadLine();
                                Console.Clear();

                                if (choice == "2")
                                {
                                    MainMenuAddresses();
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.Clear();
                        Console.WriteLine("\nSomething went wrong. Try again!\n");
                        Console.WriteLine("\n----------------------------------------\n");
                        MainMenuAddresses();
                    }
                }
            }
        }
    }
}
