using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases.Listado
{
    public class TR_listadoCliente
    {
        //datos usuario
        public string CONTRASENA { get; set; }
        public string TIPO_USUARIO_DESCRIPCION { get; set; }
        public string ESTADO_DESCRIPCION { get; set; }

        //datos cliente
        public string RUN_CLIENTE { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public string TELEFONO { get; set; }
        public string EMAIL { get; set; }
        public Nullable<System.DateTime> FECHA_NACIMIENTO { get; set; }
        public string DIRECCION { get; set; }
        public decimal COMUNA_ID { get; set; }
        public decimal ESTADO_ID { get; set; }

        //datos adicionales
        public string COMUNA_NOMBRE { get; set; }
    }
}
