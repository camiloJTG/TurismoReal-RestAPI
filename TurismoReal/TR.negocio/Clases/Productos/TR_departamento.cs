using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.negocio.Clases.Listado;
using TR.negocio.Procedimientos.Productos;

namespace TR.negocio.Clases.Productos
{
    public class TR_departamento
    {
        //ATRIBUTOS
        private Pro_departamento procedimiento = new Pro_departamento();

        //PROPIEDADES
        public Nullable<decimal> VALOR { get; set; }
        public string NOMBRE { get; set; }
        public string DIRECCION { get; set; }
        public decimal COMUNA_ID { get; set; }
        public string SUPERFICIE { get; set; }
        public string CONDICIONES_USO { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION { get; set; }
        public decimal ESTADO_ID { get; set; }

        //MÉTODOS
        public List<TR_listadoDepartamento> ListarDepartamento()
        {
            var listado = procedimiento.ListarDepartamento();
            return listado.ToList();
        }

        public List<TR_listadoDepartamento> BuscarDepartamento(decimal id)
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

        public string AgregarDepartamento(TR_departamento departamento)
        {
            try
            {
                procedimiento.AgregarDepartamento(departamento);
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
                return "El código del departamento ingresado ya se encuentra registrado";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de registrar";
            }
        }

        public string EliminarDepartamento(decimal id)
        {
            try
            {
                procedimiento.EliminarDepartamento(id);
                return "OK";
            }
            catch (Exception)
            {
                return "El código del departamento ingresado no arrojó resutlados";
            }
        }

        public string ActualizarDepartamento(decimal id, TR_departamento departamento)
        {
            try
            {
                var resultado = procedimiento.ExisteDepartamento(id);
                if (resultado == true)
                {
                    procedimiento.ActualizarDepartamento(id, departamento);
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
            catch (DbUpdateException)
            {
                return "El código del departamento ingresado ya se encuentra registrado";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de registrar";
            }
        }
    }
}
