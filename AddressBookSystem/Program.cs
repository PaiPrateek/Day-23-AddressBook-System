using System;

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
            AddressBook.AddNewContact(); //Adding the new contact
            //AddressBook.EditExistingContact(); // Edit the existing contact using person's name
            AddressBook.deleteContact(); //Delete the contact using person's name
        }
    }
}
