using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases
{
    public class TR_PaqueteProducto
    {
        public decimal PAQUETE_ID { get; set; }
        public string TRASLADO { get; set; }
        public Nullable<decimal> TOTAL { get; set; }

        // datos del tour
        public string TOUR_NOMBRE { get; set; }
        public Nullable<decimal> TOUR_VALOR { get; set; }
        public string TOUR_ITINERARIO { get; set; }

        // datos para el departamento
        public string DEPARTAMENTO_NOMBRE { get; set; }
        public string DEPARTAMENTO_DIRECCION { get; set; }
        public Nullable<decimal> DEPARTAMENTO_VALOR { get; set; }
        public string DEPARTAMENTO_SUPERFICIE { get; set; }
    }
}
