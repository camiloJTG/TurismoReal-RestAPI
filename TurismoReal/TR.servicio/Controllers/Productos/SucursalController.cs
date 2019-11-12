using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases.Listado;
using TR.negocio.Clases.Productos;

namespace TR.servicio.Controllers.Productos
{
    public class SucursalController : ApiController
    {
        private readonly TR_sucursal validaciones = new TR_sucursal();

        [HttpGet]
        public IEnumerable<TR_listadoSucursal> ListarSucursal()
        {
            var listado = validaciones.ListadoSucursal();
            return listado.ToList();
        }

        [HttpGet]
        public IHttpActionResult BuscarSucursal(decimal id)
        {
            var resultado = validaciones.BuscarSucursal(id);
            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("El número de la sucursal ingresada no arrojó resultados");
        }

        [HttpPost]
        public IHttpActionResult AgregarSucursal(TR_sucursal sucursal)
        {
            var resultado = validaciones.AgregarSucursal(sucursal);
            if (resultado == "OK")
            {
                return Ok("Sucursal registrada correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpDelete]
        public IHttpActionResult EliminarSucursal(decimal id)
        {
            var resultado = validaciones.EliminarSucursal(id);
            if (resultado == "OK")
            {
                return Ok("Sucursal eliminada correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpPut]
        public IHttpActionResult ActualizarSucursal(decimal id, TR_sucursal sucursal)
        {
            var resultado = validaciones.ActualizarSucursal(id, sucursal);
            if (resultado == "OK")
            {
                return Ok("Sucursal actualizada correctamente");
            }
            return BadRequest(resultado);
        }
    }
}
