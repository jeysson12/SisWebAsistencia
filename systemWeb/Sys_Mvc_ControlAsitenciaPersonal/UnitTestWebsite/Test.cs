using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSite;
using WebSite.Controllers;
using System.Web;
using System.Web.Mvc;
namespace UnitTestWebsite
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void TestDepartmentIndex()
        {
            WebSite.Controllers.AreasController controler = new AreasController();

            var actResult = controler.Index() as ViewResult;

            Assert.That(actResult.ViewName, Is.EqualTo("Index"));
        }
    }
}
