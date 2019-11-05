using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.dato.TurismoReal;
using TR.negocio.Seguridad;

namespace TR.negocio.Procedimientos.Reservas
{
    public class Pro_DatosReserva
    {
        private Entities db = new Entities();
        private Numero numero = new Numero();

        //datos para agregar la reserva
        public decimal AgregarPaqueteProducto(string traslado, decimal tour_id, decimal departamento_id, decimal total)
        {
            var PaqueteProdcuto = db.PAQUETE_PRODUCTO.Create();

            PaqueteProdcuto.PAQUETE_ID = numero.numeroAleatorio();
            PaqueteProdcuto.TRASLADO = traslado;
            PaqueteProdcuto.TOUR_ID = tour_id;
            PaqueteProdcuto.DEPARTAMENTO_ID = departamento_id;
            PaqueteProdcuto.TOTAL = total;

            db.PAQUETE_PRODUCTO.Add(PaqueteProdcuto);
            db.SaveChanges();
            return PaqueteProdcuto.PAQUETE_ID;
        }

        public void AgregarDetalleReserva(decimal reserva_id, decimal producto_paquete_id)
        {
            var data= db.DETALLE_RESERVA.Create();

            data.DETALLE_RESERVA_ID = numero.numeroAleatorio();
            data.RESERVA_ID = reserva_id;
            data.PRODUCTO_PAQUETE_ID = producto_paquete_id;

            db.DETALLE_RESERVA.Add(data);
            db.SaveChanges();
        }
    }
}
