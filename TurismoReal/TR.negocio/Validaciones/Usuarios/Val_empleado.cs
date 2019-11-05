using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.negocio.Clases.Listado;
using TR.negocio.Clases.Usuarios;
using TR.negocio.Procedimientos.Usuarios;

namespace TR.negocio.Validaciones.Usuarios
{
    public class Val_empleado
    {
        private readonly Pro_empleado procedimiento = new Pro_empleado();

        public List<TR_listadoEmpleado> ListadoEmpleado()
        {
            var listado = procedimiento.ListadoEmpleado();
            return listado.ToList();
        }

        public TR_listadoEmpleado BuscarEmpleado(string id)
        {
            try
            {
                var resultado = procedimiento.BuscarEmpleado(id);
                return resultado;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string AgregarEmpleado(TR_empleado empleado)
        {
            try
            {
                procedimiento.AgregarEmpleado(empleado);
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
            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }
            //    throw;
            //}
            catch (DbUpdateException)
            {
                return "El run ingresado ya se encuentra registrado";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de registrar";
            }
        }

        public string EliminarEmpleado(string id)
        {
            try
            {
                procedimiento.EliminarEmpleado(id);
                return "OK";
            }
            catch (DbUpdateException)
            {
                return "No se puede eliminar al empleado. Verifique que no tenga registros previos";
            }
            catch (Exception)
            {
                return "El run ingresado no arrojó resultados";
            }
        }

        public string ActualizarEmpleado(string id, TR_empleado empleado)
        {
            try
            {
                var resultado = procedimiento.ExisteEmpleado(id);
                if (resultado == true)
                {
                    procedimiento.ActualizarEmpleado(empleado);
                    return "OK";
                }
                return "El run ingresado no arrojó resultados";
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
