using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases.Listado
{
    public class TR_listadoSucursal
    {
        public decimal NUMERO_SUCURSAL { get; set; }
        public string DIRECCION { get; set; }
        public string TELEFONO { get; set; }
        public string RUN_EMPLEADO { get; set; }
        public decimal COMUNA_ID { get; set; }

        //datos comuna
        public string NOMBRE_COMUNA { get; set; }
        public decimal PROVINCIA_ID { get; set; }

        //datos provincia
        public string NOMBRE_PROVINCIA { get; set; }
        public decimal REGION_ID { get; set; }

        //datos region
        public string NOMBRE_REGION { get; set; }
        public string REGION_CARDINAL { get; set; }
    }
}
