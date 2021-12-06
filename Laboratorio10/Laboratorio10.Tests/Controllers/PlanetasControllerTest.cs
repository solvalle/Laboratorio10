using Microsoft.VisualStudio.TestTools.UnitTesting;
using Laboratorio10.Controllers;
using Laboratorio10.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace UnitTestLab10.Controllers
{
    [TestClass]
    public class PlanetasControllerTest
    {
        [TestMethod]
        public void TestCrearPlanetaViewResultNotNull()
        {
            //Arrange
            PlanetasController planetasController = new PlanetasController();
            //Act
            ActionResult vista = planetasController.crearPlaneta();
            //Assert
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestCrearPlanetaViewResult()
        {
            //Arrange
            PlanetasController planetasController = new PlanetasController();
            //Act
            ViewResult vista = planetasController.crearPlaneta() as ViewResult;
            //Assert
            Assert.AreEqual("crearPlaneta", vista.ViewName);
        }

        [TestMethod]
        public void EditarPlanetaIdValidoVistaNoNula()
        {
            //Arrange
            int id = 1;
            PlanetasController planetasController = new PlanetasController();
            //Act
            ViewResult vista = planetasController.editarPlaneta(id) as ViewResult;
            //Assert
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void EditarPlanetaValidoModeloRetornadoNoEsNulo()
        {
            //Arrange
            int id = 1;
            PlanetasController planetasController = new PlanetasController();
            //Act
            ViewResult vista = planetasController.editarPlaneta(id) as ViewResult;
            //Assert
            Assert.IsNotNull(vista.Model);
        }

        [TestMethod]
        public void EditarPlanetaConIdNoExistenteRedirectToLP()
        {
            //Arrange
            int idInvalido = -1;
            PlanetasController planetasController = new PlanetasController();
            //Act
            RedirectToRouteResult vista = planetasController.editarPlaneta(idInvalido) as RedirectToRouteResult;
            //Assert
            Assert.AreEqual("listadoDePlanetas", vista.RouteValues["action"]);
        }

        [TestMethod]
        public void EditarPlanetaElModeloEnviadoEsCorrecto()
        {
            //Arrange
            int id = 10;
            PlanetasController planetasController = new PlanetasController();
            //Act
            ViewResult vista = planetasController.editarPlaneta(id) as ViewResult;
            PlanetaModel planeta = vista.Model as PlanetaModel;
            //Assert
            Assert.IsNotNull(planeta);
            Assert.AreEqual(0, planeta.numeroAnillos);
            Assert.AreEqual("B 612", planeta.nombre);
        }

        [TestMethod]
        public void EditarPlanetaElModeloEsDelTipoDeDatoCorrecto() {
            //Arrange
            int id = 10;
            PlanetasController planetasController = new PlanetasController();
            //Act
            ViewResult vista = planetasController.editarPlaneta(id) as ViewResult;
            //Assert
            Assert.IsInstanceOfType(vista.Model, typeof(PlanetaModel));
        }

        [TestMethod]
        public void ListadoDePlanetasCantidadDePlanetasEsCorrecta()
        {
            //Arrange
            int numeroPlanetas = 10;
            PlanetasController planetasController = new PlanetasController();
            //Act
            ViewResult vista = planetasController.listadoDePlanetas() as ViewResult;
            //Assert
            Assert.AreEqual(numeroPlanetas, vista.ViewBag.planetas.Count);
        }

        [TestMethod]
        public void ListadoDePlanetasContienePlaneta() {
            //Arrange
            int idPlaneta = 10;
            PlanetasController planetasController = new PlanetasController();

            //Act
            ViewResult vista = planetasController.listadoDePlanetas() as ViewResult;
            List<PlanetaModel> planetas= vista.ViewBag.planetas;

            //Assert
            Assert.IsTrue(planetas.Exists(model => model.id == idPlaneta));
        }

    }
}
