using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.negocio.Procedimientos.Estáticos;

namespace TR.negocio.Clases.Estáticos
{
    public class TR_region
    {
        //ATRIBUTOS
        private readonly Pro_region procedimiento = new Pro_region();

        //PROPIEDADES
        public decimal REGION_ID { get; set; }
        public string NOMBRE_REGION { get; set; }
        public string REGION_CARDINAL { get; set; }

        //MÉTODOS
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
