using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases.Productos
{
    public class TR_servicio
    {
        public TR_servicio(decimal sERVICIO_ID, string nOMBRE, string dESCRIPCION)
        {
            SERVICIO_ID = sERVICIO_ID;
            NOMBRE = nOMBRE;
            DESCRIPCION = dESCRIPCION;
        }

        public TR_servicio()
        {
        }

        public decimal SERVICIO_ID { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
    }
}
