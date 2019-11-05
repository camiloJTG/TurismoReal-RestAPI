using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases;
using TR.negocio.Validaciones;

namespace TR.servicio.Controllers.Estáticos
{
    public class TipoUsuarioController : ApiController
    {
        private readonly Val_tipoUsuario validaciones = new Val_tipoUsuario(); 

        [HttpGet]
        public IEnumerable<TR_tipoUsuario> ListadoTipoUsuario()
        {
            var resultado = validaciones.ListadoTipoUsuario();
            return resultado.ToList();
        }

        [HttpGet]
        public IHttpActionResult BuscarTipoEmpleado(string id)
        {
            var resultado = validaciones.BuscarTipoUsuario(id);
            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("El código ingresado no arrojó resultados");
        }

        [HttpPost]
        public IHttpActionResult AgregarTipoUsuario(TR_tipoUsuario tipoUsuario)
        {
            var resultado = validaciones.AgregarTipoUsuario(tipoUsuario);
            if (resultado == "OK")
            {
                return Ok("Tipo usuario agregado correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpDelete]
        public IHttpActionResult EliminarTipoUsuario(string id)
        {
            var resultado = validaciones.EliminarTipoUsuario(id);
            if (resultado == "OK")
            {
                return Ok("Tipo usuario eliminado correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpPut]
        public IHttpActionResult ActualizarTipoUsuario(string id, TR_tipoUsuario tipoUsuario)
        {
            var resultado = validaciones.ActualizarTipoUsuario(id,tipoUsuario);
            if (resultado == "OK")
            {
                return Ok("Tipo usuario actualizado correctamente");
            }
            return BadRequest(resultado);
        }
    }
}
