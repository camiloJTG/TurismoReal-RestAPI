using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.negocio.Clases;
using TR.negocio.Procedimientos.Estáticos;

namespace TR.negocio.Validaciones.Estáticos
{
    public class Val_provincia
    {
        private readonly Pro_provincia procedimiento = new Pro_provincia();

        public List<TR_provincia> ListadoProvincia()
        {
            var listado = procedimiento.ListadoProvincia();
            return listado.ToList();
        }

        public TR_provincia BuscarProvincia(int id)
        {
            try
            {
                var resultado = procedimiento.BuscarProvincia(id);
                TR_provincia provincia = new TR_provincia
                {
                    NOMBRE_PROVINCIA = resultado.NOMBRE_PROVINCIA,
                    PROVINCIA_ID = resultado.PROVINCIA_ID,
                    REGION_ID = resultado.REGION_ID
                };
                return provincia;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string AgregarProvincia(TR_provincia provincia)
        {
            try
            {
                procedimiento.AgregarProvincia(provincia);
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
                return "Ha ocurrido un error al momento de registrar";
            }
        }

        public string EliminarProvincia(decimal id)
        {
            try
            {
                procedimiento.EliminarProvincia(id);
                return "OK";
            }
            catch (Exception)
            {
                return "El código ingresado no arrojó resultados";
            }
        }

        public string ActualizarProvincia(int id, TR_provincia provincia)
        {
            try
            {
                var resultado = procedimiento.ProvinciaExiste(id);
                if (resultado != true)
                {
                    procedimiento.ActualizarProvincia(provincia);
                    return "OK";
                }
                return "El código ingresado no arrojó resultados";
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
