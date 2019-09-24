using RestApi.Models.TR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.Lógica;

namespace RestApi.Controllers
{
    public class ClienteController : ApiController
    {
        private Entities db = new Entities();

        [HttpGet]
        public IEnumerable<Cliente> GetCliente()
        {
            var list = db.CLIENTE.ToList();
            List<Cliente> cli = new List<Cliente>();

            foreach (var i in list)
            {
                Cliente cliente = new Cliente
                {
                    APELLIDO_MATERNO = i.APELLIDO_MATERNO,
                    APELLIDO_PATERNO = i.APELLIDO_PATERNO,
                    DIRECCION = i.DIRECCION,
                    EMAIL = i.EMAIL,
                    FECHA_NACIMIENTO = i.FECHA_NACIMIENTO,
                    NOMBRE = i.NOMBRE,
                    TELEFONO = i.TELEFONO,
                    RUN_CLIENTE = i.RUN_CLIENTE,
                    USUARIO = i.USUARIO,
                    ESTADO_ID = i.ESTADO_ID,
                    COMUNA_ID = i.COMUNA_ID,
                    NOMBRE_COMUNA = i.COMUNA.NOMBRE_COMUNA,
                };
                cli.Add(cliente);
            }
            return cli.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetClienteById(string id)
        {
            var result = db.CLIENTE.FirstOrDefault(c=>c.RUN_CLIENTE == id);

            if (result != null)
            {
                Cliente cliente = new Cliente
                {
                    APELLIDO_MATERNO = result.APELLIDO_MATERNO,
                    APELLIDO_PATERNO = result.APELLIDO_PATERNO,
                    DIRECCION = result.DIRECCION,
                    EMAIL = result.EMAIL,
                    FECHA_NACIMIENTO = result.FECHA_NACIMIENTO,
                    NOMBRE = result.NOMBRE,
                    TELEFONO = result.TELEFONO,
                    RUN_CLIENTE = result.RUN_CLIENTE,
                    USUARIO = result.USUARIO,
                    ESTADO_ID = result.ESTADO_ID,
                    COMUNA_ID = result.COMUNA_ID,
                    NOMBRE_COMUNA = result.COMUNA.NOMBRE_COMUNA,
                };
                return Ok(cliente);
            }
            return BadRequest();
        }

        [HttpPost]
        public IHttpActionResult POSTCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario
                {
                    CONTRASENA = cliente.USUARIO1.CONTRASENA,
                    USUARIO1 = cliente.USUARIO1.USUARIO1,
                    ESTADO_ID = cliente.USUARIO1.ESTADO_ID,
                    TIPO_USUARIO_CODIGO = cliente.USUARIO1.TIPO_USUARIO_CODIGO
                };

                Cliente cli = new Cliente
                {
                    APELLIDO_MATERNO = cliente.APELLIDO_MATERNO,
                    APELLIDO_PATERNO = cliente.APELLIDO_PATERNO,
                    COMUNA_ID = cliente.COMUNA_ID,
                    DIRECCION = cliente.DIRECCION,
                    EMAIL = cliente.EMAIL,
                    FECHA_NACIMIENTO = cliente.FECHA_NACIMIENTO,
                    NOMBRE = cliente.NOMBRE,
                    RUN_CLIENTE = cliente.RUN_CLIENTE,
                    TELEFONO = cliente.TELEFONO,
                    ESTADO_ID = cliente.ESTADO_ID,
                    USUARIO = cliente.USUARIO,
                    USUARIO1 = cliente.USUARIO1,
                    NOMBRE_COMUNA = cliente.NOMBRE_COMUNA,
                    COMUNA = cliente.COMUNA
                };

                return Ok(cli);
            }
            return BadRequest();
        }
    }
}
