﻿using System;

namespace AddressBookSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Program");
            Console.WriteLine("\n");

            //Creating the Contact
            //AddressBook.createContact();

            //Adding New Contact
            //AddressBook.AddNewContact(); //Adding the new contact
            //AddressBook.EditExistingContact(); // Edit the existing contact using person's name
            //AddressBook.deleteContact(); //Delete the contact using person's name


            while (true)
            {
                Console.WriteLine("\nEnter 1 to Add New Contact in AddressBook");
                Console.WriteLine("\nEnter 2 to Edit the Existing Contact in AdressBook using Person's Name");
                Console.WriteLine("\nEnter 3 to Delete the Person using Person's Name in AddressBook");
                Console.WriteLine("\nEnter 4 to Get List of Contact in AddressBook");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddressBook.AddNewContact(); //Adding the new contact
                        break;
                    case 2:
                        AddressBook.EditExistingContact(); // Edit the existing contact using person's name
                        break;
                    case 3:
                        AddressBook.deleteContact(); //Delete the contact using person's name
                        break;
                    case 4:
                        AddressBook.ListOfContact(); //To get the list of contact in Addressbook
                        break;
                    default:
                        Console.WriteLine("Pleasee select valid input");
                        break;

                }

            }
        }
    }
}
