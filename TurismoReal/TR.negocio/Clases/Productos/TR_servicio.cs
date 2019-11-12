using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.negocio.Procedimientos.Productos;

namespace TR.negocio.Clases.Productos
{
    public class TR_servicio
    {
        //ATRIBUTOS
        private readonly Pro_servicio procedimiento = new Pro_servicio();

        //CONSTRUCTORES
        public TR_servicio(decimal sERVICIO_ID, string nOMBRE, string dESCRIPCION)
        {
            SERVICIO_ID = sERVICIO_ID;
            NOMBRE = nOMBRE;
            DESCRIPCION = dESCRIPCION;
        }

        public TR_servicio()
        {
        }

        //PROPIEDADES
        public decimal SERVICIO_ID { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }

        //MÉTODOS
        public List<TR_servicio> ListarServicios()
        {
            var listado = procedimiento.ListadoServicio();
            return listado.ToList();
        }

        public TR_servicio BuscarServicio(decimal id)
        {
            try
            {
                var resultado = procedimiento.BuscarServicio(id);
                return resultado;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string AgregarServicio(TR_servicio servicio)
        {
            try
            {
                procedimiento.AgregarServicio(servicio);
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
                return "El código del servicio ingresado ya se encuentra registrado";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de registrar";
            }
        }

        public string EliminarServicio(decimal id)
        {
            try
            {
                procedimiento.EliminarServicio(id);
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
                return "El código del servicio ingresado ya se encuentra registrado";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de registrar";
            }
        }

        public string ActualizarServicio(decimal id, TR_servicio servicio)
        {
            try
            {
                var resultado = procedimiento.ExisteServicio(id);
                if (resultado == true)
                {
                    procedimiento.ActualizarServicio(id, servicio);
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
                return "El código del servicio ingresado ya se encuentra registrado";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de registrar";
            }
        }
    }
}
