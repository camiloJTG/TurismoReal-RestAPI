using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases.Productos
{
    public class TR_tour
    {
        public TR_tour(decimal tOUR_ID, decimal? vALOR_TOUR, string iTINERARIO_TOUR, string nOMBRE_TOUR)
        {
            TOUR_ID = tOUR_ID;
            VALOR_TOUR = vALOR_TOUR;
            ITINERARIO_TOUR = iTINERARIO_TOUR;
            NOMBRE_TOUR = nOMBRE_TOUR;
        }

        public TR_tour()
        {
        }

        public decimal TOUR_ID { get; set; }
        public Nullable<decimal> VALOR_TOUR { get; set; }
        public string ITINERARIO_TOUR { get; set; }
        public string NOMBRE_TOUR { get; set; }
    }
}
