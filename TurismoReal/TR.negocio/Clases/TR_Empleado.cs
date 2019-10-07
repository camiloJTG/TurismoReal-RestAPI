using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases
{
    public class TR_Empleado
    {
        public string RUN_EMPLEADO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public string TELEFONO { get; set; }
        public string EMAIL { get; set; }
        public string DIRECCION { get; set; }
        public Nullable<System.DateTime> FECHA_NACIMIENTO { get; set; }
        public string CARGO { get; set; }
        public string COMUNA_NOMBRE { get; set; }
        public string SUCURSAL_DIRECCION { get; set; }
        public string SUCURSAL_TELEFONO { get; set; }
        public string USUARIO_RUN { get; set; }
        public string USUARIO_CONTRASENA { get; set; }
        public string TIPO_USUARIO_DESCRIPCION { get; set; }
        public string ESTADO_ENTIDAD { get; set; }
        public string ESTADO_DESCRIPCION { get; set; }

    }
}
