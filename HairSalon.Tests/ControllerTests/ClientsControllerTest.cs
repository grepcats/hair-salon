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

        [TestMethod]
        public void Details_ReturnIfView_True()
        {
            //arrange
            ClientsController controller = new ClientsController();

            //act
            IActionResult clientDetailsView = controller.Details(1);
            ViewResult result = clientDetailsView as ViewResult;

            //assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Details_HasCorrectModelType_True()
        {
            //arrange
            ViewResult clientDetailsView = new ClientsController().Details(1) as ViewResult;

            //act
            var result = clientDetailsView.ViewData.Model;

            //assert
            Assert.IsInstanceOfType(result, typeof(Dictionary<string,object>));
        }

        [TestMethod]
        public void UpdateClientForm_ReturnIfView_True()
        {
            //arrange
            ClientsController controller = new ClientsController();

            //act
            IActionResult updateClientFormView = controller.UpdateClientForm(1);
            ViewResult result = updateClientFormView as ViewResult;

            //assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void UpdateClientForm_HasCorrectModelType_True()
        {
            //arrange
            ViewResult updateClientFormView = new ClientsController().UpdateClientForm(1) as ViewResult;

            //act
            var result = updateClientFormView.ViewData.Model;

            //assert
            Assert.IsInstanceOfType(result, typeof(Dictionary<string,object>));
        }
    }
}
