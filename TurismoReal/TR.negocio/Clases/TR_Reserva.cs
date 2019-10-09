using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases
{
    public class TR_Reserva
    {
        public decimal RESERVA_ID { get; set; }
        public decimal ESTADO_ID { get; set; }
        public Nullable<System.DateTime> FECHA_HORA_RESERVA { get; set; }
        public Nullable<System.DateTime> FECHA_HORA_ACTUALIZACION { get; set; }
    }
}
