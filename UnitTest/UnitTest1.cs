using NUnit.Framework;
using AddressBookSystem;
using System.Collections.Generic;
using System;
using AddressBookSystem;
using RestSharp;
using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;

namespace UnitTest
{
    public class Tests
    {
<<<<<<< HEAD

=======
        RestClient client;
>>>>>>> UC22

        [SetUp]
        public void Setup()
        {
<<<<<<< HEAD
           
=======
            client = new RestClient("http://localhost:3000");
>>>>>>> UC22
        }

        //Add multipmle contacts to addressBook
        [Test]
        public void AddMultipleContactsToAddressBook()
        {

            AddressBook addressBook = new AddressBook();
            List<AddressBookModel> addressbookDetails = new List<AddressBookModel>();
            addressbookDetails.Add(new AddressBookModel { FirstName = "Prateek", LastName = "Pai", Address = "Bangalore", City = "Bangalore", State = "Karnataka ", ZipCode = 5600274, MobileNumber = "9945007207", Email = "prateek@gmail.com", AddressBookName = "Prateek", AddressBookID =1 });
            addressbookDetails.Add(new AddressBookModel { FirstName = "Prateeksha", LastName = "Pai", Address = "Dharwad", City = "Dharwad", State = " Karnataka", ZipCode = 574104, MobileNumber = "9482655077", Email = "prateeksha@gmail.com", AddressBookName = "Prateekahs", AddressBookID =2 });
            addressbookDetails.Add(new AddressBookModel { FirstName = "Vasanth", LastName = "Pai", Address = "Sirsi", City = "Sirsi", State = "Karnataka ", ZipCode = 581336, MobileNumber = "9482652477", Email = "vasanth@gmail.com", AddressBookName = "Vasanth", AddressBookID =2 });
            addressbookDetails.Add(new AddressBookModel { FirstName = "Geetha", LastName = "Pai", Address = "Sagar", City = "Sagar", State = "Karnataka ", ZipCode =577401 , MobileNumber = "8277099440", Email = "geetha@gmail.com", AddressBookName = "Geetha", AddressBookID =3 });
            addressbookDetails.Add(new AddressBookModel { FirstName = "Ramanath", LastName = "Pai", Address = "Kumta", City = "Kumta", State = " Karnataka", ZipCode = 581401, MobileNumber = "9483364518", Email = "ramu@gmail.com", AddressBookName = "Ramu", AddressBookID = 1});

            DateTime startDateTime1 = DateTime.Now;
            Console.WriteLine($"Data Addition to DB started on {startDateTime1}");
            AddressBook.AddMultipleContactToAddressBook(addressbookDetails);
            DateTime endDateTime1 = DateTime.Now;
            Console.WriteLine($"Data Addition to DB ended on {endDateTime1}");
            Console.WriteLine($"Time for Adding Data to DB is {endDateTime1 - startDateTime1}");
            
        }

<<<<<<< HEAD
=======
        //Read entries of AddressBook 
        [Test]
        public void onCallGetAdddressBookList()
        {
            RestRequest request = new RestRequest("/addressbook ", Method.Get);
            RestResponse response = client.Execute(request);

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            List<AddressBookModel> dataResponse = JsonConvert.DeserializeObject<List<AddressBookModel>>(response.Content);
            Assert.AreEqual(7, dataResponse.Count);

            foreach (AddressBookModel model in dataResponse)
            {
                System.Console.WriteLine("\nid :" + model.id +
                                        "\nFirst Name : " + model.FirstName +
                                        "\nLast Name : " + model.LastName +
                                        "\nAddress : " + model.Address +
                                        "\nCity : " + model.City +
                                        "\nState: " + model.State +
                                        "\nZip Code :" + model.ZipCode +
                                        "\nMobile Number : " + model.MobileNumber +
                                        "\nE-Mail : " + model.Email +
                                        "\nAddressBook Name : " + model.AddressBookName);
            }
        }
>>>>>>> UC22

    }
}