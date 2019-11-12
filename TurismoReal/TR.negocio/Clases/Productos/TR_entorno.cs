using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.negocio.Procedimientos.Productos;

namespace TR.negocio.Clases.Productos
{
    public class TR_entorno
    {
        //ATRIBUTOS
        private readonly Pro_entorno procedimiento = new Pro_entorno();

        //CONSTRUCTORES
        public TR_entorno()
        {

        }

        public TR_entorno(decimal entorno, string nombre, string img)
        {
            this.ENTORNO_ID = entorno;
            this.NOMBRE = nombre;
            this.IMG = img;
        }

        //PROPIEDADES
        public decimal ENTORNO_ID { get; set; }
        public string NOMBRE { get; set; }
        public string IMG { get; set; }

        //MÉTODOS
        public List<TR_entorno> ListadoEntorno()
        {
            var listado = procedimiento.ListarEntorno();
            return listado.ToList();
        }

        public TR_entorno BuscarEntorno(decimal id)
        {
            try
            {
                var resultado = procedimiento.BuscarEntorno(id);
                return resultado;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string AgregarEntorno(TR_entorno entorno)
        {
            try
            {
                procedimiento.AgregarEntorno(entorno);
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
                return "El código del entorno ingresado ya se encuentra registrado";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de registrar";
            }
        }

        public string EliminarEntorno(decimal id)
        {
            try
            {
                procedimiento.EliminarEntorno(id);
                return "OK";
            }
            catch (Exception)
            {
                return "El código del entorno ingresado no arrojó resultados";
            }
        }

        public string ActualizarEntorno(decimal id, TR_entorno entorno)
        {
            try
            {
                var resultado = procedimiento.ExisteEntorno(id);
                if (resultado == true)
                {
                    procedimiento.ActualizarEntorno(id, entorno);
                    return "OK";
                }
                return "El código del entorno no arrojó resultados";
            }
            catch (NullReferenceException)
            {
                return "Todos los campos deben estar completos";
            }
            catch (InvalidCastException)
            {
                return "El tipo de formato enviado no corresponde";
            }

        }
    }
}
