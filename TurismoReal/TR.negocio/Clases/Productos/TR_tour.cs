using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.negocio.Procedimientos.Usuarios;

namespace TR.negocio.Clases.Productos
{
    public class TR_tour
    {
        //ATRIBUTOS
        private readonly Pro_tour procedimiento = new Pro_tour();

        //CONSTRUCTORES
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

        //PROPIEDADES
        public decimal TOUR_ID { get; set; }
        public Nullable<decimal> VALOR_TOUR { get; set; }
        public string ITINERARIO_TOUR { get; set; }
        public string NOMBRE_TOUR { get; set; }

        //MÉTODOS
        public IEnumerable<TR_tour> LIstadoTour()
        {
            var listado = procedimiento.ListarTour();
            return listado.ToList();
        }

        public TR_tour BuscarTour(decimal id)
        {
            try
            {
                var resultado = procedimiento.BuscarTour(id);
                return resultado;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string AgregarTour(TR_tour tour)
        {
            try
            {
                procedimiento.AgregarTour(tour);
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
                return "El código del tour ingresado ya se encuentra registrado";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de registrar";
            }
        }

        public string EliminarTour(decimal id)
        {
            try
            {
                procedimiento.EliminarTour(id);
                return "OK";
            }
            catch (Exception)
            {
                return "El código ingresado no arrojó resultados";
            }
        }

        public string ActualizarTour(decimal id, TR_tour tour)
        {
            try
            {
                var resultado = procedimiento.ExisteTour(id);
                if (resultado == true)
                {
                    procedimiento.ActualizarTour(id, tour);
                }
                return "El código ingresado no arrojó resultado";
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
                return "El código del tour ingresado ya se encuentra registrado";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de registrar";
            }
        }
    }
}
