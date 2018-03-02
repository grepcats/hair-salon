using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtyTests : IDisposable
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
            Specialty.DeleteAll();
        }

        public SpecialtyTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=kayla_ondracek_test";
        }

        [TestMethod]
        public void Getters_GettersReturnAppropriately_StringsAndInts()
        {
            //arrange
            Specialty newSpecialty = new Specialty("Cutting Hair");
            string testName = "Cutting Hair";
            int testId = 0;

            //act
            string nameResult = newSpecialty.GetName();
            int idResult = newSpecialty.GetId();

            //assert
            Assert.AreEqual(nameResult, testName);
            Assert.AreEqual(idResult, testId);
        }

        [TestMethod]
        public void GetAllSpecialties_DBEmptyAtFirst_0()
        {
            //arrange, act
            int result = Specialty.GetAllSpecialties().Count;

            //assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfSame_Client()
        {
            //arrange, act
            Specialty firstSpecialty = new Specialty("Cutting Hair", 1);
            Specialty secondSpecialty = new Specialty("Cutting Hair", 1);

            //assert
            Assert.AreEqual(firstSpecialty, secondSpecialty);
        }

        [TestMethod]
        public void Save_SavesToDatabase_SpecialtyList()
        {
            //arrange
            Specialty newSpecialty = new Specialty("Cutting Hair");

            //act
            newSpecialty.Save();
            List<Specialty> result = Specialty.GetAllSpecialties();
            List<Specialty> testList = new List<Specialty>{newSpecialty};

            //assert
            CollectionAssert.AreEqual(testList, result);
        }

        public void Save_AssignsIdToObject_Id()
        {
            //arrange
            Specialty newSpecialty = new Specialty("Cutting Hair");

            //act
            newSpecialty.Save();
            Specialty savedSpecialty = Specialty.GetAllSpecialties()[0];
            int result = savedSpecialty.GetId();
            int testId = newSpecialty.GetId();

            //assign
            Assert.AreEqual(result, testId);
        }

        [TestMethod]
        public void Find_ReturnASpecialty_Specialty()
        {
            //arrange
            Specialty newSpecialty1 = new Specialty("Cutting Hair");
            Specialty newSpecialty2 = new Specialty("Curly Hair");
            newSpecialty1.Save();
            newSpecialty2.Save();
            List<Specialty> allSpecialties = Specialty.GetAllSpecialties();

            //act
            Specialty result = Specialty.Find(newSpecialty1.GetId());

            //assert
            Assert.AreEqual(newSpecialty1, result);
        }

        [TestMethod]
        public void GetStylists_ReturnListOfStylists_List()
        {
            //arrange
            Stylist newStylist1 = new Stylist("Carol", "Smith");
            Stylist newStylist2 = new Stylist("Mike", "Stinson");
            newStylist1.Save();
            newStylist2.Save();
            Specialty newSpecialty1 = new Specialty("Cutting Hair");
            Specialty newSpecialty2 = new Specialty("Curly Hair");
            newSpecialty1.Save();
            newSpecialty2.Save();
            newStylist1.AddSpecialty(newSpecialty1);
            List<Stylist> testList = new List<Stylist>{newStylist1};

            //act
            List<Stylist> result = newSpecialty1.GetStylists();

            //assert
            CollectionAssert.AreEqual(result, testList);
        }

        [TestMethod]
        public void AddStylist_ReturnListOfStylists_List()
        {
            //arrange
            Stylist newStylist1 = new Stylist("Carol", "Smith");
            Stylist newStylist2 = new Stylist("Mike", "Stinson");
            newStylist1.Save();
            newStylist2.Save();
            Specialty newSpecialty1 = new Specialty("Cutting Hair");
            Specialty newSpecialty2 = new Specialty("Curly Hair");
            newSpecialty1.Save();
            newSpecialty2.Save();

            List<Stylist> testList = new List<Stylist>{newStylist1};

            //act
            newSpecialty1.AddStylist(newStylist1);
            List<Stylist> result = newSpecialty1.GetStylists();

            //assert
            CollectionAssert.AreEqual(result, testList);
        }
    }
}
