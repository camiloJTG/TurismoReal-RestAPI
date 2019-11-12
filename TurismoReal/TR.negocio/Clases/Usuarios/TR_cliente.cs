using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.negocio.Clases.Listado;
using TR.negocio.Procedimientos.Usuarios;

namespace TR.negocio.Clases.Usuarios
{
    public class TR_cliente
    {
        //ATRIBUTOS
        private Pro_cliente procedimiento = new Pro_cliente();

        //PROPIEDADES
        //datos usuario
        public string CONTRASENA { get; set; }
        public string TIPO_USUARIO_CODIGO { get; set; }

        //datos cliente
        public string RUN_CLIENTE { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public string TELEFONO { get; set; }
        public string EMAIL { get; set; }
        public Nullable<System.DateTime> FECHA_NACIMIENTO { get; set; }
        public string DIRECCION { get; set; }
        public decimal COMUNA_ID { get; set; }
        public decimal ESTADO_ID { get; set; }

        //MÉTODOS
        public List<TR_listadoCliente> ListaCliente()
        {
            var resultado = procedimiento.ListarCliente();
            return resultado.ToList();
        }

        public TR_listadoCliente BuscarCliente(string id)
        {
            try
            {
                var resultado = procedimiento.BuscarCliente(id);
                return resultado;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string AgregarCliente(TR_cliente cliente)
        {
            try
            {
                procedimiento.AgregarCliente(cliente);
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
                return "El run ingresado ya se encuentra registrado";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de registrar";
            }
        }

        public string EliminarCliente(string id)
        {
            try
            {
                procedimiento.EliminarCliente(id);
                return "OK";
            }
            catch (DbUpdateException)
            {
                return "No se puede eliminar al cliente. Verifique que no tenga reservas registradas previamente";
            }
            catch (Exception)
            {
                return "El run ingresado no arrojó resultados";
            }
        }

        public string ActualizarCliente(string id, TR_cliente cliente)
        {
            try
            {
                var resultado = procedimiento.ExisteCliente(id);
                if (resultado == true)
                {
                    procedimiento.ActualizarCliente(cliente);
                    return "OK";
                }
                return "El run ingresado no se encuentra registrado";
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
                return "El run ingresado ya se encuentra registrado";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de registrar";
            }
        }
    }
}
