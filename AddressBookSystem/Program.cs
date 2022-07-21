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
            //AddressBook.AddNewContact(); //Adding the new contact
            //AddressBook.EditExistingContact(); // Edit the existing contact using person's name
            //AddressBook.deleteContact(); //Delete the contact using person's name


            while (true)
            {
                Console.WriteLine("\nEnter 1 to Add New Contact in AddressBook");
                Console.WriteLine("\nEnter 2 to Edit the Existing Contact in AdressBook using Person's Name");
                Console.WriteLine("\nEnter 3 to Delete the Person using Person's Name in AddressBook");
                Console.WriteLine("\nEnter 4 to Get List of Contact in AddressBook");
                Console.WriteLine("\nEnter 5 to Get List of Address Book in AddressBook");
                Console.WriteLine("\nEnter 6 to Search person in City in AddressBook");
                Console.WriteLine("\nEnter 7 to Search person in State in AddressBook");
                Console.WriteLine("\nEnter 8 to To get the list of persons belongs to same city in Address Book");
                Console.WriteLine("\nEnter 9 to To get the list of persons belongs to same State in Address Book");
                Console.WriteLine("\nEnter 10 to To get the Number of persons belongs to same city in Address Book");
                Console.WriteLine("\nEnter 11 to To get the Number of persons belongs to same State in Address Book");
                Console.WriteLine("\nEnter 12 to To get the List of entries in address book sorted by Persons Name in Address Book");
                Console.WriteLine("\nEnter 13 to To get the List of entries in address book sorted by City in Address Book");
                Console.WriteLine("\nEnter 14 to To get the List of entries in address book sorted by State in Address Book");
                Console.WriteLine("\nEnter 15 to To get the List of entries in address book sorted by Zip Code in Address Book");
                Console.WriteLine("\nEnter 16 to To Export the Person details from AddressBook to Text File");
                Console.WriteLine("\nEnter 17 to To Export the Person details from AddressBook to CSV File");
                Console.WriteLine("\nEnter 18 to To Export the Person details from AddressBook to JSON File");
                Console.WriteLine("\nEnter 19 to To Retrieve the employee payroll from SQL database");
                Console.WriteLine("\nEnter 20 to To Update the Contact information in the address Book for a person");
                Console.WriteLine("\nEnter 21 to To Retrieve the contacts from the database were added in a perticular period");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddressBook.AddNewContact(); //Adding the new contact ensured that No duplicate values entry of the ssame person in a partiucular AddressBook
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
                    case 5:
                        AddressBook.AddressBookNames(); //Display the multiple addressbook with unique name and details
                        break;
                    case 6:
                        AddressBook.SearchPersonInCity(); //Search person in City
                        break;
                    case 7:
                        AddressBook.SearchPersonInState(); //Search person in State
                        break;
                    case 8:
                        AddressBook.ListOfPersonsofSameCity(); //List of Persons belongs to same city
                        break;
                    case 9:
                        AddressBook.ListOfPersonsofSameState(); //List of Persons belongs to same state
                        break;
                    case 10:
                        AddressBook.SearchPersonInCity(); //Number of Persons belongs to same city
                        break;
                    case 11:
                        AddressBook.SearchPersonInState(); //Number of Persons belongs to same state
                        break;
                    case 12:
                        AddressBook.SortByPersonsName(); //Sort the entries in Addressbook by persons name
                        break;
                    case 13:
                        AddressBook.SortByCity(); //Sort the entries in Addressbook by City
                        break;
                    case 14:
                        AddressBook.SortByState(); //Sort the entries in Addressbook by State
                        break;
                    case 15:
                        AddressBook.SortByZipCode(); //Sort the entries in Addressbook by Zip Code
                        break;
                    case 16:
                        AddressBook.WriteAddressbookintoTextFile(); //Write the Persons details in AddtressBook to Tex file And read from the person details from TextFile.
                        break;
                    case 17:
                        AddressBook.WriteAddressbookintoCSVFile(); //Write the Persons details in AddtressBook to CSV file And read from the person details from CSV File.
                        break;
                    case 18:
                        AddressBook.WriteAddressbookintoJSONFile(); //Write the Persons details in AddtressBook to CSV file And read from the person details from JSON File.
                        break;
                    case 19:
                        AddressBookSystem.RetrieveEmployeePayrollFromDataBase(); //Retrieve the employee payroll from  database
                        break;
                    case 20:
                        AddressBookSystem.UpdateContactInformationOfPersoninAddressBook(); //Update the Contact information in the address Book for a person 
                        break;
                    case 21:
                        AddressBookSystem.RetrieveContactsFromDatabaseInPerticularPeriod();  //Retrieve all the contacts from the database were added in a perticular period
                        break;
                    default:
                        Console.WriteLine("Pleasee select valid input");
                        break;
                }
            }
        }
    }
}
