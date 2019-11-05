using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases.Productos
{
    public class TR_inventario
    {
        public TR_inventario()
        {
        }

        public TR_inventario(decimal iNVENTARIO_ID, string nOMBRE, string dESCRIPCION)
        {
            INVENTARIO_ID = iNVENTARIO_ID;
            NOMBRE = nOMBRE;
            DESCRIPCION = dESCRIPCION;
        }

        public decimal INVENTARIO_ID { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
    }
}
