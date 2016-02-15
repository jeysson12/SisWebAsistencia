using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.serv
{
    public class AreasRepositorio:IAreasRepositorio
    {
        List<Models.AREAS> _areas;

        public AreasRepositorio()
        {
            _areas = new List<Models.AREAS>
            {
                new Models.AREAS{ID_AREA=1,NOMBRE="Sistemas12"},
                new Models.AREAS{ID_AREA=2,NOMBRE="Produccion12"},
                new Models.AREAS{ID_AREA=3,NOMBRE="Finanzas12"}
            };
        }

        public List<Models.AREAS> ListarAreasT()
        {
            return _areas;
        }

    }
}