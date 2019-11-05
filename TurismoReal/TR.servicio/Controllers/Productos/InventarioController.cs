using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases.Productos;
using TR.negocio.Validaciones.Productos;

namespace TR.servicio.Controllers.Productos
{
    public class InventarioController : ApiController
    {
        private Val_inventario validaciones = new Val_inventario();

        [HttpGet]
        public IEnumerable<TR_inventario> ListarInventario()
        {
            var listado = validaciones.ListarInventario();
            return listado.ToList();
        }

        [HttpGet]
        public IHttpActionResult BuscarInventario(decimal id)
        {
            var resultado = validaciones.BuscarInventario(id);
            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("El código ingresado no arrojó resultados");
        }

        [HttpPost]
        public IHttpActionResult RegistrarInventario(TR_inventario inventario)
        {
            var resultado = validaciones.AgregarInventario(inventario);
            if (resultado == "OK")
            {
                return Ok("Inventario registrado correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpDelete]
        public IHttpActionResult EliminarInventario(decimal id)
        {
            var resultado = validaciones.EliminarInventario(id);
            if (resultado == "OK")
            {
                return Ok("Inventario eliminado correctamente");
            }
            return BadRequest(resultado);
        } 

        [HttpPut]
        public IHttpActionResult ActualizarInventario(decimal id, TR_inventario inventario)
        {
            var resultado = validaciones.ActualizarInventario(id, inventario);
            if (resultado == "OK")
            {
                return Ok("Inventario actualziado correctamente");
            }
            return BadRequest(resultado);
        }
    }
}
