using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases.Listado;
using TR.negocio.Clases.Usuarios;
using TR.negocio.Validaciones.Usuarios;

namespace TR.servicio.Controllers.Usuarios
{
    public class ClienteController : ApiController
    {
        private readonly Val_cliente validaciones = new Val_cliente();

        [HttpGet]
        public IEnumerable<TR_listadoCliente> ListarCliente()
        {
            var resultado = validaciones.ListaCliente();
            return resultado.ToList();
        }

        [HttpGet]
        public IHttpActionResult BuscarCliente(string id)
        {
            var resultado = validaciones.BuscarCliente(id);
            if (resultado != null)
            {
                return Ok(resultado); ;
            }
            return BadRequest("El run ingresado no arrojó resultados");
        }

        [HttpPost]
        public IHttpActionResult AgregarCliente(TR_cliente cliente)
        {
            var resultado = validaciones.AgregarCliente(cliente);
            if (resultado == "OK")
            {
                return Ok("Cliente registrado correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpDelete]
        public IHttpActionResult EliminarCliente(string id)
        {
            var resultado = validaciones.EliminarCliente(id);
            if (resultado == "OK")
            {
                return Ok("Cliente eliminado correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpPut]
        public IHttpActionResult ActualizarCliente(string id, TR_cliente cliente)
        {
            var resultado = validaciones.ActualizarCliente(id, cliente);
            if (resultado == "OK")
            {
                return Ok("Cliente actualizado correctamente");
            }
            return BadRequest(resultado);
        }
    }
}
