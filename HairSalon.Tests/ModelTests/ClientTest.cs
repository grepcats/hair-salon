using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientTests : IDisposable
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
            Specialty.DeleteAll();
        }

        public ClientTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=kayla_ondracek_test";
        }

        [TestMethod]
        public void Getters_GettersReturnAppropriately_StringsAndInts()
        {
            //arrange
            Client newClient = new Client("Tom", "Tomson", "503-555-1234", 1, 1);
            string controlFirst = "Tom";
            string controlLast = "Tomson";
            string controlPhone = "503-555-1234";
            int controlId = 1;
            int controlStylistId = 1;

            //act
            string resultFirst = newClient.GetFirstName();
            string resultLast = newClient.GetLastName();
            string resultPhone = newClient.GetPhoneNumber();
            int resultId = newClient.GetId();
            int resultStylistId = newClient.GetStylistId();

            //assert
            Assert.AreEqual(controlFirst, resultFirst);
            Assert.AreEqual(controlLast, resultLast);
            Assert.AreEqual(controlPhone, resultPhone);
            Assert.AreEqual(controlId, resultId);
            Assert.AreEqual(controlStylistId, resultStylistId);
        }

        [TestMethod]
        public void SetStylistId_ReturnCorrectStylistId_StylistId()
        {
            //arrange
            Client newClient = new Client("Tom", "Tomson", "503-555-1234", 1);
            Stylist newStylist = new Stylist("Carol", "Smith", 5);
            int controlId = 5;

            //act
            newClient.SetStylistId(newStylist.GetId());
            int result = newClient.GetStylistId();

            //assert
            Assert.AreEqual(result, controlId);
        }

        [TestMethod]
        public void GetAllClients_DBEmptyAtFirst_0()
        {
            //arrange, act
            int result = Client.GetAllClients().Count;

            //assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetAllClients_GetThemAll_ListClients()
        {
            //arrange
            Client newClient1 = new Client("Tom", "Tomson", "503-555-1234");
            Client newClient2 = new Client("Bill", "Tomson", "503-555-1234");
            newClient1.Save();
            newClient2.Save();
            List<Client> testList = new List<Client>{newClient1, newClient2};

            //act
            List<Client> result = Client.GetAllClients();

            //assert
            CollectionAssert.AreEqual(result, testList);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfSame_Client()
        {
            //arrange, act
            Client firstClient = new Client("Tom", "Tomson", "503-555-1234", 1, 1);
            Client secondClient = new Client("Tom", "Tomson", "503-555-1234", 1, 1);

            //assert
            Assert.AreEqual(firstClient, secondClient);
        }

        [TestMethod]
        public void Save_SavesToDatabase_ClientList()
        {
            //arrange
            Client newClient = new Client("Tom", "Tomson", "503-555-1234");

            //act
            newClient.Save();
            List<Client> result = Client.GetAllClients();
            List<Client> testList = new List<Client>{newClient};

            //assert
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Save_AssignsIdToObject_Id()
        {
            //arrange
            Client newClient = new Client("Tom", "Tomson", "503-555-1234");

            //act
            newClient.Save();
            Client savedClient = Client.GetAllClients()[0];
            int result = savedClient.GetId();
            int testId = newClient.GetId();

            //assign
            Assert.AreEqual(result, testId);
        }

        [TestMethod]
        public void Find_FindAClient_Client()
        {
            //arrange
            Client controlClient = new Client("Tom", "Tomson", "503-555-1234");
            controlClient.Save();

            //act
            Client foundClient = Client.Find(controlClient.GetId());

            //Assert
            Assert.AreEqual(foundClient, controlClient);
        }

        [TestMethod]
        public void Delete_DeleteAClientInDatabase_void()
        {
            //arrange
            Client newClient1 = new Client("Tom", "Tomson", "503-555-1234", 1);
            newClient1.Save();
            List<Client> originalList = Client.GetAllClients();
            Client newClient2 = new Client("Bill", "Billson", "503-555-1234", 2);
            newClient2.Save();

            //act
            newClient2.Delete();
            List<Client> newList = Client.GetAllClients();

            //assert
            CollectionAssert.AreEqual(newList, originalList);
        }

        [TestMethod]
        public void Edit_EditClientInfoInDB_Client()
        {
            //arrange
            Stylist newStylist = new Stylist("Carol", "Smith");
            newStylist.Save();
            Stylist newStylist2 = new Stylist("Andrea", "HairCuts");
            newStylist2.Save();
            Client newClient = new Client("Bob", "Bobson", "222-222-2222");
            newClient.Save();
            newClient.SetStylistId(newStylist.GetId());
            string newFirstName = "Bill";
            string newLastName = "Billson";
            string newPhone = "333-333-3333";
            int stylistId = newStylist2.GetId();

            //act
            newClient.Edit(newFirstName, newLastName, newPhone, stylistId);

            //assert
            Assert.AreEqual(newFirstName, newClient.GetFirstName());
            Assert.AreEqual(newLastName, newClient.GetLastName());
            Assert.AreEqual(newPhone, newClient.GetPhoneNumber());
            Assert.AreEqual(stylistId, newClient.GetStylistId());
        }
    }
}
