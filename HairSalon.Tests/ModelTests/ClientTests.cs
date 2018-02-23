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
            Stylist newStylist = new Stylist("Carol", "Smith", "Curly Hair", 2);
            int controlId = 2;

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

        //test for making sure returning clients just for a stylist
    }
}
