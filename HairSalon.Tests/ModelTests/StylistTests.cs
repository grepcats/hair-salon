using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistTests
  {
    public StylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=kayla_ondracek_test";
    }

    [TestMethod]
    public void GetAllStylists_DBEmptyAtFirst_0()
    {
      //arrange, act
      int result = Stylist.GetAllStylists().Count;

      //assert
      Assert.AreEqual(0, result);
    }
  }
}
