using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.dato.TurismoReal;
using TR.negocio.Clases.Listado;
using TR.negocio.Clases.Reservas;
using TR.negocio.Seguridad;

namespace TR.negocio.Procedimientos.Reservas
{
    public class Pro_reserva
    {
        private Entities db = new Entities();
        private Numero numero = new Numero();
        private Pro_DatosReserva DatosReserva = new Pro_DatosReserva();

        public List<TR_listadoReserva> ListarReserva()
        {
            var listado = db.RESERVA.Join(db.DETALLE_RESERVA, r => r.RESERVA_ID, dr => dr.RESERVA_ID, (reserva, detalleReserva) => new { reserva, detalleReserva}).
                Join(db.PAQUETE_PRODUCTO, r=>r.detalleReserva.PRODUCTO_PAQUETE_ID, pp=>pp.PAQUETE_ID, (reserva, paqueteProducto)=> new { reserva.reserva, reserva.detalleReserva, paqueteProducto}).
                Join(db.DEPARTAMENTO, r=>r.paqueteProducto.DEPARTAMENTO_ID, d=>d.DEPARTAMENTO_ID, (reserva, departamento)=> new { reserva.reserva, reserva.detalleReserva, reserva.paqueteProducto, departamento}).
                Join(db.TOUR, r=>r.paqueteProducto.TOUR_ID, t=>t.TOUR_ID, (reserva, tour)=> new { reserva.reserva, reserva.detalleReserva, reserva.paqueteProducto, reserva.departamento, tour}).
                Select(x=> new TR_listadoReserva
                { 
                    RESERVA_ID = x.reserva.RESERVA_ID,
                    FECHA_HORA_RESERVA = x.reserva.FECHA_HORA_RESERVA,
                    FECHA_HORA_ACTUALIZACION = x.reserva.FECHA_HORA_ACTUALIZACION,
                    RUN_CLIENTE = x.reserva.RUN_CLIENTE,
                    RUN_EMPLEADO = x.reserva.RUN_EMPLEADO,
                    ESTADO_ID = x.reserva.ESTADO_ID,
                    PAQUETE_ID = x.paqueteProducto.PAQUETE_ID,
                    TRASLADO = x.paqueteProducto.TRASLADO,
                    TOUR_ID = x.paqueteProducto.TOUR_ID,
                    TOTAL = x.paqueteProducto.TOTAL,
                    VALOR_TOUR = x.tour.VALOR_TOUR,
                    ITINERARIO_TOUR = x.tour.ITINERARIO_TOUR,
                    NOMBRE_TOUR = x.tour.NOMBRE_TOUR,
                    DEPARTAMENTO_ID = x.departamento.DEPARTAMENTO_ID,
                    DEPARTAMENTO_VALOR = x.departamento.VALOR,
                    DEPARTAMENTO_NOMBRE = x.departamento.NOMBRE,
                    DEPARTAMENTO_DIRECCION = x.departamento.DIRECCION,
                    DEPARTAMENTO_COMUNA_ID = x.departamento.COMUNA_ID,
                    DEPARTAMENTO_SUPERFICIE = x.departamento.SUPERFICIE,
                    DEPARTAMENTO_CONDICIONES_USO = x.departamento.CONDICIONES_USO,
                    FECHA_CREACION = x.departamento.FECHA_CREACION
                });
            return listado.ToList();
        }

