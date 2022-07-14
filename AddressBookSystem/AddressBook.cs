using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    public class AddressBook
    {
        // Creating list for Storing the Contacts of Each Persons details
        public static List<Contact> AddressDetails = new List<Contact>();

        // Creating the dictionary to save the Multiple conatact in Addressbook
        public static Dictionary<string, Contact> Dairy = new Dictionary<string, Contact>();

        //public static Contact person = new Contact();

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

        // Creating the method for Adding new contact
        public static void AddNewContact()
        {
            Contact person = new Contact();
            Console.Write("Enter First Name: ");
            person.FirstName = Console.ReadLine();

            //checkduplicateEntry();
            List<Contact> checkDuplicate = AddressDetails.FindAll(x => (x.FirstName == person.FirstName));
            {
                if (checkDuplicate.Count == 0)
                {
                    Console.Write("Enter Last Name: ");
                    person.LastName = Console.ReadLine();

                    Console.Write("Enter Address : ");
                    person.Address = Console.ReadLine();

                    Console.Write("Enter City: ");
                    person.City = Console.ReadLine();

                    Console.Write("Enter State: ");
                    person.State = Console.ReadLine();

                    Console.Write("Enter Zip Code: ");
                    person.ZipCode = int.Parse(Console.ReadLine());

                    Console.Write("Enter Mobile Number: ");
                    person.MobileNumber = long.Parse(Console.ReadLine());

                    Console.Write("Enter E-Mail: ");
                    person.Email = Console.ReadLine();

                    Console.WriteLine("\n************************************\n");
                    PrintContact(person);
                    Console.WriteLine("\n************************************\n");

                    //Adding Contact into AddressBook
                    AddressDetails.Add(person);

                    //Adding Unique name to the Address Book
                    Console.WriteLine("\nEnter Name of the Contact details to Store in the Address Book\n");
                    string DairyName = Console.ReadLine();
                    Dairy.Add(DairyName, person);
                }
                else
                {
                    Console.WriteLine("\n************************************\n");
                    Console.WriteLine("\nThe Entered Person Name is already exist in the Address Book");
                    Console.WriteLine("\n************************************\n");
                }
            }

        }

        // Creating the method for editing the existing contact
        public static void EditExistingContact()
        {
            Console.WriteLine("Enter the First Name of the person you would like to Edit.");

            string firstName = Console.ReadLine();
            Contact person = AddressDetails.FirstOrDefault(x => x.FirstName.ToLower() == firstName.ToLower());
            if (person == null)
            {
                Console.WriteLine("That person could not be found. Press any key to continue");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\nDetails of the entered person is:\n");
            Console.WriteLine("\n************************************\n");
            PrintContact(person);
            Console.WriteLine("\n************************************\n");

            Console.WriteLine("\n");
            Console.WriteLine("Are you sure you want to Edit this person from your address book? (Y/N)");
            string c = Console.ReadLine().ToLower();
            if (c == "y")
            {
                AddressDetails.Remove(person);
            }
            AddressBook.AddNewContact();
            Console.WriteLine("Person details Edited Successfully. Press any key to continue.");
            Console.ReadKey();
        }

        // Creating the method for delete the contact using person's name
        public static void deleteContact()
        {
            Console.WriteLine("Enter the First Name of the person you would like to remove.");

            string firstName = Console.ReadLine();
            Contact person = AddressDetails.FirstOrDefault(x => x.FirstName.ToLower() == firstName.ToLower());
            if (person == null)
            {
                Console.WriteLine("That person could not be found. Press any key to continue");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("\n************************************\n");
            PrintContact(person);
            Console.WriteLine("\n************************************\n");

            Console.WriteLine("Are you sure you want to remove this person from your address book? (Y/N)");
            string d = Console.ReadLine().ToLower();

            if (d == "y")
            {
                AddressDetails.Remove(person);
                Console.WriteLine("\nPerson removed\n");
            }
        }

        //List of People Method
        public static void ListOfContact()
        {
            if (AddressDetails.Count == 0)
            {
                Console.WriteLine("Address Book is empty. Press any key to continue.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("\nCurrent Contacts in Address Book:\n");
            foreach (var person in AddressDetails)
            {
                Console.WriteLine("\n************************************\n");
                PrintContact(person);
                Console.WriteLine("\n************************************\n");
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }
        //Creating the method for displyang the multiple address Book
        public static void AddressBookNames()
        {
            if (Dairy.Count == 0)
            {
                Console.WriteLine("Address Book is empty. Press any key to continue.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("List of Address Book");
            foreach (KeyValuePair<string, Contact> dairy in Dairy)
            {

                Console.WriteLine("Address Book Name : {0} - Details {1}", dairy.Key, dairy.Value);
                Console.WriteLine("\n************************************\n");
                PrintContact(dairy.Value);
                Console.WriteLine("\n************************************\n");
            }
        }

        //Serch the person by city name
        public static void SearchPersonInCity()
        {
            Console.WriteLine("Please enter the city name to search person: ");
            string city = Console.ReadLine();
            List<Contact> checkCity = AddressDetails.FindAll(x => (x.City == city));

            //Checking for Availability
            if (checkCity.Count == 0)
            {
                Console.WriteLine("No person found in the given City");
            }
            else
            {
                Console.WriteLine("Person details are: ");
                foreach (Contact contact in checkCity)
                {
                    Console.WriteLine("\nFirst Name is: " + contact.FirstName);
                }
            }
        }

        //Serch the person by city name
        public static void SearchPersonInState()
        {
            Console.WriteLine("Please enter the State name to search person: ");
            string state = Console.ReadLine();
            List<Contact> checkState= AddressDetails.FindAll(x => (x.State == state));

            //Checking for Availability
            if (checkState.Count == 0)
            {
                Console.WriteLine("No person found in the given State");
            }
            else
            {
                Console.WriteLine("Person details are: ");
                foreach (Contact contact in checkState)
                {
                    Console.WriteLine("\nFirst Name is: " + contact.FirstName);
                }
            }
        }
    }
}
