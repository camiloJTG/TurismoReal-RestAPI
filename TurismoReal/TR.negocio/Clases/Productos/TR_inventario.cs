using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.negocio.Procedimientos.Productos;

namespace TR.negocio.Clases.Productos
{
    public class TR_inventario
    {
        //ATRIBUTOS
        private readonly Pro_inventario procedimiento = new Pro_inventario();

        //CONSTRUCTORES
        public TR_inventario()
        {
        }

        public TR_inventario(decimal iNVENTARIO_ID, string nOMBRE, string dESCRIPCION)
        {
            INVENTARIO_ID = iNVENTARIO_ID;
            NOMBRE = nOMBRE;
            DESCRIPCION = dESCRIPCION;
        }

        //PROPIEDADES
        public decimal INVENTARIO_ID { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }

        //MÉTODOS
        public List<TR_inventario> ListarInventario()
        {
            var listado = procedimiento.ListarInventario();
            return listado.ToList();
        }

        public TR_inventario BuscarInventario(decimal id)
        {
            try
            {
                var resultado = procedimiento.BuscarInventario(id);
                return resultado;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string AgregarInventario(TR_inventario inventario)
        {
            try
            {
                procedimiento.AgregarInventario(inventario);
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
                return "El código del inventario ingresado ya se encuentra registrado";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de registrar";
            }
        }

        public string EliminarInventario(decimal id)
        {
            try
            {
                procedimiento.EliminarInventario(id);
                return "OK";
            }
            catch (Exception)
            {
                return "El código del inventario no arrojó resultado";
            }
        }

        public string ActualizarInventario(decimal id, TR_inventario inventario)
        {
            try
            {
                var resultado = procedimiento.ExisteInventario(id);
                if (resultado == true)
                {
                    procedimiento.ActualizarInventario(id, inventario);
                    return "OK";
                }
                return "El código del inventario no arrojó resultados";
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
                return "El código del inventario ingresado ya se encuentra registrado";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de registrar";
            }
        }

    }
}