        public List<TR_listadoReserva> BuscarDepartamento(decimal id)
        {
            var listado = db.RESERVA.Where(x=>x.RESERVA_ID == id).Join(db.DETALLE_RESERVA, r => r.RESERVA_ID, dr => dr.RESERVA_ID, (reserva, detalleReserva) => new { reserva, detalleReserva }).
                Join(db.PAQUETE_PRODUCTO, r => r.detalleReserva.PRODUCTO_PAQUETE_ID, pp => pp.PAQUETE_ID, (reserva, paqueteProducto) => new { reserva.reserva, reserva.detalleReserva, paqueteProducto }).
                Join(db.DEPARTAMENTO, r => r.paqueteProducto.DEPARTAMENTO_ID, d => d.DEPARTAMENTO_ID, (reserva, departamento) => new { reserva.reserva, reserva.detalleReserva, reserva.paqueteProducto, departamento }).
                Join(db.TOUR, r => r.paqueteProducto.TOUR_ID, t => t.TOUR_ID, (reserva, tour) => new { reserva.reserva, reserva.detalleReserva, reserva.paqueteProducto, reserva.departamento, tour }).
                Select(x => new TR_listadoReserva
                {
                    RESERVA_ID = x.reserva.RESERVA_ID,
                    FECHA_HORA_RESERVA = x.reserva.FECHA_HORA_RESERVA,
                    FECHA_HORA_ACTUALIZACION = x.reserva.FECHA_HORA_ACTUALIZACION,
                    RUN_CLIENTE = x.reserva.RUN_CLIENTE,
                    RUN_EMPLEADO = x.reserva.RUN_EMPLEADO,
                    ESTADO_ID = x.reserva.ESTADO_ID,
                    PAQUETE_ID = x.paqueteProducto.PAQUETE_ID,
                    TRASLADO = x.paqueteProducto.TRASLADO,
                    TOUR_ID = x.paqueteProducto.TOUR_ID,
                    TOTAL = x.paqueteProducto.TOTAL,
                    VALOR_TOUR = x.tour.VALOR_TOUR,
                    ITINERARIO_TOUR = x.tour.ITINERARIO_TOUR,
                    NOMBRE_TOUR = x.tour.NOMBRE_TOUR,
                    DEPARTAMENTO_ID = x.departamento.DEPARTAMENTO_ID,
                    DEPARTAMENTO_VALOR = x.departamento.VALOR,
                    DEPARTAMENTO_NOMBRE = x.departamento.NOMBRE,
                    DEPARTAMENTO_DIRECCION = x.departamento.DIRECCION,
                    DEPARTAMENTO_COMUNA_ID = x.departamento.COMUNA_ID,
                    DEPARTAMENTO_SUPERFICIE = x.departamento.SUPERFICIE,
                    DEPARTAMENTO_CONDICIONES_USO = x.departamento.CONDICIONES_USO,
                    FECHA_CREACION = x.departamento.FECHA_CREACION
                });
            return listado.ToList();
        }

        public void AgregarReserva(TR_reserva reserva)
        {
            var data = db.RESERVA.Create();

            data.RESERVA_ID = numero.numeroAleatorio();
            data.FECHA_HORA_RESERVA = reserva.FECHA_HORA_RESERVA;
            data.FECHA_HORA_ACTUALIZACION = reserva.FECHA_HORA_ACTUALIZACION;
            data.RUN_CLIENTE = reserva.RUN_CLIENTE;
            data.RUN_EMPLEADO = reserva.RUN_EMPLEADO;
            data.ESTADO_ID = reserva.ESTADO_ID;

            db.RESERVA.Add(data);
            db.SaveChanges();
            var PaqueteProducto = DatosReserva.AgregarPaqueteProducto(reserva.PAQUETE_TRASLADO, reserva.PAQUETE_TOUR_ID, reserva.PAQUETE_DEPARTAMENTO_ID,reserva.PAQUETE_TOTAL);
            DatosReserva.AgregarDetalleReserva(data.RESERVA_ID, PaqueteProducto);
        }

        public void EliminarReserva(decimal id)
        {
            var DetalleReserva = db.DETALLE_RESERVA.FirstOrDefault(x=>x.RESERVA_ID == id);
            var Reserva = db.RESERVA.Find(id);
            var PaqueteProducto = db.PAQUETE_PRODUCTO.Find(DetalleReserva.PRODUCTO_PAQUETE_ID);

            db.PAQUETE_PRODUCTO.Remove(PaqueteProducto);
            db.DETALLE_RESERVA.Remove(DetalleReserva);
            db.RESERVA.Remove(Reserva);
            db.SaveChanges();
        }

        public void ActualizarReserva(decimal id, TR_reserva reserva)
        {
            var Reserva = db.RESERVA.Find(id);
            db.Entry(Reserva).CurrentValues.SetValues(reserva);
            db.Entry(Reserva).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool ExisteReserva(decimal id)
        {
            var resultado = db.RESERVA.FirstOrDefault(x=>x.RESERVA_ID == id);
            if (resultado != null)
            {
                return true;
            }
            return false;
        }
    }
}
