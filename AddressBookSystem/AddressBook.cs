using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public  class AddressBook
    {
        //Creating the method for creating the contact
        public static void createContact()
        {
            Contact contact = new Contact();

            contact.FirstName = "Prateek";

            contact.LastName = "Pai";

            contact.Address = "#231, Bangalore";

            contact.City = "Bangalore";

            contact.State = "Karnataka";

            contact.ZipCode = 560027;

            contact.MobileNumber = 9945007207;

            contact.Email = "Prateekvasanthpai@gmail.com";

            Console.WriteLine("\n************************************\n");
            PrintContact(contact);
            Console.WriteLine("\n************************************\n");

        }
        // Display the Person Details
        public static void PrintContact(Contact person)
        {
            Console.WriteLine("First Name :" + person.FirstName);
            Console.WriteLine("Last Name :" + person.LastName);
            Console.WriteLine("Address :" + person.Address);
            Console.WriteLine("City :" + person.City);
            Console.WriteLine("State :" + person.State);
            Console.WriteLine("Zip Code :" + person.ZipCode);
            Console.WriteLine("Mobile Number :" + person.MobileNumber);
            Console.WriteLine("E-Mail :" + person.Email);
        }
    }
}
