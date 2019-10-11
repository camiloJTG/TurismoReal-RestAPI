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

namespace TR.servicio.Controllers.Productos
{
    public class TourController : ApiController
    {
        private ConexionEntities con = new ConexionEntities();
        private Validaciones validaciones = new Validaciones();

        [HttpGet]
        public IEnumerable<TR_Tour> GetTour()
        {
            var list = con.Connection.TOUR.Select(x=>new TR_Tour {
                ITINERARIO_TOUR = x.ITINERARIO_TOUR,
                NOMBRE_TOUR = x.NOMBRE_TOUR,
                TOUR_ID = x.TOUR_ID,
                VALOR_TOUR = x.VALOR_TOUR
            });
            return list.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetTour(int id)
        {
            var result = con.Connection.TOUR.Where(x => x.TOUR_ID == id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("El código ingresado no se encuentra registrado dentro de la plataforma");
        }

        [HttpPost]
        public IHttpActionResult PostTour(TR.dato.TOUR tour)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (UserExists(tour.TOUR_ID))
                    {
                        var val1 = validaciones.ValidateEmpty(tour.ITINERARIO_TOUR);
                        var val2 = validaciones.ValidateEmpty(tour.NOMBRE_TOUR);

                        if (!val1 && !val2)
                        {
                            con.Connection.TOUR.Add(tour);
                            con.Connection.SaveChanges();
                            return Ok("Tour registrado correctamente");
                        }
                        return BadRequest("Todos los campos deben estar completos");
                    }
                    return BadRequest("El código del tour ya se encuentra registrado");
                }
                return BadRequest("El modelo de clase establecido no coincide con el del servicio");
            }
            catch (Exception)
            {

                return BadRequest("Ha ocurrido un error al momento de ingresar un nuevo tour. Por favor, verifique que todos los campos estén completos");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteTour(int id)
        {
            var result = con.Connection.TOUR.FirstOrDefault(x=>x.TOUR_ID == id);

            if (result != null)
            {
                con.Connection.TOUR.Remove(result);
                con.Connection.SaveChanges();
                return Ok("Tour eliminado correctamente");
            }
            return BadRequest("El ccódigo ingresado no existe dentro de la plataforma");
        }

        [HttpPut]
        public IHttpActionResult PutUsuario(int id, TR.dato.TOUR tour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Ha ocurrido un error al momento de actualizar el tour. Por favor, intentelo más tarde");
            }
            if (id != tour.TOUR_ID)
            {
                return BadRequest("El códgio del tour que desea actualizar no se encuentra registrado");
            }

            con.Connection.Entry(tour).State = EntityState.Modified;

            try
            {
                con.Connection.SaveChanges();
                return Ok("tour actualizado correctamente");
            }
            catch (DbUpdateConcurrencyException)
            {

                return BadRequest("Error al momento de actualizar el tour");
            }
        }

        private bool UserExists(decimal id)
        {
            var result = con.Connection.TOUR.FirstOrDefault(x => x.TOUR_ID == id);
            if (result == null)
            {
                return true;
            }
            return false;
        }
    }
}
