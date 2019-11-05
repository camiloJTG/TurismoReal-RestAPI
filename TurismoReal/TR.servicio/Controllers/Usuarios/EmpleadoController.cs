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
    public class EmpleadoController : ApiController
    {
        private Val_empleado validaciones = new Val_empleado();

        [HttpGet]
        public IEnumerable<TR_listadoEmpleado> ListarEmpleado()
        {
            var resultado = validaciones.ListadoEmpleado();
            return resultado.ToList();
        }

        [HttpGet]
        public IHttpActionResult BuscarEmpleado(string id)
        {
            var resultado = validaciones.BuscarEmpleado(id);
            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("El run ingresado no arrojó resultados");
        }

        [HttpPost]
        public IHttpActionResult AgregarEmpleado(TR_empleado empleado)
        {
            var resultado = validaciones.AgregarEmpleado(empleado);
            if (resultado == "OK")
            {
                return Ok("Empleado registrado correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpDelete]
        public IHttpActionResult EliminarEmpleado(string id)
        {
            var resultado = validaciones.EliminarEmpleado(id);
            if (resultado == "OK")
            {
                return Ok("Empleado eliminado correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpPut]
        public IHttpActionResult ActualizarEmpleado(string id, TR_empleado empleado)
        {
            var resultado = validaciones.ActualizarEmpleado(id, empleado);
            if (resultado == "OK")
            {
                return Ok("Empleado actualizado correctamente");
            }
            return BadRequest(resultado);
        }
    }
}
