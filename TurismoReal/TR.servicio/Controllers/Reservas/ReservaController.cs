using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases;
using TR.negocio.Conexión;
using TR.negocio.Validaciones;

namespace TR.servicio.Controllers.Reservas
{
    public class ReservaController : ApiController
    {
        private ConexionEntities Conn = new ConexionEntities();
        private Validaciones validaciones = new Validaciones();

        [HttpGet]
        public IEnumerable<TR_Reserva> GetReserva()
        {
            var list = Conn.Connection.RESERVA.ToList();
            List<TR_Reserva> listReserva = new List<TR_Reserva>();

            foreach (var i in list)
            {
                TR_Reserva r = new TR_Reserva
                {
                    ESTADO_ID = i.ESTADO_ID,
                    FECHA_HORA_ACTUALIZACION = i.FECHA_HORA_ACTUALIZACION,
                    FECHA_HORA_RESERVA = i.FECHA_HORA_RESERVA,
                    RESERVA_ID = i.RESERVA_ID
                };
                listReserva.Add(r);
            }
            return listReserva.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetReserva(int id)
        {
            var result = Conn.Connection.RESERVA.FirstOrDefault(x=>x.RESERVA_ID == id);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("El id de la reserva no es válido");
        }
    }
}