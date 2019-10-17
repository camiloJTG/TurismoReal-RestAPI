using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases;
using TR.negocio.Conexión;
using TR.negocio.Validaciones;

namespace TR.servicio.Controllers.Previos
{
    public class ComunaController : ApiController
    {
        private ConexionEntities conexion = new ConexionEntities();
        private Validaciones validaciones = new Validaciones();

        [HttpGet]
        public IEnumerable<TR_Comuna> GetComuna()
        {
            var list = conexion.Connection.COMUNA.Select(x=> new TR_Comuna {
                    COMUNA_ID = x.COMUNA_ID,
                    NOMBRE_COMUNA = x.NOMBRE_COMUNA,
                    PROVINCIA_ID = x.PROVINCIA_ID
            });
            return list.ToList();
        }
    }
}
