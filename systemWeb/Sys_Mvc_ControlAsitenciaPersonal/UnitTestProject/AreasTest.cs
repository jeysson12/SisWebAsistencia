using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit;
using Moq;
using WebSite.Models;
using WebSite.serv;
using WebSite.Controllers;
using System.Web;
using System.Web.Mvc;
namespace UnitTestProject
{
    [TestFixture]
    public class AreasTest
    {
        [Test]
        public void Areas_get_List()
        {
            var areaReportMock = new Mock<IAreasRepositorio>();

            areaReportMock.Setup(a => a.ListarAreasT()).Returns(new List<AREAS>()
            {
                new AREAS{ID_AREA=1,NOMBRE="Sistemas"},
                new AREAS{ID_AREA=2,NOMBRE="Produccion"},
                new AREAS{ID_AREA=3,NOMBRE="Finanzas"}
            });

            var controlador = new AreasController(areaReportMock.Object);
            var result = controlador.listarAreasTest() as ViewResult;
            Assert.IsNotNull(result);

            List<AREAS> list = result.Model as List<AREAS>;
            Assert.IsNotNull(list);

            Assert.IsTrue(igualValores(1, "Sistemas", list[0]));
            Assert.IsTrue(igualValores(2, "Produccion", list[1]));
            Assert.IsTrue(igualValores(3, "Finanzas", list[2]));
        }

        private bool igualValores(int id , string nombre, AREAS area)
        {
            return id == area.ID_AREA && nombre == area.NOMBRE;
        }

    }
}
