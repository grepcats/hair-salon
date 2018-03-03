using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using HairSalon.Controllers;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtiesControllerTest
    {
        [TestMethod]
        public void Index_ReturnIfView_True()
        {
            //arrange
            SpecialtiesController controller = new SpecialtiesController();

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
            ViewResult indexView = new SpecialtiesController().Index() as ViewResult;

            //act
            var result = indexView.ViewData.Model;

            //assert
            Assert.IsInstanceOfType(result, typeof(List<Specialty>));
        }

        [TestMethod]
        public void CreateSpecialtyForm_ReturnIfView_True()
        {
            //arrange
            SpecialtiesController controller = new SpecialtiesController();

            //act
            IActionResult createSpecialtyFormView = controller.Index();
            ViewResult result = createSpecialtyFormView as ViewResult;

            //assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Details_ReturnIfView_True()
        {
            //arrange
            SpecialtiesController controller = new SpecialtiesController();

            //act
            IActionResult detailsView = controller.Index();
            ViewResult result = detailsView as ViewResult;

            //assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Details_HasCorrectModelType_True()
        {
            //arrange
            ViewResult detailsView = new SpecialtiesController().Details(1) as ViewResult;

            //act
            var result = detailsView.ViewData.Model;

            //assert
            Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
        }
    }
}
