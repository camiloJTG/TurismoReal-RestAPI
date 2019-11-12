using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases;

namespace TR.servicio.Controllers.Estáticos
{
    public class EstadoController : ApiController
    {
        private readonly TR_estado Estado = new TR_estado();

        [HttpGet]
        public IEnumerable<TR_estado> ListadoEstado()
        {
            var listado = Estado.ListadoEstado();
            return listado.ToList();
        }
        
        [HttpGet]
        public IHttpActionResult BuscarEstado(int id)
        {
            var resultado = Estado.BuscarEstado(id);
            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("La búsqueda realizada no arrojó resultados");
        }

        [HttpPost]
        public IHttpActionResult AgregarEstado(TR_estado estado)
        {
            var resultado = Estado.AgregarEstado(estado);
            if (resultado == "OK")
            {
                return Ok("Estado agregado correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpDelete]
        public IHttpActionResult EliminarEstado(int id)
        {
            var resultado = Estado.EliminarEstado(id);
            if (resultado == "OK")
            {
                return Ok("Estado eliminado correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpPut]
        public IHttpActionResult ActualizarEstado(int id, TR_estado estado)
        {
            var resultado = Estado.ActualizarEstado(id,estado);
            if (resultado == "OK")
            {
                return Ok("Estado actualizado correctamente");
            }
            return BadRequest(resultado);
        }
    }
}
