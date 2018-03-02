using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using HairSalon.Controllers;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistsControllerTest
    {
        [TestMethod]
        public void Index_ReturnIfView_True()
        {
            //arrange
            StylistsController controller = new StylistsController();

            //act
            IActionResult indexView = controller.Index();
            ViewResult result = indexView as ViewResult;

            //assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_HasCorrectModelType_True()
        {
            //arrange
            ViewResult indexView = new StylistsController().Index() as ViewResult;

            //act
            var result = indexView.ViewData.Model;

            //assert
            Assert.IsInstanceOfType(result, typeof(List<Stylist>));
        }

        [TestMethod]
        public void CreateStylistForm_ReturnIfView_True()
        {
            //arrange
            StylistsController controller = new StylistsController();

            //act
            IActionResult stylistsView = controller.CreateStylistForm();
            ViewResult result = stylistsView as ViewResult;

            //assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Details_ReturnIfView_True()
        {
            //arrange
            StylistsController controller = new StylistsController();

            //act
            IActionResult detailsView = controller.Details(1);
            ViewResult result = detailsView as ViewResult;

            //assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Details_HasCorrectModelType_True()
        {
            //arrange
            ViewResult detailsView = new StylistsController().Details(1) as ViewResult;

            //act
            var result = detailsView.ViewData.Model;

            //assert
            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
        }

        [TestMethod]
        public void UpdateStylistForm_ReturnIfView_True()
        {
            //arrange
            StylistsController controller = new StylistsController();

            //act
            IActionResult updateStylistFormView = controller.UpdateStylistForm(1);
            ViewResult result = updateStylistFormView as ViewResult;

            //assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void UpdateStylistForm_HasCorrectModelType_True()
        {
            //arrange
            ViewResult updateStylistFormView = new StylistsController().UpdateStylistForm(1) as ViewResult;

            //act
            var result = updateStylistFormView.ViewData.Model;

            //assert
            Assert.IsInstanceOfType(result, typeof(Stylist));
        }

    }
}
