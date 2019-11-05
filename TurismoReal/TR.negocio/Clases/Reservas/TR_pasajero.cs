using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases.Reservas
{
    public class TR_pasajero
    {
        public string RUN_PASAJERO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public string TELEFONO { get; set; }
        public string EMAIL { get; set; }
        public Nullable<System.DateTime> FECHA_NACIMIENTO { get; set; }
        public string MENOR_EDAD { get; set; }
        public decimal RESERVA_ID { get; set; }
    }
}
