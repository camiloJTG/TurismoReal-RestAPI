using RestApi.Models.TR;
using System;
using System.Collections.Generic;
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

        //[HttpGet]
        //public IEnumerable<USUARIO> GetUsuario()
        //{
        //    var list = db.USUARIO.ToList();
        //    return list;
        //}

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
    }
}
