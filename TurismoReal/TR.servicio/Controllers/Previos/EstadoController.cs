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

namespace TR.servicio.Controllers
{
    public class EstadoController : ApiController
    {
        private ConexionEntities Conn = new ConexionEntities();
        private Validaciones Validaciones = new Validaciones();

        [HttpGet]
        public IEnumerable<TR_Estado> GetEstado()
        {
            var list = Conn.Connection.ESTADO.ToList();
            List<TR_Estado> ListEstado = new List<TR_Estado>();

            foreach (var i in list)
            {
                TR_Estado Est = new TR_Estado
                {
                    ESTADO_ID = i.ESTADO_ID,
                    ENTIDAD = i.ENTIDAD,
                    DESCRIPCION = i.DESCRIPCION
                };
                ListEstado.Add(Est);
            }
            return ListEstado.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetEstado(int id)
        {
            var result = Conn.Connection.ESTADO.FirstOrDefault(x=>x.ESTADO_ID == id);

            if (result != null)
            {
                TR_Estado estado = new TR_Estado();
                estado.DESCRIPCION = result.DESCRIPCION;
                estado.ENTIDAD = result.ENTIDAD;
                estado.ESTADO_ID = result.ESTADO_ID;

                return Ok(estado);
            }
            return BadRequest("El Código ingresado dentro del estado no se encuentra registrado");
        }

        [HttpPost]
        public IHttpActionResult PostEstado(TR.dato.ESTADO estado)
        {
            if (ModelState.IsValid)
            {
                if (Validaciones.ValidateEmpty(estado.DESCRIPCION) && Validaciones.ValidateEmpty(estado.ENTIDAD))
                {
                    return BadRequest("Todos los campos deben estar completos");
                }
                Conn.Connection.ESTADO.Add(estado);
                Conn.Connection.SaveChanges();
                return Ok("Estado guardado correctamente");
            }
            return BadRequest("Error al momento de ingresar un nuevo estado dentro del sistema. Por favor, intentelo más tarde");
        }

        [HttpDelete]
        public IHttpActionResult DeleteEstado(int id)
        {
            var result = Conn.Connection.ESTADO.FirstOrDefault(x=>x.ESTADO_ID == id);

            if (result != null)
            {
                Conn.Connection.ESTADO.Remove(result);
                Conn.Connection.SaveChanges();
                return Ok("Estado eliminado correctamente");
            }
            return BadRequest("El código ingresado para la eliminación de un estado no es correcto. Por favor, intentelo nuevamente");
        }

        [HttpPut]
        public IHttpActionResult PutEstado(int id, TR.dato.ESTADO estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Ha ocurrido un error al momento de actualizar el estado. Por favor, intentelo más tarde");
            }
            if (id != estado.ESTADO_ID)
            {
                return BadRequest("El código del estado que desea actualizar no se encuentra registrado");
            }

            Conn.Connection.Entry(estado).State = EntityState.Modified;

            try
            {
                Conn.Connection.SaveChanges();
                return Ok("Estado actualizado correctamente");
            }
            catch (DbUpdateConcurrencyException)
            {

                return BadRequest("Error al mmento de actualizar un estado");
            }
        }
    }
}
