using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases
{
    public class TR_estado
    {
        public TR_estado()
        {

        }

        public TR_estado(decimal estado, string entidad, string codigo, string descripcion)
        {
            this.ESTADO_ID = estado;
            this.ENTIDAD = entidad;
            this.CODIGO = codigo;
            this.DESCRIPCION = descripcion;
        }

        public decimal ESTADO_ID { get; set; }
        public string ENTIDAD { get; set; }
        public string CODIGO { get; set; }
        public string DESCRIPCION { get; set; }
    }
}
