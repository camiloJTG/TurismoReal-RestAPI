using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases.Usuarios
{
    public class TR_empleado
    {
        //datos usuario 
        public string CONTRASENA { get; set; }
        public string TIPO_USUARIO_CODIGO { get; set; }

        //datos empleado
        public string RUN_EMPLEADO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public string TELEFONO { get; set; }
        public string EMAIL { get; set; }
        public string DIRECCION { get; set; }
        public Nullable<System.DateTime> FECHA_NACIMIENTO { get; set; }
        public string CARGO { get; set; }
        public decimal NUMERO_SUCURSAL { get; set; }
        public decimal COMUNA_ID { get; set; }
        public decimal ESTADO_ID { get; set; }

    }
}
