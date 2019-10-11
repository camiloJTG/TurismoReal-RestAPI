using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Conexión;
using TR.negocio.Validaciones;

namespace TR.servicio.Controllers.Reservas
{
    public class DetalleReservaController : ApiController
    {
        private ConexionEntities con = new ConexionEntities();
        private Validaciones validaciones = new Validaciones();

        [HttpPost]
        public IHttpActionResult PostDetalleReserva(TR.dato.DETALLE_RESERVA reserva)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    con.Connection.DETALLE_RESERVA.Add(reserva);
                    con.Connection.SaveChanges();
                    return Ok("");
                }
                return BadRequest("el modelo establecido no es correcto");
            }
            catch (Exception)
            {

                return BadRequest("Ha ocurrido un error al momento de ingresar una nuevo detalle de reseva");
            }
        }

        public IHttpActionResult DeleteDetalle(decimal id)
        {
            var result = con.Connection.DETALLE_RESERVA.FirstOrDefault(x=>x.DETALLE_RESERVA_ID == id);

            if (result != null)
            {
                con.Connection.DETALLE_RESERVA.Remove(result);
                con.Connection.SaveChanges();
                return Ok("Detalle eliminado correctamente");
            }
            return BadRequest("El código ingresado no se encuentra registrado dentro de la plataforma");
        }
    }
}
