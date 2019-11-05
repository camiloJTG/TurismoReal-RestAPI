using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases.Reservas
{
    public class TR_reserva
    {
        //datos reserva
        public Nullable<System.DateTime> FECHA_HORA_RESERVA { get; set; }
        public Nullable<System.DateTime> FECHA_HORA_ACTUALIZACION { get; set; }
        public string RUN_CLIENTE { get; set; }
        public string RUN_EMPLEADO { get; set; }
        public decimal ESTADO_ID { get; set; }

        //datos paquete producto
        public string PAQUETE_TRASLADO { get; set; }
        public decimal PAQUETE_TOUR_ID { get; set; }
        public decimal PAQUETE_DEPARTAMENTO_ID { get; set; }
        public decimal PAQUETE_TOTAL { get; set; }
    }
}
