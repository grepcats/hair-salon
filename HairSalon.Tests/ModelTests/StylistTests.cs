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
        public void Save_SavesToDatabase_StylistList()
        {
            //arrange
            Stylist newStylist = new Stylist("Carol", "Smith", "Curly Hair");

            //act
            newStylist.Save();
            List<Stylist> result = Stylist.GetAllStylists();
            List<Stylist> testList = new List<Stylist>{newStylist};

            //assert
            CollectionAssert.AreEqual(testList, result);
        }

        // [TestMethod]
        // public void GetId_GetsTheId_Id()
        // {
        //
        // }
        //
        // [TestMethod]
        // public void Save_AssignsIdToObject_Id()
        // {
        //
        // }
    }
}
