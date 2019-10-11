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
        public decimal ESTADO_DESCRIPCION { get; set; }
        public Nullable<System.DateTime> RESERVA_FECHA_HORA_RESERVA { get; set; }
        public Nullable<System.DateTime> RESERVA_FECHA_HORA_ACTUALIZACION { get; set; }

        //DATOS FACTURAS
        public decimal NUMERO_FACTURA { get; set; }
        public Nullable<decimal> FACTURA_VALOR_NETO { get; set; }
        public Nullable<decimal> FACTURA_IVA { get; set; }
        public Nullable<decimal> FACTURA_TOTAL { get; set; }

        //datos de pasajeros
        public string RUN_PASAJERO { get; set; }
        public string PASAJERO_NOMBRE { get; set; }
        public string PASAJERO_APELLIDO_PATERNO { get; set; }
        public string PASAJERO_APELLIDO_MATERNO { get; set; }
        public string PASAJERO_TELEFONO { get; set; }
        public string PASAJERO_EMAIL { get; set; }
        public Nullable<System.DateTime> PASAJERO_FECHA_NACIMIENTO { get; set; }
        public Nullable<decimal> PASAJERO_MENOR_EDAD { get; set; }

        //datos del paquete
        public string PAQUETE_TRASLADO { get; set; }
        public Nullable<decimal> PAQUETE_TOTAL { get; set; }

        //datos extras
        public string TOUR_NOMBRE { get; set; }
        public decimal DEPARTAMENTO_ID { get; set; } 
    }
}
