using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using HairSalon.Controllers;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientsControllerTest
    {
        [TestMethod]
        public void Index_ReturnIfView_True()
        {
            //arrange
            ClientsController controller = new ClientsController();

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
            ViewResult indexView = new ClientsController().Index() as ViewResult;

            //act
            var result = indexView.ViewData.Model;

            //assert
            Assert.IsInstanceOfType(result, typeof(List<Client>));
        }

        [TestMethod]
        public void CreateClientForm_ReturnIfView_True()
        {
            //arrange
            ClientsController controller = new ClientsController();

            //act
            IActionResult clientFormView = controller.CreateClientForm(1);
            ViewResult result = clientFormView as ViewResult;

            //assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void CreateClientForm_HasCorrectModelType_True()
        {
            //arrange
            ViewResult clientFormView = new ClientsController().CreateClientForm(1) as ViewResult;

            //act
            var result = clientFormView.ViewData.Model;

            //assert
            Assert.IsInstanceOfType(result, typeof(Stylist));
        }
    }
}
