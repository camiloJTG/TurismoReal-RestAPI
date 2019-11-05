using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases.Productos;
using TR.negocio.Validaciones.Productos;

namespace TR.servicio.Controllers.Productos
{
    public class ServicioController : ApiController
    {
        private readonly Val_servicio validaciones = new Val_servicio(); 

        [HttpGet]
        public IEnumerable<TR_servicio> LIstarServicio()
        {
            var listado = validaciones.ListarServicios();
            return listado.ToList();
        }

        [HttpGet]
        public IHttpActionResult BuscarServicio(decimal id)
        {
            var resultado = validaciones.BuscarServicio(id);
            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("El código ingresado no arrojó resultados");
        }

        [HttpPost]
        public IHttpActionResult AgregarServicio(TR_servicio servicio)
        {
            var resultado = validaciones.AgregarServicio(servicio);
            if (resultado == "OK")
            {
                return Ok("Servicio registrado correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpDelete]
        public IHttpActionResult EliminarServicio(decimal id)
        {
            var resultado = validaciones.EliminarServicio(id);
            if (resultado == "OK")
            {
                return Ok("Servicio eliminado correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpPut]
        public IHttpActionResult ActualizarServicio(decimal id, TR_servicio servicio)
        {
            var resultado = validaciones.ActualizarServicio(id, servicio);
            if (resultado == "OK")
            {
                return Ok("Servicio eliminado correctamente");
            }
            return BadRequest(resultado); 
        }
    }
}
