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
            Client.DeleteAll();
            Specialty.DeleteAll();
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
            Stylist newStylist = new Stylist("Carol", "Smith");

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
            Stylist newStylist = new Stylist("Carol", "Smith", 1);
            string controlFirst = "Carol";
            string controlLast = "Smith";
            int controlId = 1;

            //act
            string resultFirst = newStylist.GetFirstName();
            string resultLast = newStylist.GetLastName();
            int resultId = newStylist.GetId();

            //assert
            Assert.AreEqual(controlFirst, resultFirst);
            Assert.AreEqual(controlLast, resultLast);
            Assert.AreEqual(controlId, resultId);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfFirstNameSame_Stylist()
        {
            //arrange, act
            Stylist firstStylist = new Stylist("Carol", "Smith", 1);
            Stylist secondStylist = new Stylist("Carol", "Smith", 1);

            //assert
            Assert.AreEqual(firstStylist, secondStylist);
        }

        [TestMethod]
        public void Save_SavesToDatabase_StylistList()
        {
            //arrange
            Stylist newStylist = new Stylist("Carol", "Smith");

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
            Stylist newStylist = new Stylist("Carol", "Smith");

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
            Stylist newStylist = new Stylist("Carol", "Smith");
            newStylist.Save();
            Client newClient = new Client("Tom", "Tomson", "503-555-1234");
            newClient.SetStylistId(newStylist.GetId());
            newClient.Save();
            Client otherClient = new Client("Joe", "Joeson", "503-555-4567", 3, 4);
            otherClient.SetStylistId(newStylist.GetId());
            otherClient.Save();
            List<Client> controlList = new List<Client>{newClient, otherClient};

            //act
            List<Client> result = newStylist.GetClients();

            //assert
            CollectionAssert.AreEqual(result, controlList);
        }

        [TestMethod]
        public void Find_ReturnAStylist_Stylist()
        {
            //arrange
            Stylist newStylist = new Stylist("Carol", "Smith");
            Stylist newStylist2 = new Stylist("Jane", "Fonda");
            newStylist.Save();
            newStylist2.Save();
            List<Stylist> allStylists = Stylist.GetAllStylists();

            //act
            Stylist result = Stylist.Find(newStylist.GetId());

            //assert
            Assert.AreEqual(newStylist, result);
        }

        [TestMethod]
        public void Delete_DeleteStylistandClientsfromDB_void()
        {
            //arrange
            Stylist newStylist1 = new Stylist("Carol", "Smith");
            newStylist1.Save();
            Client newClient1 = new Client("Tom", "Tomson", "503-555-1234");
            Client newClient2 = new Client("Bill", "Billson", "503-555-1234");
            newClient1.SetStylistId(newStylist1.GetId());
            newClient2.SetStylistId(newStylist1.GetId());
            newClient1.Save();
            newClient2.Save();

            Stylist newStylist2 = new Stylist("Jane", "Fonda");
            newStylist2.Save();
            Client newClient3 = new Client("Tom", "Tomson", "503-555-1234");
            Client newClient4 = new Client("Bill", "Billson", "503-555-1234");
            newClient3.SetStylistId(newStylist2.GetId());
            newClient4.SetStylistId(newStylist2.GetId());
            newClient3.Save();
            newClient4.Save();

            int numExistingClientsControl = 2;

            //act
            newStylist1.Delete();
            int result = Client.GetAllClients().Count;

            //assert
            Assert.AreEqual(numExistingClientsControl, result);
        }

        [TestMethod]
        public void Edit_EditStylistInfoInDB_Stylist()
        {
            //arrange
            Stylist newStylist = new Stylist("Carol", "Smith");
            newStylist.Save();
            string newLast = "Brady";

            //act
            newStylist.Edit("Carol", newLast);
            string result = newStylist.GetLastName();

            //assert
            Assert.AreEqual(newLast, result);
        }

        [TestMethod]
        public void AddSpecialty_AddsEntryToJunctionTable_ListSpecialties()
        {
            //arrange
            Specialty newSpecialty = new Specialty("Cutting Hair");
            newSpecialty.Save();
            Stylist newStylist = new Stylist("Carol", "Smith");
            newStylist.Save();

            //act
            newStylist.AddSpecialty(newSpecialty);
            List<Specialty> testList = new List<Specialty>{newSpecialty};
            List<Specialty> result = newStylist.GetSpecialties();
            Console.WriteLine(result.Count);
            //assert
            CollectionAssert.AreEqual(testList, result);
        }
    }
}
