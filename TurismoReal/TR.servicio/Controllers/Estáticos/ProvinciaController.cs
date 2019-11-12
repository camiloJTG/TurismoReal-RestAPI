using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases;

namespace TR.servicio.Controllers.Estáticos
{
    public class ProvinciaController : ApiController
    {
        private readonly TR_provincia validaciones = new TR_provincia();

        [HttpGet]
        public IEnumerable<TR_provincia> ListadoProvincia()
        {
            var listado = validaciones.ListadoProvincia();
            return listado.ToList();
        }

        [HttpGet]
        public IHttpActionResult BuscarProvincia(int id)
        {
            var resultado = validaciones.BuscarProvincia(id);
            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("El código ingresado no arrojó resultados");
        }

        [HttpPost]
        public IHttpActionResult AgregarProvincia(TR_provincia provincia)
        {
            var resultado = validaciones.AgregarProvincia(provincia);
            if (resultado == "OK")
            {
                return Ok("Provincia agregada correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpDelete]
        public IHttpActionResult EliminarProvincia(int id)
        {
            var resultado = validaciones.EliminarProvincia(id);
            if (resultado == "OK")
            {
                return Ok("Provincia eliminada correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpPut]
        public IHttpActionResult ActualizarProvincia(int id, TR_provincia provincia)
        {
            var resultado = validaciones.ActualizarProvincia(id,provincia);
            if (resultado == "OK")
            {
                return Ok("Provincia actualizado correctamente");
            }
            return BadRequest(resultado);
        }
    }
}
