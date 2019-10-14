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
    public class InventarioController : ApiController
    {
        private ConexionEntities con = new ConexionEntities();
        private Validaciones validaciones = new Validaciones();

        [HttpGet]
        public IEnumerable<TR_Inventario>GetInventario()
        {
            var list = con.Connection.INVENTARIO.Select(x=> new TR_Inventario {
                DESCRIPCION = x.DESCRIPCION,
                INVENTARIO_ID = x.INVENTARIO_ID,
                NOMBRE = x.NOMBRE
            });
            return list.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetInventario(int id)
        {
            var result = con.Connection.INVENTARIO.Where(x=>x.INVENTARIO_ID == id).Select(x=> new TR_Inventario {
                INVENTARIO_ID = x.INVENTARIO_ID,
                DESCRIPCION = x.DESCRIPCION,
                NOMBRE = x.NOMBRE
            });

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("El código del inventario ingresado no se encuentra registrado en el sistema");
        }

        [HttpPost]
        public IHttpActionResult PostInventario(TR.dato.INVENTARIO inventario)
        {
            try
            {
                if (UserExists(inventario.INVENTARIO_ID))
                {
                    var val1 = validaciones.ValidateEmpty(inventario.DESCRIPCION);
                    var val2 = validaciones.ValidateEmpty(inventario.NOMBRE);

                    if (!val1 && !val2)
                    {
                        con.Connection.INVENTARIO.Add(inventario);
                        con.Connection.SaveChanges();
                        return Ok("Inventario registrado correctamente");
                    }
                    return BadRequest("Todos los campos deben estar completos");
                }
                return BadRequest("El códgio ingresado ya se encuentra registrado");
            }
            catch (Exception)
            {
                return BadRequest("Se ha producido un error al momento de ingresar un nuevo inventario");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteInventario(int id)
        {
            var result = con.Connection.INVENTARIO.FirstOrDefault(x=>x.INVENTARIO_ID == id);

            if (result != null)
            {
                con.Connection.INVENTARIO.Remove(result);
                con.Connection.SaveChanges();
                return Ok("Inventario eliminado correctamente");
            }
            return BadRequest("El código ingresado no se encuentra registrado en el sistema");
        }

        [HttpPut]
        public IHttpActionResult PutUsuario(int id, TR.dato.INVENTARIO inventario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Ha ocurrido un error al momento de actualizar el inventario. Por favor, intentelo más tarde");
            }
            if (id != inventario.INVENTARIO_ID)
            {
                return BadRequest("El código del inventario que desea actualizar no se encuentra registrado");
            }

            con.Connection.Entry(inventario).State = EntityState.Modified;

            try
            {
                con.Connection.SaveChanges();
                return Ok("Inventario actualizado correctamente");
            }
            catch (DbUpdateConcurrencyException)
            {

                return BadRequest("Error al momento de actualizar el inventario");
            }
        }

        private bool UserExists(decimal id)
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
