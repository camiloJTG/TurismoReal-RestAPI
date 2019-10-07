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
    public class TipoUsuarioController : ApiController
    {
        private ConexionEntities Conn = new ConexionEntities();
        private TR_TipoUsuario tu = new TR_TipoUsuario();
        private Validaciones Validaciones = new Validaciones();  

        //Listado de los tipos de usuarios existentes en el sistema 
        [HttpGet]
        public IEnumerable<TR_TipoUsuario> GetTipoUsuario()
        {
            var list = Conn.Connection.TIPO_USUARIO.ToList();
            List<TR_TipoUsuario> ListUsuario = new List<TR_TipoUsuario>();

            foreach (var i in list)
            {
                TR_TipoUsuario tu = new TR_TipoUsuario
                {
                    CODIGO = i.CODIGO,
                    DESCRIPCION = i.DESCRIPCION
                };
                ListUsuario.Add(tu);
            }
            return ListUsuario.ToList();
        }

        //servicio que permite mostrar datos de un tipo de usuario en específico
        [HttpGet]
        public IHttpActionResult GetTipoUsuario(string id)
        {
            var toUpper = id.ToUpper();
            var result = Conn.Connection.TIPO_USUARIO.FirstOrDefault(x=>x.CODIGO == toUpper);

            if (result != null)
            {
                TR_TipoUsuario tu = new TR_TipoUsuario
                {
                    CODIGO = result.CODIGO,
                    DESCRIPCION = result.DESCRIPCION
                };
                return Ok(tu);
            }
            return BadRequest("El código ingresado no es válido");
        }

        //Servicios que permite agregar nuevos tipos de usuarios al sistema
        [HttpPost]
        public IHttpActionResult PostTipoUsuario(TR.dato.TIPO_USUARIO usuario)
        {
            if (ModelState.IsValid)
            {
                if (Validaciones.ValidateEmpty(usuario.DESCRIPCION) == false)
                {
                    Conn.Connection.TIPO_USUARIO.Add(usuario);
                    Conn.Connection.SaveChanges();
                    return Ok("Tipo de usuario registrado correctamente");
                }
                return BadRequest("El tipo de usuario no puede estar vacío");
            }
            return BadRequest("Ha ocurrido un error al momento de registrar un nuevo tipo de usuario");
        }

        //Servicio que permite eliminar a un tipo de usuario
        [HttpDelete]
        public IHttpActionResult DeleteTipoUsuario(string id)
        {
            var result = Conn.Connection.TIPO_USUARIO.FirstOrDefault(x=>x.CODIGO == id);

            if (result != null)
            {
                Conn.Connection.TIPO_USUARIO.Remove(result);
                Conn.Connection.SaveChanges();
                return Ok("Tipo de usuario eliminado correctamente");
            }
            return BadRequest("El código ingresado no es válido");
        }

        //Servicios que permiten actualizar un registro existente
        [HttpPut]
        public IHttpActionResult PutTipoUsuario(string id, TR.dato.TIPO_USUARIO TipoUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Ha ocurrido un error al momento de realizar la modificación del tipo de usuario");
            }

            if (id.ToUpper() != TipoUsuario.CODIGO)
            {
                return BadRequest("El código ingresado no se encuentra registrado dentro del sistema");
            }

            Conn.Connection.Entry(TipoUsuario).State = EntityState.Modified;

            try
            {
                Conn.Connection.SaveChanges();
                return Ok("Tipo de usuario actualizado correctamente");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool userExists(string id)
        {
            return Conn.Connection.TIPO_USUARIO.Count(x=>x.CODIGO == id) > 0;
        }
    }
}
