using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases.Productos;

namespace TR.servicio.Controllers.Productos
{
    public class TourController : ApiController
    {
        private TR_tour validaciones = new TR_tour();

        [HttpGet]
        public IEnumerable<TR_tour> LIstarTour()
        {
            var listado = validaciones.LIstadoTour();
            return listado.ToList();
        }

        [HttpGet]
        public IHttpActionResult BuscarTour(decimal id)
        {
            var resultado = validaciones.BuscarTour(id);
            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("El código ingresado no arrojó resultados");
        }

        [HttpPost]
        public IHttpActionResult AgregarTour(TR_tour tour)
        {
            var resultado = validaciones.AgregarTour(tour);
            if (resultado == "OK")
            {
                return Ok("Tour agregado correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpDelete]
        public IHttpActionResult EliminarTour(decimal id)
        {
            var resultado = validaciones.EliminarTour(id);
            if (resultado == "OK")
            {
                return Ok("Tour eliminado correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpPut]
        public IHttpActionResult ActualizarTour(decimal id, TR_tour tour)
        {
            var resultado = validaciones.ActualizarTour(id, tour);
            if (resultado == "OK")
            {
                return Ok("Tour actualizado correctamente");
            }
            return BadRequest(resultado);
        }
    }
}
