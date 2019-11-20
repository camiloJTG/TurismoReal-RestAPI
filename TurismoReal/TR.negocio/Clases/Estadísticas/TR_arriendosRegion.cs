using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.negocio.Procedimientos.Estadísticas;

namespace TR.negocio.Clases.Estadísticas
{
    public class TR_arriendosRegion
    {
        private Pro_estadistica procedimientos = new Pro_estadistica();

        public string NOMBRE_REGION { get; set; }
        public decimal CANTIDAD_ARRIENDO { get; set; }

        //MÉTODOS
        public List<TR_arriendosRegion> ResultadosRegion()
        {
            var estadistica = procedimientos.CantidadArriendos();
            return estadistica;
        }
    } 
}
