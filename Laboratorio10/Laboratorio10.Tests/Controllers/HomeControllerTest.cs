using Microsoft.VisualStudio.TestTools.UnitTesting;
using Laboratorio10.Controllers;
using System.Web.Mvc;

namespace UnitTestLab10.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void ContactSendValuesTest()
        {
            //Arrange
            HomeController homeController = new HomeController();
            //Act
            ViewResult vista = homeController.Contact() as ViewResult;
            //Assert
            Assert.IsNotNull(vista);
            Assert.AreEqual("Contact", vista.ViewName);
            Assert.AreEqual("Your contact page.", vista.ViewBag.Message);
            Assert.AreEqual(1, vista.ViewBag.ValorParaTest);
        }
    }
}