using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases.Usuarios
{
    public class TR_usuario
    {
        public string TIPO_USUARIO_CODIGO { get; set; }
        public decimal ESTADO_ID { get; set; }

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
        public string CARGO { get; set; }
        public decimal NUMERO_SUCURSAL { get; set; }
    }
}
