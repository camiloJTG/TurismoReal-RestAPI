using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.negocio.Clases;
using TR.negocio.Procedimientos;

namespace TR.negocio.Validaciones
{
    public class Val_tipoUsuario
    {
        private readonly Pro_tipoUsuario Procedimiento = new Pro_tipoUsuario();

        public List<TR_tipoUsuario> ListadoTipoUsuario()
        {
            var resultado = Procedimiento.ListadoTipoUsuario();
            return resultado.ToList();
        }

        public TR_tipoUsuario BuscarTipoUsuario(string id)
        {
            try
            {
                var resultado = Procedimiento.BuscarTipoUsuario(id);
                return resultado;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string AgregarTipoUsuario(TR_tipoUsuario tipoUsuario)
        {
            try
            {
                Procedimiento.AgregarTipoUsuario(tipoUsuario.CODIGO, tipoUsuario.DESCRIPCION);
                return "OK";
            }
            catch (DbEntityValidationException)
            {
                return "El formato del modelo no es correcto. Por favor, revise que las propiedades sean igual a las de la base de datos";
            }
            catch (DbUpdateException)
            {
                return "Todos los campos deben estar completos para realizar el registro";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de agregar un nuevo tipo de usuario";
            }
        }

        public string EliminarTipoUsuario(string id)
        {
            try
            {
                Procedimiento.EliminarTipoUsuario(id);
                return "OK";
            }
            catch (Exception)
            {
                return "El código ingresado no arrojó resultados";
            }
        }

        public string ActualizarTipoUsuario(string id, TR_tipoUsuario tipoUsuario)
        {
            try
            {
                var resultado = Procedimiento.TipoUsuarioExiste(id);
                if (resultado == true)
                {
                    Procedimiento.ActualizarTipoUsuario(tipoUsuario);
                    return "OK";
                }
                return "El código ingresado no existe registrado en la base de datos";
            }
            catch (DbUpdateConcurrencyException)
            {
                return "Error al momento de actualizar el tipo de usuario";
            }
            catch (DbEntityValidationException)
            {
                return "El formato del modelo no es correcto. Por favor, revise que las propiedades sean igual a las de la base de datos";
            }
            catch (InvalidOperationException)
            {
                return "Error al reconocer algún dato de un propiedad. Por favor, revise que las propiedades sean igual a las de la base de datos";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de actualizar";
            }
        }
    }
}
