using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.negocio.Procedimientos;

namespace TR.negocio.Clases
{
    public class TR_estado
    {
        //ATRIBUTOS
        private readonly Pro_estado procedimiento = new Pro_estado();

        //CONSTRUCTORES
        public TR_estado(){}

        public TR_estado(decimal estado, string entidad, string codigo, string descripcion)
        {
            this.ESTADO_ID = estado;
            this.ENTIDAD = entidad;
            this.CODIGO = codigo;
            this.DESCRIPCION = descripcion;
        }

        //PROPIEDADES
        public decimal ESTADO_ID { get; set; }
        public string ENTIDAD { get; set; }
        public string CODIGO { get; set; }
        public string DESCRIPCION { get; set; }

        //MÉTODOS
        public List<TR_estado> ListadoEstado()
        {
            var listado = procedimiento.ListarEstado();
            return listado;
        }

        public TR_estado BuscarEstado(int id)
        {
            try
            {
                var resultado = procedimiento.BuscarEstado(id);
                return resultado;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string AgregarEstado(TR_estado estado)
        {
            try
            {
                procedimiento.AgregarEstado(estado);
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
                return "El tipo de dato ingresado no es correcta";
            }
        }

        public string EliminarEstado(int id)
        {
            try
            {
                procedimiento.EliminarEstado(id);
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
                return "El tipo de dato ingresado no es correcta";
            }
        }

        public string ActualizarEstado(int id, TR_estado estado)
        {
            try
            {
                var resultado = procedimiento.ExisteEstado(id);
                if (resultado == true)
                {
                    procedimiento.ActualizarEstado(id, estado);
                    return "OK";
                }
                return "El código del estado no arrojó resultado";
            }
            catch (DbUpdateConcurrencyException)
            {

                return "Error al mmento de actualizar el estado";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de actualizar";
            }
        }
    }
}
