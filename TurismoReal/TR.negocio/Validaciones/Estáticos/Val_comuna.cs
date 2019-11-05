using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.negocio.Clases;
using TR.negocio.Procedimientos.Estáticos;

namespace TR.negocio.Validaciones.Estáticos
{
    public class Val_comuna
    {
        private readonly Pro_comuna procedimiento = new Pro_comuna();

        public List<TR_comuna> LIstadoComuna()
        {
            var resultado = procedimiento.ListadoComuna();
            return resultado.ToList();
        }

        public TR_comuna BuscarComuna(int id)
        {
            try
            {
                var resultado = procedimiento.BuscarComuna(id);
                return resultado;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string AgregarComuna(TR_comuna comuna)
        {
            try
            {
                procedimiento.AgregarComuna(comuna);
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

        public string EliminarComuna(int id)
        {
            try
            {
                procedimiento.EliminarComuna(id);
                return "OK";
            }
            catch (Exception)
            {
                return "El código no arrojó resultados";
            }
        }

        public string ActualizarComuna(int id, TR_comuna comuna)
        {
            try
            {
                var resultado = procedimiento.ExisteComuna(comuna.COMUNA_ID);
                if (resultado == true)
                {
                    procedimiento.ActualizarComuna(comuna);
                    return "OK";
                }
                return "El codigo de la comuna ingresa no arrojó resultados";
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
                return "Ha ocurrido un error al momento de actualizar una comuna";
            }
        }
    }
}
