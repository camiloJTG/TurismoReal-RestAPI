using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases.Listado
{
    public class TR_listadoReserva
    {
        //datos reserva
        public decimal RESERVA_ID { get; set; }
        public Nullable<System.DateTime> FECHA_HORA_RESERVA { get; set; }
        public Nullable<System.DateTime> FECHA_HORA_ACTUALIZACION { get; set; }
        public string RUN_CLIENTE { get; set; }
        public string RUN_EMPLEADO { get; set; }
        public decimal ESTADO_ID { get; set; }

        //datos paquete producto
        public decimal PAQUETE_ID { get; set; }
        public string TRASLADO { get; set; }
        public decimal TOUR_ID { get; set; }
        public Nullable<decimal> TOTAL { get; set; }

        //datos tour
        public Nullable<decimal> VALOR_TOUR { get; set; }
        public string ITINERARIO_TOUR { get; set; }
        public string NOMBRE_TOUR { get; set; }

        //datos departamento
        public decimal DEPARTAMENTO_ID { get; set; }
        public Nullable<decimal> DEPARTAMENTO_VALOR { get; set; }
        public string DEPARTAMENTO_NOMBRE { get; set; }
        public string DEPARTAMENTO_DIRECCION { get; set; }
        public decimal DEPARTAMENTO_COMUNA_ID { get; set; }
        public string DEPARTAMENTO_SUPERFICIE { get; set; }
        public string DEPARTAMENTO_CONDICIONES_USO { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION { get; set; }
    }
}
