using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases
{
    public class TR_Factura
    {
        public decimal NUMERO_FACTURA { get; set; }
        public Nullable<decimal> VALOR_NETO { get; set; }
        public Nullable<decimal> IVA { get; set; }
        public Nullable<decimal> TOTAL { get; set; }

        //datos de la reserva
        public Nullable<System.DateTime> RESERVA_FECHA_HORA_RESERVA { get; set; }
        public Nullable<System.DateTime> RESERVA_FECHA_HORA_ACTUALIZACION { get; set; }
        public decimal RESERVA_ID { get; set; }

        //datos del cliente
        public string CLIENTE_RUN { get; set; }
        public string CLIENTE_NOMBRE { get; set; }
        public string CLIENTE_APELLIDO_PATERNO { get; set; }
        public string CLIENTE_APELLIDO_MATERNO { get; set; }
    }
}
