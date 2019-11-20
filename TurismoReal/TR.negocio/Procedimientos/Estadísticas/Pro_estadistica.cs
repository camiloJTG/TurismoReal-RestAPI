using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.dato.TurismoReal;
using TR.negocio.Clases.Estadísticas;

namespace TR.negocio.Procedimientos.Estadísticas
{
    public class Pro_estadistica
    {
        private Entities db = new Entities();

        public List<TR_arriendosRegion> CantidadArriendos()
        {
            var consulta = db.REGION.Join(db.PROVINCIA, re => re.REGION_ID, pro => pro.REGION_ID, (region, provincia) => new { region, provincia }).
                Join(db.COMUNA, pro => pro.provincia.PROVINCIA_ID, com => com.PROVINCIA_ID, (region, comuna) => new { region.region, region.provincia, comuna }).
                Join(db.DEPARTAMENTO, com => com.comuna.COMUNA_ID, depto => depto.COMUNA_ID, (comuna, departamento) => new { comuna.comuna, comuna.provincia, comuna.region, departamento }).
                Join(db.PAQUETE_PRODUCTO, depto => depto.departamento.DEPARTAMENTO_ID, pp => pp.DEPARTAMENTO_ID, (departamento, paqueteProducto) => new { departamento.comuna, departamento.departamento, departamento.provincia, departamento.region, paqueteProducto }).
                Join(db.DETALLE_RESERVA, pp => pp.paqueteProducto.PAQUETE_ID, dr => dr.PRODUCTO_PAQUETE_ID, (datos, detalleReserva) => new { datos.comuna, datos.departamento, datos.paqueteProducto, datos.provincia, datos.region, detalleReserva }).
                Join(db.RESERVA, dr => dr.detalleReserva.RESERVA_ID, re => re.RESERVA_ID, (datos, reserva) => new { datos.comuna, datos.departamento, datos.detalleReserva, datos.paqueteProducto, datos.provincia, datos.region, reserva }).
                Select(x => new TR_arriendosRegion
                {
                    NOMBRE_REGION = x.region.NOMBRE_REGION,
                    CANTIDAD_ARRIENDO = x.paqueteProducto.PAQUETE_ID,
                });

            return consulta.ToList();
        }
    }
}
