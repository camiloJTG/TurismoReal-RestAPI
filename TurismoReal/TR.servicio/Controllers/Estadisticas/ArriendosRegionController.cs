using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases.Estadísticas;

namespace TR.servicio.Controllers.Estadisticas
{
    public class ArriendosRegionController : ApiController
    {
        private TR_arriendosRegion validaciones = new TR_arriendosRegion();

        [HttpGet]
        public List<TR_arriendosRegion> ArriendoRegion()
        {
            var resultado = validaciones.ResultadosRegion();
            return resultado;
        }
    }
}
