using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases;
using TR.negocio.Validaciones.Estáticos;

namespace TR.servicio.Controllers.Estáticos
{
    public class ComunaController : ApiController
    {
        private Val_comuna validaciones = new Val_comuna();

        [HttpGet]
        public IEnumerable<TR_comuna> ListadoComuna()
        {
            var resultado = validaciones.LIstadoComuna();
            return resultado.ToList();
        }

        [HttpGet]
        public IHttpActionResult BuscarComuna(int id)
        {
            var resultado = validaciones.BuscarComuna(id);
            if (resultado != null)
            {
                return Ok(resultado);
            }
            return BadRequest("El código ingresado no arrojó resultados");
        }

        [HttpPost]
        public IHttpActionResult AgregarComuna(TR_comuna comuna)
        {
            var resultado = validaciones.AgregarComuna(comuna);
            if (resultado == "OK")
            {
                return Ok("Comuna registrada correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpDelete]
        public IHttpActionResult EliminarComuna(int id)
        {
            var resultado = validaciones.EliminarComuna(id);
            if (resultado == "OK")
            {
                return Ok("Comuna eliminada correctamente");
            }
            return BadRequest(resultado);
        }

        [HttpPut]
        public IHttpActionResult ActualizarComuna(int id, TR_comuna comuna)
        {
            var resultado = validaciones.ActualizarComuna(id, comuna);
            if (resultado == "OK")
            {
                return Ok("Comuna actualizada correctamente");
            }
            return BadRequest(resultado);
        }

    }
}
