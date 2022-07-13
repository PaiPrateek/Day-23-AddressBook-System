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
            AddressBook.AddNewContact();
            AddressBook.EditExistingContact();
        }
    }
}
