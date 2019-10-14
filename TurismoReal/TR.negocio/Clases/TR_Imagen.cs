using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases
{
    public class TR_Imagen
    {
        public decimal IMAGEN_ID { get; set; }
        public string NOMBRE_IMAGEN { get; set; }
        public string IMAGEN_ENCODE64 { get; set; }
        public decimal TOUR_ID { get; set; }
        public decimal ENTORNO_ID { get; set; }
        public decimal DEPARTAMENTO_ID { get; set; }
    }
}
