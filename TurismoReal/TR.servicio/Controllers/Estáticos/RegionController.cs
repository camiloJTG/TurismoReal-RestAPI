using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases.Estáticos;

namespace TR.servicio.Controllers.Estáticos
{
    public class RegionController : ApiController
    {
        private TR_region validaciones = new TR_region();

        [HttpGet]
        public IEnumerable<TR_region> ListadoRegion()
        {
            var listado = validaciones.ListadoRegion();
            return listado.ToList();
        }

        [HttpGet]
        public IHttpActionResult BuscarRegion(decimal id)
        {
            var resultado = validaciones.BuscarRegion(id);
            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("El código de la región no arrojó resultado");
        }

        [HttpPost]
        public IHttpActionResult AgregarRegion(TR_region region)
        {
            var resultado = validaciones.AgregarRegion(region);
            if (resultado == "OK")
            {
                return Ok("Región registrada exitosamente");
            }
            return BadRequest(resultado);
        }

        [HttpDelete]
        public IHttpActionResult EliminarRegion(decimal id)
        {
            var resultado = validaciones.EliminarRegion(id);
            if (resultado == "OK")
            {
                return Ok("Región eliminada correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpPut]
        public IHttpActionResult ActualizarRegion(decimal id, TR_region region)
        {
            var resultado = validaciones.ActualizarRegion(id, region);
            if (resultado == "OK")
            {
                return Ok("Región actualizada correctamente");
            }
            return BadRequest(resultado);
        }
    }
}
