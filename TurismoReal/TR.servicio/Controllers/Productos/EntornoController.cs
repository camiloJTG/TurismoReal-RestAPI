using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases.Productos;

namespace TR.servicio.Controllers.Productos
{
    public class EntornoController : ApiController
    {
        private readonly TR_entorno validaciones = new TR_entorno();

        [HttpGet]
        public IEnumerable<TR_entorno> LIstadoEntorno()
        {
            var listado = validaciones.ListadoEntorno();
            return listado.ToList();
        }

        [HttpGet]
        public IHttpActionResult BuscarEntorno(decimal id)
        {
            var resultado = validaciones.BuscarEntorno(id);
            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("El código del entorno ingresado no arrojó resultados");
        }

        [HttpPost]
        public IHttpActionResult AgregarEntorno(TR_entorno entorno)
        {
            var resultado = validaciones.AgregarEntorno(entorno);
            if (resultado == "OK")
            {
                return Ok("Entorno registrado correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpDelete]
        public IHttpActionResult EliminarEntorno(decimal id)
        {
            var resultado = validaciones.EliminarEntorno(id);
            if (resultado == "OK")
            {
                return Ok("Entorno eliminado correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpPut]
        public IHttpActionResult ActualizarEntorno(decimal id, TR_entorno entorno)
        {
            var resultado = validaciones.ActualizarEntorno(id, entorno);
            if (resultado == "OK")
            {
                return Ok("Entorno actualizado");
            }
            return BadRequest(resultado);
        }
    }
}
