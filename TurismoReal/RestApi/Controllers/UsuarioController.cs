using RestApi.Models.TR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TR.Lógica;

namespace RestApi.Controllers
{
    public class UsuarioController : ApiController
    {
        private Entities db = new Entities();

        [HttpGet]
        public IEnumerable<Usuario> GetUsuario()
        {
            var list = db.USUARIO.ToList();
            List<Usuario> user = new List<Usuario>();

            foreach (var i in list)
            {
                Usuario usuario = new Usuario
                {
                    USUARIO1 = i.USUARIO1,
                    TIPO_USUARIO_CODIGO = i.TIPO_USUARIO_CODIGO,
                    ESTADO_ID = i.ESTADO_ID,
                    CONTRASENA = i.CONTRASENA
                };
                user.Add(usuario);
            }
            return user.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetUsuarioById(string id)
        {
            var data = db.USUARIO.FirstOrDefault(u=>u.USUARIO1 == id);

            if (data != null)
            {
                Usuario usuario = new Usuario
                {
                    CONTRASENA = data.CONTRASENA,
                    ESTADO_ID = data.ESTADO_ID,
                    TIPO_USUARIO_CODIGO = data.TIPO_USUARIO_CODIGO,
                    USUARIO1 = data.USUARIO1
                };

                return Ok(usuario);
            }
            return BadRequest();
        }

        [HttpPost]
        public IHttpActionResult PostUsuario(USUARIO usuario)
        {
            if (ModelState.IsValid)
            {
                db.USUARIO.Add(usuario);
                db.SaveChanges();
                return CreatedAtRoute("DefaultApi", new { id = usuario.USUARIO1}, usuario);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public IHttpActionResult PostLogin(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = db.USUARIO.FirstOrDefault(u => u.USUARIO1 == login.USUARIO && u.CONTRASENA == login.CONSTRASENA && u.ESTADO_ID == 1);

                if (result.TIPO_USUARIO_CODIGO == "1")
                {
                    return Ok("USUARIO ADMIN");
                }
                if (result.TIPO_USUARIO_CODIGO == "2")
                {
                    return Ok("USUARIO CLIENTE");
                }
                if (result.TIPO_USUARIO_CODIGO == "2")
                {
                    return Ok("USUARIO EMPLEADO");
                }

            }
            return BadRequest("Usuario no encontrado");   
        }

        [HttpDelete]
        public IHttpActionResult DeleteUsuario(string id)
        {
            var DATA = db.USUARIO.FirstOrDefault(u=>u.USUARIO1 == id);

            if (DATA == null)
            {
                return BadRequest();
            }

            db.USUARIO.Remove(DATA);
            db.SaveChanges();
            return Ok(DATA.USUARIO1 + "Eliminado correctamente");
        }

        [HttpPut]
        public IHttpActionResult PutUsuario(string id, USUARIO usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.USUARIO1)
            {
                return BadRequest();
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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

            return StatusCode(HttpStatusCode.NoContent);
        }

        private bool userExists(string id)
        {
            return db.USUARIO.Count(e => e.USUARIO1 == id) > 0;
        }
    }
}
