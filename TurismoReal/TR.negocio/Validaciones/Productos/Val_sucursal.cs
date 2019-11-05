using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.negocio.Clases.Listado;
using TR.negocio.Clases.Productos;
using TR.negocio.Procedimientos.Productos;

namespace TR.negocio.Validaciones.Productos
{
    public class Val_sucursal
    {
        private readonly Pro_sucursal procedimiento = new Pro_sucursal();

        public List<TR_listadoSucursal> ListadoSucursal()
        {
            var listado = procedimiento.ListadoSucursal();
            return listado.ToList();
        }

        public TR_listadoSucursal BuscarSucursal(decimal id)
        {
            try
            {
                var resultado = procedimiento.BuscarSucursal(id);
                return resultado;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string AgregarSucursal(TR_sucursal sucursal)
        {
            try
            {
                procedimiento.AgregarSucursal(sucursal);
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
                return "El numero de sucursal ingresado ya se encuentra registrado";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de registrar";
            }
        }

        public string EliminarSucursal(decimal id)
        {
            try
            {
                procedimiento.EliminarSucursal(id);
                return "OK";
            }
            catch (Exception)
            {
                return "El número de la sucursal no se encuentra registrado";
            }
        }

        public string ActualizarSucursal(decimal id, TR_sucursal sucursal)
        {
            try
            {
                var resultado = procedimiento.ExisteSucursal(id);
                if (resultado == true)
                {
                    procedimiento.ActualizarSucural(id,sucursal);
                    return "OK";
                }
                return "El número de la sucursal ya se encuentra registrado";
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
                return "El número de la sucursal ingresado ya se encuentra registrado";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de registrar";
            }
        }
    }
}
