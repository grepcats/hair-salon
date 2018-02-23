using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTests : IDisposable
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
        }

        public StylistTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=kayla_ondracek_test";
        }

        //update when Save method is created
        [TestMethod]
        public void DeleteAll_RemoveAllStylists_Void()
        {
            //arrange
            Stylist newStylist = new Stylist("Carol", "Smith", "Hair");

            //act
            Stylist.DeleteAll();
            int result = Stylist.GetAllStylists().Count;

            //assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetAllStylists_DBEmptyAtFirst_0()
        {
            //arrange, act
            int result = Stylist.GetAllStylists().Count;

            //assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Getters_GettersReturnAppropriately_StringsAndInts()
        {
            //arrange
            Stylist newStylist = new Stylist("Carol", "Smith", "Curly Hair", 1);
            string controlFirst = "Carol";
            string controlLast = "Smith";
            int controlId = 1;
            string controlSpecialty = "Curly Hair";

            //act
            string resultFirst = newStylist.GetFirstName();
            string resultLast = newStylist.GetLastName();
            int resultId = newStylist.GetId();
            string resultSpecialty = newStylist.GetSpecialty();

            //assert
            Assert.AreEqual(controlFirst, resultFirst);
            Assert.AreEqual(controlLast, resultLast);
            Assert.AreEqual(controlId, resultId);
            Assert.AreEqual(controlSpecialty, resultSpecialty);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfFirstNameSame_Stylist()
        {
            //arrange, act
            Stylist firstStylist = new Stylist("Carol", "Smith", "Curly Hair", 1);
            Stylist secondStylist = new Stylist("Carol", "Smith", "Curly Hair", 1);

            //assert
            Assert.AreEqual(firstStylist, secondStylist);
        }

        [TestMethod]
        public void Save_SavesToDatabase_StylistList()
        {
            //arrange
            Stylist newStylist = new Stylist("Carol", "Smith", "Curly Hair");

            //act
            newStylist.Save();
            List<Stylist> result = Stylist.GetAllStylists();
            Console.WriteLine(result.Count);
            List<Stylist> testList = new List<Stylist>{newStylist};
            Console.WriteLine(testList.Count);

            //assert
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Save_AssignsIdToObject_Id()
        {
            //arrange
            Stylist newStylist = new Stylist("Carol", "Smith", "Curly Hair");

            //act
            newStylist.Save();
            Stylist savedStylist = Stylist.GetAllStylists()[0];
            int result = savedStylist.GetId();
            int testId = newStylist.GetId();

            //assign
            Assert.AreEqual(result, testId);
        }

        [TestMethod]
        public void GetClients_GetClientsForThisStylist_ListClients()
        {
            //arrange
            Stylist newStylist = new Stylist("Carol", "Smith", "Curly Hair");
            newStylist.Save();
            Client newClient = new Client("Tom", "Tomson", "503-555-1234");
            newClient.SetStylistId(newStylist.GetId());
            newClient.Save();
            Client otherClient = new Client("Joe", "Joeson", "503-555-4567", 3, 4);
            otherClient.SetStylistId(newStylist.GetId());
            otherClient.Save();
            List<Client> controlList = new List<Client>{newClient, otherClient};


            Console.WriteLine("stylist id is: " + newStylist.GetId());
            Console.WriteLine("newClient stylistid is: " + newClient.GetStylistId());
            Console.WriteLine("otherClient stylistid is: " + otherClient.GetStylistId());

            //act
            List<Client> result = newStylist.GetClients();

            Console.WriteLine(result.Count + ", " + controlList.Count);

            //assert
            CollectionAssert.AreEqual(result, controlList);
        }

        [TestMethod]
        public void Find_ReturnAStylist_Stylist()
        {
            //arrange
            Stylist newStylist = new Stylist("Carol", "Smith", "Curly Hair", 1);
            Stylist newStylist2 = new Stylist("Jane", "Fonda", "Short Hair", 2);
            newStylist.Save();
            newStylist2.Save();
            List<Stylist> allStylists = Stylist.GetAllStylists();

            //act
            Stylist result = Stylist.Find(1);

            //assert
            Assert.AreEqual(newStylist, result);
        }
    }
}
