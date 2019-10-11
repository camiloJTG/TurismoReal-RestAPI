using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases
{
    public class TR_Departamento
    {
        public decimal DEPARTAMENTO_ID { get; set; }
        public Nullable<decimal> VALOR { get; set; }
        public string NOMBRE { get; set; }
        public string DIRECCION { get; set; }
        public string SUPERFICIE { get; set; }
        public string CONDICIONES_USO { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION { get; set; }

        // datos de la comuna
        public string COMUNA_NOMBRE { get; set; }
        public decimal COMUNA_ID { get; set; }

        //dato del estado del departamento
        public decimal ESTADO_ID { get; set; }
        public string ESTADO_ENTIDAD { get; set; }
        public string ESTADO_DESCRIPCION { get; set; }
    }
}
