using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.Lógica
{
    public class Cliente
    {
        public string RUN_CLIENTE { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public string TELEFONO { get; set; }
        public string EMAIL { get; set; }
        public Nullable<System.DateTime> FECHA_NACIMIENTO { get; set; }
        public string DIRECCION { get; set; }
        public string USUARIO { get; set; }
        public decimal COMUNA_ID { get; set; }
        public decimal ESTADO_ID { get; set; }
        public string NOMBRE_COMUNA { get; set; }

        public virtual Comuna COMUNA { get; set; }
        //public virtual ESTADO ESTADO { get; set; }
        public virtual Usuario USUARIO1 { get; set; }

        //public virtual ESTADO ESTADO { get; set; }
        //public virtual USUARIO USUARIO1 { get; set; }
    }
}
