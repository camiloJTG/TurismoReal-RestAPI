using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases
{
    public class TR_Servicio
    {
        public decimal SERVICIO_ID { get; set; }
        public string NOMBRE { get; set; }
        public Nullable<decimal> COSTO { get; set; }
        public string DESCRIPCION { get; set; }
    }
}
