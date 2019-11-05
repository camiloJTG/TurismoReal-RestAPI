using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases.Productos
{
    public class TR_departamento
    {
        public Nullable<decimal> VALOR { get; set; }
        public string NOMBRE { get; set; }
        public string DIRECCION { get; set; }
        public decimal COMUNA_ID { get; set; }
        public string SUPERFICIE { get; set; }
        public string CONDICIONES_USO { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION { get; set; }
        public decimal ESTADO_ID { get; set; }
    }
}
