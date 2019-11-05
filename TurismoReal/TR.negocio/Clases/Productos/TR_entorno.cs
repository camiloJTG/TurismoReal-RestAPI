using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases.Productos
{
    public class TR_entorno
    {
        public TR_entorno()
        {

        }

        public TR_entorno(decimal entorno, string nombre, string img)
        {
            this.ENTORNO_ID = entorno;
            this.NOMBRE = nombre;
            this.IMG = img;
        }

        public decimal ENTORNO_ID { get; set; }
        public string NOMBRE { get; set; }
        public string IMG { get; set; }
    }
}
