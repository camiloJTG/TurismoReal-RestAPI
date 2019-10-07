using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TR.servicio.Controllers.Reservas
{
    public class ReservaController : ApiController
    {
        private ConexionEntities Conn = new ConexionEntities();
        Validaciones validaciones = new Validaciones();

        [HttpGet]
        public IHttpActionResult GetReserva()
        {

        }
    }
}
