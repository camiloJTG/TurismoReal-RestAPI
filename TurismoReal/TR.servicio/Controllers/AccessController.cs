using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.logica.Clases;
using TR.logica.Conexion;

namespace TR.servicio.Controllers
{
    public class AccessController : ApiController
    {
        Conexion con = new Conexion();

        public IHttpActionResult PostLogin(Login login)
        {
            var result = con.Connection.USUARIO.FirstOrDefault(x=>x.USUARIO1 == login.USUARIO1 && x.CONTRASENA == login.CONTRASENA && x.ESTADO_ID == 1);

            if (result != null)
            {
                if (result.TIPO_USUARIO_CODIGO == "A")
                {
                    return Ok("ADMIN");
                }
                if (result.TIPO_USUARIO_CODIGO == "C")
                {
                    return Ok("CLIENT");
                }
                if (result.TIPO_USUARIO_CODIGO == "E")
                {
                    return Ok("EMPLOYEES");
                }
            }
            return BadRequest("user not exists");
        }
    }
}
