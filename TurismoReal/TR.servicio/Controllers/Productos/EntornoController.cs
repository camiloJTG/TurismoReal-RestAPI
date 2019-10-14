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
    public class EntornoController : ApiController
    {
        private ConexionEntities con = new ConexionEntities();
        private Validaciones validaciones = new Validaciones();

        [HttpGet]
        public IEnumerable<TR_Entorno> GetEntorno()
        {
            var list = con.Connection.ENTORNO.Select(x=> new TR_Entorno {
                ENTORNO_ID = x.ENTORNO_ID,
                IMG = x.IMG,
                NOMBRE = x.NOMBRE
            });
            return list.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetEntorno(int id)
        {
            var result = con.Connection.ENTORNO.Where(x => x.ENTORNO_ID== id).Select(x=> new TR_Entorno{
                ENTORNO_ID = x.ENTORNO_ID,
                IMG = x.IMG
            });

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("El código del entorno ingreso no se encuentra registrado en el sistema");
        }

        [HttpPost]
        public IHttpActionResult PostEntorno(TR.dato.ENTORNO entorno)
        {
            try
            {
                if (userExist(entorno.ENTORNO_ID))
                {
                    var val1 = validaciones.ValidateEmpty(entorno.NOMBRE);
                    var val2 = validaciones.ValidateEmpty(entorno.IMG);

                    if (!val1 && !val2)
                    {
                        con.Connection.ENTORNO.Add(entorno);
                        con.Connection.SaveChanges();
                        return Ok("Entorno guardado correctamente");
                    }
                    return BadRequest("Todos los campos deben estar completos");
                }
                return BadRequest("El entorno ingresado ya se encuentra registrado");
            }
            catch (Exception)
            {
                return BadRequest("Ha ocurrido un error al momento de ingresar un nuevo inventario. Por favor, intentelo nuevamente");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteEntorno(int id)
        {
            var result = con.Connection.ENTORNO.FirstOrDefault(x=>x.ENTORNO_ID == id);

            if (result != null)
            {
                con.Connection.ENTORNO.Remove(result);
                con.Connection.SaveChanges();
                return Ok("Entorno eliminado correctamente");
            }
            return BadRequest("El código ingresado no se encuentra registrado en el sistema");
        }

        [HttpPut]
        public IHttpActionResult PutEntorno(int id, TR.dato.ENTORNO entorno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Ha ocurrido un error al momento de actualizar el entorno. Por favor, intentelo más tarde");
            }
            if (id != entorno.ENTORNO_ID)
            {
                return BadRequest("El código del entorno que desea actualizar no se encuentra registrado");
            }

            con.Connection.Entry(entorno).State = EntityState.Modified;

            try
            {
                con.Connection.SaveChanges();
                return Ok("Entorno actualizado correctamente");
            }
            catch (DbUpdateConcurrencyException)
            {

                return BadRequest("Error al momento de actualizar el entorno");
            }
        }

        private bool userExist(decimal id)
        {
            var result = con.Connection.INVENTARIO.FirstOrDefault(x => x.INVENTARIO_ID == id);
            if (result == null)
            {
                return true;
            }
            return false;
        }
    }
}
