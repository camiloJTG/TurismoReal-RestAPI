using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.dato.TurismoReal;
using TR.negocio.Clases.Productos;
using TR.negocio.Procedimientos.Usuarios;

namespace TR.negocio.Validaciones.Productos
{
    public class Val_tour
    {
        private readonly Pro_tour procedimiento = new Pro_tour();

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
                    procedimiento.ActualizarTour(id,tour);
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
