using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases.Listado;
using TR.negocio.Clases.Productos;
using TR.negocio.Validaciones.Productos;

namespace TR.servicio.Controllers.Productos
{
    public class DepartamentoController : ApiController
    {
        private readonly Val_departamento validaciones = new Val_departamento();

        [HttpGet]
        public IEnumerable<TR_listadoDepartamento> LIstarDepartamento()
        {
            var listado = validaciones.ListarDepartamento();
            return listado.ToList();
        }

        [HttpGet]
        public IEnumerable<TR_listadoDepartamento> BuscarDepartamento(decimal id)
        {
            var resultado = validaciones.BuscarDepartamento(id);
            return resultado.ToList();
        }

        [HttpPost]
        public IHttpActionResult AgregarDepartamento(TR_departamento departamento)
        {
            var resultado = validaciones.AgregarDepartamento(departamento);
            if (resultado == "OK")
            {
                return Ok("Departamento registrado correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpDelete]
        public IHttpActionResult EliminarDepartamento(decimal id)
        {
            var resultado = validaciones.EliminarDepartamento(id);
            if (resultado == "OK")
            {
                return Ok("Departamento eliminiado correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpPut]
        public IHttpActionResult ActualizarDepartamento(decimal id, TR_departamento departamento)
        {
            var resultado = validaciones.ActualizarDepartamento(id, departamento);
            if (resultado == "OK")
            {
                return Ok("Departamento actualizado correctamente");
            }
            return BadRequest(resultado);
        }
    }
}
