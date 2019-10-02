using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.logica.Clases;
using TR.logica.Conexion;

namespace TR.servicio.Controllers
{
    public class UserController : ApiController
    {
        private Conexion c = new Conexion();

        [HttpGet]
        public IEnumerable<Usuario> GetUsers()
        {
            var list = c.Connection.USUARIO.ToList();
            List<Usuario> usuarios = new List<Usuario>();

            foreach (var i in list)
            {
                Usuario u = new Usuario
                {
                    CONTRASENA = i.CONTRASENA,
                    ESTADO_ID = i.ESTADO_ID,
                    TIPO_USUARIO_CODIGO = i.TIPO_USUARIO_CODIGO,
                    USUARIO1 = i.USUARIO1
                };
                usuarios.Add(u);
            }
            return usuarios.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetUser(string id)
        {
            var data = c.Connection.USUARIO.FirstOrDefault(us=>us.USUARIO1 == id);

            Usuario u = new Usuario
            {
                CONTRASENA = data.CONTRASENA,
                USUARIO1 = data.USUARIO1,
                ESTADO_ID = data.ESTADO_ID,
                TIPO_USUARIO_CODIGO = data.TIPO_USUARIO_CODIGO
            };

            if (data != null)
            {
                return Ok(u);
            }
            return BadRequest();
        }

        [HttpPost]
        public IHttpActionResult PostUser(dato.TR.USUARIO user)
        {
            if (ModelState.IsValid)
            {

                c.Connection.USUARIO.Add(user);
                c.Connection.SaveChanges();
                return Ok("User saved successfully");
            }
            return BadRequest("An error has occurred");
        }

        [HttpDelete]
        public IHttpActionResult DeleteUser(string id)
        {

            var result = c.Connection.USUARIO.FirstOrDefault(x => x.USUARIO1 == id);

            if (result != null)
            {
                c.Connection.USUARIO.Remove(result);
                c.Connection.SaveChanges();
                return Ok("user deleted successfully");
            }
            return BadRequest("An error has ocurred");
        }
        [HttpPut]
        public IHttpActionResult PutUsuario(string id, dato.TR.USUARIO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.USUARIO1)
            {
                return BadRequest();
            }

            c.Connection.Entry(user).State = EntityState.Modified;

            try
            {
                c.Connection.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return BadRequest("User not found");
                }
                else
                {
                    return Ok("User modified");
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool UserExists(string id)
        {
            return c.Connection.USUARIO.Count(e => e.USUARIO1 == id) > 0;
        }
    }
}
