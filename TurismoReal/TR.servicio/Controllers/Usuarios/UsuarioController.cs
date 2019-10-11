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
    public class UsuarioController : ApiController
    {
        ConexionEntities Conn = new ConexionEntities();
        Validaciones Validaciones = new Validaciones();
        
        [HttpGet]
        public IEnumerable<TR_Usuario> GetUsuario()
        {
            var list = Conn.Connection.USUARIO.Select(x=> new TR_Usuario { USUARIO1 = x.USUARIO1, CONTRASENA = x.CONTRASENA, ESTADO_DESCRIPCION = x.ESTADO.DESCRIPCION, TIPO_USUARIO_DESCRIPCION = x.TIPO_USUARIO.DESCRIPCION});


            return list.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetUsuario(string id)
        {
            var result = Conn.Connection.USUARIO.FirstOrDefault(x=>x.USUARIO1 == id);

            if (result != null)
            {
                if (!Validaciones.ValidateEmpty(result.USUARIO1))
                {
                    TR_Usuario usuario = new TR_Usuario
                    {
                        USUARIO1 = result.USUARIO1,
                        TIPO_USUARIO_DESCRIPCION = result.TIPO_USUARIO.DESCRIPCION,
                        ESTADO_ENTIDAD = result.ESTADO.ENTIDAD,
                        ESTADO_DESCRIPCION = result.ESTADO.DESCRIPCION,
                        CONTRASENA = result.CONTRASENA
                    };
                    return Ok(usuario);
                }
                return BadRequest("El run no debe tener espacios en blancos"); 
            }
            return BadRequest("El run ingresado en la plataforma no se encuentraregistrado");
        }

        [HttpPost]
        public IHttpActionResult PostUsuario(TR.dato.USUARIO usuario)
        {
            if (ModelState.IsValid)
            {
                if (UserExists(usuario.USUARIO1))
                {
                    if (!Validaciones.ValidateEmpty(usuario.USUARIO1) && !Validaciones.ValidateEmpty(usuario.CONTRASENA))
                    {
                        Conn.Connection.USUARIO.Add(usuario);
                        Conn.Connection.SaveChanges();
                        return Ok("Usuario registrado correctamente");
                    }
                    return BadRequest("Todos los campos deben estar completos");
                }
                return BadRequest("El run ingresado ya se encuentra registrado dentro de la base de datos");
            }
            return BadRequest("Ha ocurrido un error al momento de registrar un nuevo usuario");
        }

        [HttpDelete]
        public IHttpActionResult DeleteUsuario(string id)
        {
            var result = Conn.Connection.USUARIO.FirstOrDefault(x=>x.CONTRASENA == id);

            if (result != null)
            {
                Conn.Connection.USUARIO.Remove(result);
                Conn.Connection.SaveChanges();
                return Ok("Usuario eliminado correctamente");
            }
            return BadRequest("El run ingresado no se encuentra registrado dentro de la base de datos");
        }

        [HttpPut]
        public IHttpActionResult PutUsuario(string id, TR.dato.USUARIO usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Ha ocurrido un error al momento de actualizar al usuario. Por favor, intentelo más tarde");
            }
            if (id != usuario.USUARIO1)
            {
                return BadRequest("El run del usuario que desea actualizar no se encuentra registrado");
            }

            Conn.Connection.Entry(usuario).State = EntityState.Modified;

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

        private bool UserExists(string run)
        {
            var result = Conn.Connection.USUARIO.FirstOrDefault(x=>x.USUARIO1 == run);
            if (result == null)
            {
                return true;
            }
            return false;
        }
    }
}
