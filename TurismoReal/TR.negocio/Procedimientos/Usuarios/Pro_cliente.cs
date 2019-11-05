using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.dato.TurismoReal;
using TR.negocio.Clases.Listado;
using TR.negocio.Clases.Usuarios;
using TR.negocio.Seguridad;

namespace TR.negocio.Procedimientos.Usuarios
{
    public class Pro_cliente
    {
        private readonly Entities db = new Entities();
        private readonly Encriptacion encriptacion = new Encriptacion();

        public List<TR_listadoCliente> ListarCliente()
        {
            var listado = db.CLIENTE.Select(x => new TR_listadoCliente
            {
                APELLIDO_MATERNO = x.APELLIDO_MATERNO,
                APELLIDO_PATERNO = x.APELLIDO_PATERNO,
                COMUNA_ID = x.COMUNA_ID,
                COMUNA_NOMBRE = x.COMUNA.NOMBRE_COMUNA,
                CONTRASENA = x.USUARIO1.CONTRASENA,
                DIRECCION = x.DIRECCION,
                EMAIL = x.EMAIL,
                ESTADO_DESCRIPCION = x.ESTADO.DESCRIPCION,
                ESTADO_ID = x.ESTADO_ID,
                FECHA_NACIMIENTO = x.FECHA_NACIMIENTO,
                NOMBRE = x.NOMBRE,
                RUN_CLIENTE = x.RUN_CLIENTE,
                TELEFONO = x.TELEFONO,
                TIPO_USUARIO_DESCRIPCION = x.USUARIO1.TIPO_USUARIO.DESCRIPCION
            });
            return listado.ToList();
        }

        public TR_listadoCliente BuscarCliente(string id)
        {
            var resultado = db.CLIENTE.FirstOrDefault(x=>x.RUN_CLIENTE == id);
            TR_listadoCliente cliente = new TR_listadoCliente
            {
                APELLIDO_MATERNO = resultado.APELLIDO_MATERNO,
                APELLIDO_PATERNO = resultado.APELLIDO_PATERNO,
                COMUNA_ID = resultado.COMUNA_ID,
                COMUNA_NOMBRE = resultado.COMUNA.NOMBRE_COMUNA,
                CONTRASENA = resultado.USUARIO1.CONTRASENA,
                DIRECCION = resultado.DIRECCION,
                EMAIL = resultado.EMAIL,
                ESTADO_DESCRIPCION = resultado.ESTADO.DESCRIPCION,
                ESTADO_ID = resultado.ESTADO_ID,
                FECHA_NACIMIENTO = resultado.FECHA_NACIMIENTO,
                NOMBRE = resultado.NOMBRE,
                RUN_CLIENTE = resultado.RUN_CLIENTE,
                TELEFONO = resultado.TELEFONO,
                TIPO_USUARIO_DESCRIPCION = resultado.USUARIO1.TIPO_USUARIO.DESCRIPCION
            };
            return cliente;
        }

        public void AgregarCliente(TR_cliente cliente)
        {
            var dato = db.CLIENTE.Create();
            var usuario = db.USUARIO.Create();
            var contraseniaEncriptada = encriptacion.Encriptar(cliente.CONTRASENA);

            usuario.USUARIO1 = cliente.RUN_CLIENTE;
            usuario.CONTRASENA = contraseniaEncriptada;
            usuario.TIPO_USUARIO_CODIGO = cliente.TIPO_USUARIO_CODIGO;
            usuario.ESTADO_ID = cliente.ESTADO_ID;

            dato.RUN_CLIENTE = cliente.RUN_CLIENTE;
            dato.NOMBRE = cliente.NOMBRE;
            dato.APELLIDO_MATERNO = cliente.APELLIDO_MATERNO;
            dato.APELLIDO_PATERNO = cliente.APELLIDO_PATERNO;
            dato.TELEFONO = cliente.TELEFONO;
            dato.EMAIL = cliente.EMAIL;
            dato.FECHA_NACIMIENTO = cliente.FECHA_NACIMIENTO;
            dato.DIRECCION = cliente.DIRECCION;
            dato.COMUNA_ID = cliente.ESTADO_ID;
            dato.ESTADO_ID = cliente.ESTADO_ID;
            dato.USUARIO = cliente.RUN_CLIENTE;

            db.USUARIO.Add(usuario);
            db.CLIENTE.Add(dato);
            db.SaveChanges();
        }

        public void EliminarCliente(string id)
        {
            var resultadoCliente = db.CLIENTE.FirstOrDefault(x=>x.RUN_CLIENTE == id);
            var resultadoUsuario = db.USUARIO.FirstOrDefault(x=>x.USUARIO1 == id);

            db.CLIENTE.Remove(resultadoCliente);
            db.USUARIO.Remove(resultadoUsuario);
            db.SaveChanges();
        }

        public void ActualizarCliente(TR_cliente cliente)
        {
            var resultado = db.CLIENTE.Find(cliente.RUN_CLIENTE);
            var usuario = db.USUARIO.Find(cliente.RUN_CLIENTE);

            db.Entry(usuario).CurrentValues.SetValues(cliente);
            db.Entry(resultado).CurrentValues.SetValues(cliente);
            db.Entry(resultado).State = EntityState.Modified;
            db.Entry(usuario).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool ExisteCliente(string id)
        {
            var resultado = db.CLIENTE.FirstOrDefault(x => x.RUN_CLIENTE == id);
            if (resultado != null)
            {
                return true;
            }
            return false;
        }
    }
}
