using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebSite.Controllers;
using WebSite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WEb_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var areControl = new AreasController();
            //ViewResult resultado = WebSite.Controllers.AreasController as ViewResult;
        }
    }
}
