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
    }
}
