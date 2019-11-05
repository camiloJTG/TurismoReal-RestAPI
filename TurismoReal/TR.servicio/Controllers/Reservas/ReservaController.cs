using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases.Listado;
using TR.negocio.Clases.Reservas;
using TR.negocio.Validaciones.Reservas;

namespace TR.servicio.Controllers.Reservas
{
    public class ReservaController : ApiController
    {
        private Val_reserva validaciones = new Val_reserva();

        [HttpGet]
        public IEnumerable<TR_listadoReserva> ListarReserva()
        {
            var resultado = validaciones.ListarReserva();
            return resultado.ToList();
        }

        [HttpGet]
        public IEnumerable<TR_listadoReserva> BuscarReserva(decimal id)
        {
            var resultado = validaciones.BuscarReserva(id);
            if (resultado != null)
            {
                return resultado;
            }
            return null;
        }

        [HttpPost]
        public IHttpActionResult AgregarReserva(TR_reserva reserva)
        {
            var resultado = validaciones.AgregarReserva(reserva);
            if (resultado == "OK")
            {
                return Ok("Reserva agreagada correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpDelete]
        public IHttpActionResult EliminarReserva(decimal id)
        {
            var resultado = validaciones.EliminarReserva(id);
            if (resultado == "OK")
            {
                return Ok("Reserva eliminada correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpPut]
        public IHttpActionResult ActualizarReserva(decimal id, TR_reserva reserva)
        {
            var resultado = validaciones.ActualizarReserva(id, reserva);
            if (resultado == "OK")
            {
                return Ok("Reserva actualizada correctamente");
            }
            return BadRequest(resultado);
        }
    }
}
