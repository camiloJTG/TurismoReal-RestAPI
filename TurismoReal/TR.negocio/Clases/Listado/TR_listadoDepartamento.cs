using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases.Listado
{
    public class TR_listadoDepartamento
    {
        //datos departamento
        public decimal DEPARTAMENTO_ID { get; set; }
        public Nullable<decimal> DEPARTAMENTO_VALOR { get; set; }
        public string DEPARTAMENTO_NOMBRE { get; set; }
        public string DEPARTAMENTO_DIRECCION { get; set; }
        public string DEPARTAMENTO_SUPERFICIE { get; set; }
        public string DEPARTAMENTO_CONDICIONES_USO { get; set; }
        public Nullable<System.DateTime> DEPARTAMENTO_FECHA_CREACION { get; set; }

        ////datos comuna
        public decimal COMUNA_ID { get; set; }
        public string COMUNA_NOMBRE { get; set; }

        ////datos estado
        public decimal ESTADO_ID { get; set; }
        public string ESTADO_ENTIDAD { get; set; }
        public string ESTADO_CODIGO { get; set; }
        public string ESTADO_DESCRIPCION { get; set; }

        ////datos servicio
        //public decimal SERVICIO_ID { get; set; }
        //public string SERVICIO_NOMBRE { get; set; }
        //public string SERVICIO_DESCRIPCION { get; set; }

        ////datos inventario
        //public decimal INVENTARIO_ID { get; set; }
        //public string INVENTARIO_NOMBRE { get; set; }
        //public string INVENTARIO_DESCRIPCION { get; set; }

        ////datos entorno
        //public decimal ENTORNO_ID { get; set; }
        //public string ENTORNO_NOMBRE { get; set; }
        //public string ENTORNO_IMG { get; set; }
    }
}
