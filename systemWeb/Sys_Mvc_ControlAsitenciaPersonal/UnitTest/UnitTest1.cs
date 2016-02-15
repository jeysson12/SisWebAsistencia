using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSite.Controllers;
using WebSite;
using System.Web.Mvc;
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AreasController controller = new AreasController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
