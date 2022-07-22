using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    internal class AddressBookSystem
    {
        static List<AddressBookModel> AddressBookcontact = new List<AddressBookModel>();

        //Retrieve the employee payroll from  database
        public static void RetrieveEmployeePayrollFromDataBase() 
        {
            string SQL = "exec GetAllDetails";
            string connectingstring = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=Address_Book_Service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingstring);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var cnt = new AddressBookModel();
                    cnt.FirstName = reader.GetString(0);
                    cnt.LastName = reader.GetString(1);
                    cnt.Address = reader.GetString(2);
                    cnt.City = reader.GetString(3);
                    cnt.State = reader.GetString(4);
                    cnt.ZipCode = reader.GetInt32(5);
                    cnt.MobileNumber = reader.GetString(6);
                    cnt.Email = reader.GetString(7);
                    cnt.AddressBookName = reader.GetString(8);
                    cnt.AddressBookID = reader.GetInt32(9);
                    AddressBookcontact.Add(cnt);
                }
                reader.Close();
                foreach (var c in AddressBookcontact)
                {
                    Console.WriteLine("\nFirst Name :" + c.FirstName +
                        "\nLast Name :" + c.LastName +
                        "\nAddress : " + c.Address +
                        "\nCity :" + c.City +
                        "\nState :" + c.State +
                        "\nZip Code :" + c.ZipCode +
                        "\nMobile Number :" + c.MobileNumber +
                        "\nEmail :" + c.Email +
                        "\nAddress Book Name :" + c.AddressBookName +
                        "\nAddress Book ID :" + c.AddressBookID);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception :" + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        //Update the Contact information in the address Book for a person 
        public static void UpdateContactInformationOfPersoninAddressBook()
        {
            var SQL = @$"UPDATE AddressBook set PhoneNumber  = '8762265775' where FirstName = 'Prateek'";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=Address_Book_Service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine(reader);
            Console.WriteLine("Updated the data Successfully");
            Console.ReadKey();
        }

        //Retrieve all the contacts from the database were added in a perticular period
        public static void RetrieveContactsFromDatabaseInPerticularPeriod()
        {
            var SQL = @$"select FirstName FROM AddressBook WHERE date_added BETWEEN CAST('2000-01-01' As date) AND CAST('2010-01-01' As date)";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=Address_Book_Service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("List of Contacts added in the given period of time is {0}", reader["FirstName"]);
                }
                reader.Close();
            };
            Console.ReadKey();
        }

        //Retrieve Number Contacts in AddressBok by City
        public static void CountOfContactsInAddressBookByCity()
        {
            var SQL = @$"select COUNT(City) FROM AddressBook";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=Address_Book_Service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();

            int reader = (int)cmd.ExecuteScalar();
            Console.WriteLine("Number Contacts in AddressBok by City : " + reader); ;
            Console.ReadKey();
        }

        //Retrieve Number Contacts in AddressBok by State 
        public static void CountOfContactsInAddressBookByState() 
        {
            var SQL = @$"select COUNT(State) FROM AddressBook";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=Address_Book_Service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();

            int reader = (int)cmd.ExecuteScalar();
            Console.WriteLine("Number Contacts in AddressBok by State : " + reader); ;
            Console.ReadKey();
        }

        //Add New Contact information in the address Book
        public static void AddNewContactInformationOfPersoninAddressBook() 
        {
            var SQL = @$"INSERT INTO AddressBook Values ('Vishwanath','Naidu','Tirupathi','Tirupathi', 'Andra Padesh','517507','9913372185','vishwa@gmail.com', 'Vishwa', 3, '2020-06-06')";
            string connectingString = @"Data Source=DESKTOP-2UKFQA8;Initial Catalog=Address_Book_Service;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectingString);
            SqlCommand cmd = new SqlCommand(SQL, connection);
            connection.Open();
            int reader = cmd.ExecuteNonQuery();
            Console.WriteLine(reader);
            Console.WriteLine("New contact added Successfully");
            Console.ReadKey();
        }

        //Write the Persons contact in AddtressBook to JSON File.
        public static void WriteContactInAddressbookintoJSONFile()
        {
            string path = @"D:\LFP 158\Assignment\Day 23\AddressBookSystem\AddressBookSystem\AddressBook.json";

            Console.WriteLine("********* Writing to JSON File **********");

            //Writing the User data in to JSON file
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter Write = new JsonTextWriter(sw))
            {
                serializer.Serialize(Write, AddressBookcontact);
            }
            using (StreamReader sr = new StreamReader(path))
            using (JsonReader Read = new JsonTextReader(sr))
            {
                //Reading the user data from JSON file
                string json = sr.ReadToEnd();
                var result = serializer.Deserialize(Read);
            }
        }
        //Write the Persons contact in AddtressBook to CSV File.
        public static void WriteContactInAddressbookintoCSVFile() 
        {
            string path = @"D:\LFP 158\Assignment\Day 23\AddressBookSystem\AddressBookSystem\AddressBook.csv";

            Console.WriteLine("********* Writing to CSV File **********");

            //Writing the User data in to CSV file
            using (StreamWriter sw = new StreamWriter(path))
            using (CsvWriter csvWrite = new CsvWriter(sw, CultureInfo.InvariantCulture))
            {
                csvWrite.WriteRecords(AddressBookcontact);
            }
            using (StreamReader sr = new StreamReader(path))
            using (CsvReader csvRead = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                //Reading the user data from CSV file
                var result = csvRead.GetRecords<AddressBookModel>().ToList();
                foreach (AddressBookModel person in AddressBookcontact)
                {
                    Console.WriteLine("\nFirst Name : " + person.FirstName +
                        "\nLast Name : " + person.LastName +
                        "\nAddress : " + person.Address +
                        "\nCity : " + person.City +
                        "\nState : " + person.State +
                        "\nZip Code: " + person.ZipCode +
                        "\nMobile Number : " + person.MobileNumber +
                        "\nEmail : " + person.Email +
                        "\nAddress Book Name :" + person.AddressBookName +
                        "\nAddress Book ID :" + person.AddressBookID);
                }
            }
        }

        //Write the Persons contact in AddtressBook to Txt File.
        public static void WriteContactInAddressbookintoTxtFile()
        {
            string path = @"D:\LFP 158\Assignment\Day 23\AddressBookSystem\AddressBookSystem\AddressBook.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (AddressBookModel person in AddressBookcontact)
                {
                    sw.WriteLine("\nFirst Name : " + person.FirstName +
                        "\nLast Name : " + person.LastName +
                        "\nAddress : " + person.Address +
                        "\nCity : " + person.City +
                        "\nState : " + person.State +
                        "\nZip Code: " + person.ZipCode +
                        "\nMobile Number : " + person.MobileNumber +
                        "\nEmail : " + person.Email +
                        "\nAddress Book Name :" + person.AddressBookName +
                        "\nAddress Book ID :" + person.AddressBookID);
                }
                sw.Close();
                Console.WriteLine(File.ReadAllText(path));
                Console.WriteLine("Person details are successfully Exported to Text File");
                Console.ReadKey();
            }
        }
    }
}
