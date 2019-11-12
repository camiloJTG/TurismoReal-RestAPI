using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.negocio.Clases.Listado;
using TR.negocio.Procedimientos.Reservas;

namespace TR.negocio.Clases.Reservas
{
    public class TR_reserva
    {
        //ATRIBUTOS
        private Pro_reserva procedimiento = new Pro_reserva();

        //PROPIEDADES
        //datos reserva
        public Nullable<System.DateTime> FECHA_HORA_RESERVA { get; set; }
        public Nullable<System.DateTime> FECHA_HORA_ACTUALIZACION { get; set; }
        public string RUN_CLIENTE { get; set; }
        public string RUN_EMPLEADO { get; set; }
        public decimal ESTADO_ID { get; set; }

        //datos paquete producto
        public string PAQUETE_TRASLADO { get; set; }
        public decimal PAQUETE_TOUR_ID { get; set; }
        public decimal PAQUETE_DEPARTAMENTO_ID { get; set; }
        public decimal PAQUETE_TOTAL { get; set; }

        //MÉTODOS
        public List<TR_listadoReserva> ListarReserva()
        {
            var resultado = procedimiento.ListarReserva();
            return resultado.ToList();
        }

        public List<TR_listadoReserva> BuscarReserva(decimal id)
        {
            try
            {
                var resultado = procedimiento.BuscarDepartamento(id);
                return resultado.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string AgregarReserva(TR_reserva reserva)
        {
            try
            {
                procedimiento.AgregarReserva(reserva);
                return "OK";
            }
            catch (NullReferenceException)
            {
                return "Todos los campos deben estar completos";
            }
            catch (InvalidCastException)
            {
                return "El tipo de formato enviado no corresponde";
            }
            catch (DbUpdateException)
            {
                return "El código de la reserva ingresado ya se encuentra registrado";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de registrar";
            }
        }

        public string EliminarReserva(decimal id)
        {
            try
            {
                procedimiento.EliminarReserva(id);
                return "OK";
            }
            catch (Exception)
            {
                return "El código de la reserva no arrojó resutlados";
            }
        }

        public string ActualizarReserva(decimal id, TR_reserva reserva)
        {
            try
            {
                var resultado = procedimiento.ExisteReserva(id);
                if (resultado == true)
                {
                    procedimiento.ActualizarReserva(id, reserva);
                    return "OK";
                }
                return "El códgido de la reserva no arrojó resultados";
            }
            catch (NullReferenceException)
            {
                return "Todos los campos deben estar completos";
            }
            catch (InvalidCastException)
            {
                return "El tipo de formato enviado no corresponde";
            }
            catch (DbUpdateException)
            {
                return "El código de la reserva ingresado ya se encuentra registrado";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de registrar";
            }
        }
    }
}
