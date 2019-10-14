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
    public class ServicioController : ApiController
    {
        private ConexionEntities con = new ConexionEntities();
        private Validaciones validaciones = new Validaciones();

        [HttpGet]
        public IEnumerable<TR_Servicio>GetServicio()
        {
            var list = con.Connection.SERVICIO.Select(x=> new TR_Servicio {
                COSTO = x.COSTO,
                DESCRIPCION = x.DESCRIPCION,
                NOMBRE = x.NOMBRE,
                SERVICIO_ID = x.SERVICIO_ID
            });
            return list.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetServicios(int id)
        {
            var result = con.Connection.SERVICIO.Where(x=>x.SERVICIO_ID == id).Select(x=> new TR_Servicio {
               SERVICIO_ID = x.SERVICIO_ID,
               COSTO = x.COSTO,
               DESCRIPCION = x.DESCRIPCION,
               NOMBRE = x.NOMBRE
            });

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("El código ingresado para eliminar un servicio no se encuentra registrado en la base de datos");
        }

        [HttpPost]
        public IHttpActionResult PostServicios(TR.dato.SERVICIO servicio)
        {
            try
            {
                var val1 = validaciones.ValidateEmpty(servicio.DESCRIPCION);
                var val2 = validaciones.ValidateEmpty(servicio.NOMBRE);

                if (!val1 && !val2)
                {
                    if (UserExists(servicio.SERVICIO_ID))
                    {
                        con.Connection.SERVICIO.Add(servicio);
                        con.Connection.SaveChanges();
                        return Ok("Servicio registrado exitosamente");
                    }
                    return BadRequest("El código ingresado ya se encuentra registrado");
                }
                return BadRequest("Todos los campos deben estar completos");
            }
            catch (Exception)
            {

                return BadRequest("Ha ocurrido un error al momento de ingresar un nuevo servicio. Por favor, intentelo más tarde");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteServicio(int id)
        {
            var result = con.Connection.SERVICIO.FirstOrDefault(x=>x.SERVICIO_ID == id);

            if (result != null)
            {
                con.Connection.SERVICIO.Remove(result);
                con.Connection.SaveChanges();
                return Ok("Servicio eliminado correctamente");
            }
            return BadRequest("El código ingresado no se encuentra registrado en el sistema");
        }

        [HttpPut]
        public IHttpActionResult PutUsuario(int id, TR.dato.SERVICIO servicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Ha ocurrido un error al momento de actualizar el servicio. Por favor, intentelo más tarde");
            }
            if (id != servicio.SERVICIO_ID)
            {
                return BadRequest("El código del servicio que desea actualizar no se encuentra registrado");
            }

            con.Connection.Entry(servicio).State = EntityState.Modified;

            try
            {
                con.Connection.SaveChanges();
                return Ok("Servicio actualizado correctamente");
            }
            catch (DbUpdateConcurrencyException)
            {

                return BadRequest("Error al momento de actualizar el servicio");
            }
        }

        private bool UserExists(decimal id)
        {
            var result = con.Connection.SERVICIO.FirstOrDefault(x => x.SERVICIO_ID == id);
            if (result == null)
            {
                return true;
            }
            return false;
        }
    }
}
