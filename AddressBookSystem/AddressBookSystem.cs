using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    }
}
