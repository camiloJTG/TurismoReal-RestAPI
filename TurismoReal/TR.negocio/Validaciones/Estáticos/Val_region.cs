using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.negocio.Clases.Estáticos;
using TR.negocio.Procedimientos.Estáticos;

namespace TR.negocio.Validaciones.Estáticos
{
    public class Val_region
    {
        private readonly Pro_region procedimiento = new Pro_region();

        public List<TR_region> ListadoRegion()
        {
            var listado = procedimiento.ListadoRegion();
            return listado.ToList();
        }

        public TR_region BuscarRegion(decimal id)
        {
            try
            {
                var resultado = procedimiento.BuscarRegion(id);
                return resultado;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string AgregarRegion(TR_region region)
        {
            try
            {
                procedimiento.AgregarRegion(region);
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
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de registrar una comuna";
            }
        }

        public string EliminarRegion(decimal id)
        {
            try
            {
                procedimiento.EliminarRegion(id);
                return "OK";
            }
            catch (Exception)
            {
                return "El código ingresado no arrojó resultados";
            }
        }

        public string ActualizarRegion(decimal id, TR_region region)
        {
            try
            {
                var resultado = procedimiento.ExisteComuna(id);
                if (resultado == true)
                {
                    procedimiento.ActualizarRegion(region);
                    return "OK";
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
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de actualizar";
            }
        }
    }
}
