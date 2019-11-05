using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases.Reserva;
using TR.negocio.Validaciones;

namespace TR.servicio.Controllers.Reservas
{
    public class FacturaController : ApiController
    {
        private Val_factura validaciones = new Val_factura();

        [HttpGet]
        public IEnumerable<TR_factura> ListarFactura()
        {
            var listado = validaciones.ListarFactura();
            return listado.ToList();
        }

        [HttpGet]
        public IHttpActionResult BuscarFactura(decimal id)
        {
            var resultado = validaciones.BuscarFactura(id);
            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("El código de la factura no aarojó resultado");
        }

        [HttpPost]
        public IHttpActionResult AgregarFactura(TR_factura factura)
        {
            var resultado = validaciones.AgregarFactura(factura);
            if (resultado == "OK")
            {
                return Ok("Factura registrada correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpDelete]
        public IHttpActionResult EliminarFactura(decimal id)
        {
            var resultado = validaciones.EliminarFactura(id);
            if (resultado == "OK")
            {
                return Ok("Factura eliminada correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpPut]
        public IHttpActionResult ActualizarFactura(decimal id, TR_factura factura)
        {
            var resultado = validaciones.ActualizarFactura(id, factura);
            if (resultado == "OK")
            {
                return Ok("Factura actualizada correctamente");
            }
            return BadRequest(resultado);
        }

    }
}
