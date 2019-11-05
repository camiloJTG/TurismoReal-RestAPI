using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases.Listado
{
    public class TR_listadoEmpleado
    {
        //datos usuarios
        public string CONTRASENA { get; set; }
        public string TIPO_USUARIO_DESCRIPCION { get; set; }
        public string ESTADO_DESCRIPCION { get; set; }

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

        //datos adicionales
        public string SUCURSAL_DIRRECCION { get; set; }
        public string COMUNA_NOMBRE { get; set; }
    }
}
