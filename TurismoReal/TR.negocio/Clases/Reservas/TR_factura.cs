using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases.Reserva
{
    public class TR_factura
    {
        public TR_factura()
        {
        }

        public TR_factura(decimal nUMERO_FACTURA, decimal? vALOR_NETO, decimal? iVA, decimal? tOTAL, decimal rESERVA_ID)
        {
            NUMERO_FACTURA = nUMERO_FACTURA;
            VALOR_NETO = vALOR_NETO;
            IVA = iVA;
            TOTAL = tOTAL;
            RESERVA_ID = rESERVA_ID;
        }

        public decimal NUMERO_FACTURA { get; set; }
        public Nullable<decimal> VALOR_NETO { get; set; }
        public Nullable<decimal> IVA { get; set; }
        public Nullable<decimal> TOTAL { get; set; }
        public decimal RESERVA_ID { get; set; }
    }
}
