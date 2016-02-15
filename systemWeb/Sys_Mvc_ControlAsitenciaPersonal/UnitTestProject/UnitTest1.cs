using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSite;
using WebSite.Controllers;
using System.Web;
using System.Web.Mvc;
namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Pruebaresul()
        {
            AreasController controlador = new AreasController();
            ViewResult result = controlador.Prueba() as ViewResult;
            Assert.IsNotNull(result);
        }
    }


}
