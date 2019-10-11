using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
            var list = Conn.Connection.RESERVA.Select(x=> new TR_Reserva {
                RESERVA_FECHA_HORA_ACTUALIZACION = x.FECHA_HORA_ACTUALIZACION,
                RESERVA_FECHA_HORA_RESERVA = x.FECHA_HORA_ACTUALIZACION,
                RESERVA_ID = x.RESERVA_ID
            });
            return list.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetReserva(int id)
        {
            var result = Conn.Connection.RESERVA.FirstOrDefault(x=>x.RESERVA_ID == id);

            if (result != null)
            {
                TR_Reserva reserva = new TR_Reserva
                {
                    ESTADO_DESCRIPCION = result.ESTADO_ID,
                    RESERVA_FECHA_HORA_ACTUALIZACION = result.FECHA_HORA_ACTUALIZACION,
                    RESERVA_FECHA_HORA_RESERVA = result.FECHA_HORA_RESERVA,
                    RESERVA_ID = result.RESERVA_ID
                };
                return Ok(reserva);
            }
            return BadRequest("El id de la reserva no es válido");
        }

        [HttpPost]
        public IHttpActionResult PostReserva(TR.dato.RESERVA reserva)
        {
            if (ModelState.IsValid)
            {
                Conn.Connection.RESERVA.Add(reserva);
                Conn.Connection.SaveChanges();
                return Ok("Reserva registrada correctamente");
            }
            return BadRequest("Ha ocurrido un error al momento de ingresar una nueva reserva");
        }

        [HttpDelete]
        public IHttpActionResult DeleteReserva(int id)
        {
            var result = Conn.Connection.RESERVA.FirstOrDefault(x=>x.RESERVA_ID == id);

            if (result != null)
            {
                Conn.Connection.RESERVA.Remove(result);
                Conn.Connection.SaveChanges();
                return Ok("Reserva eliminada correctamente");
            }
            return BadRequest("El código ingresado no es correcto");
        }

        [HttpPut]
        public IHttpActionResult PutUsuario(int id, TR.dato.RESERVA reserva)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Ha ocurrido un error al momento de actualizar la reserva. Por favor, intentelo más tarde");
            }
            if (id != reserva.RESERVA_ID)
            {
                return BadRequest("El código de la reserva que desea actualizar no se encuentra registrado");
            }

            Conn.Connection.Entry(reserva).State = EntityState.Modified;

            try
            {
                Conn.Connection.SaveChanges();
                return Ok("Usuario actualizado correctamente");
            }
            catch (DbUpdateConcurrencyException)
            {

                return BadRequest("Error al mmento de actualizar al usuario");
            }
        }
    }
}