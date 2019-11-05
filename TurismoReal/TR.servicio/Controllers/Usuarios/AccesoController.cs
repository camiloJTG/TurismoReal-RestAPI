using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases.Usuarios;
using TR.negocio.Validaciones.Usuarios;

namespace TR.servicio.Controllers.Usuarios
{
    public class AccesoController : ApiController
    {
        private Val_acceso validaciones = new Val_acceso();

        [HttpPost]
        public IHttpActionResult InicioSesion(TR_acceso acceso)
        {
            var resultado = validaciones.ValidarAcceso(acceso);
            return Ok(resultado);
        }
    }
}
