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
    public class Pro_empleado
    {
        private readonly Entities db = new Entities();
        private Encriptacion encriptacion = new Encriptacion();

        public List<TR_listadoEmpleado> ListadoEmpleado()
        {
            var listado = db.EMPLEADO.Select(x=> new TR_listadoEmpleado
            {
                CONTRASENA = x.USUARIO1.CONTRASENA,
                TIPO_USUARIO_DESCRIPCION = x.USUARIO1.TIPO_USUARIO.DESCRIPCION,
                ESTADO_DESCRIPCION = x.USUARIO1.ESTADO.DESCRIPCION,
                RUN_EMPLEADO = x.RUN_EMPLEADO,
                NOMBRE = x.NOMBRE,
                APELLIDO_MATERNO = x.APELLIDO_MATERNO,
                APELLIDO_PATERNO = x.APELLIDO_PATERNO,
                CARGO = x.CARGO,
                DIRECCION = x.DIRECCION,
                EMAIL = x.EMAIL,
                TELEFONO = x.TELEFONO,
                FECHA_NACIMIENTO = x.FECHA_NACIMIENTO,
                COMUNA_ID = x.COMUNA_ID,
                COMUNA_NOMBRE = x.COMUNA.NOMBRE_COMUNA,
                ESTADO_ID = x.ESTADO_ID,
                NUMERO_SUCURSAL =x.NUMERO_SUCURSAL,
                SUCURSAL_DIRRECCION = x.SUCURSAL.DIRECCION
            });
            return listado.ToList();
        }

        public TR_listadoEmpleado BuscarEmpleado(string id)
        {
            var resultado = db.EMPLEADO.FirstOrDefault(x=>x.RUN_EMPLEADO == id);
            TR_listadoEmpleado empleado = new TR_listadoEmpleado
            {
                CONTRASENA = resultado.USUARIO1.CONTRASENA,
                TIPO_USUARIO_DESCRIPCION = resultado.USUARIO1.TIPO_USUARIO.DESCRIPCION,
                ESTADO_DESCRIPCION = resultado.USUARIO1.ESTADO.DESCRIPCION,
                RUN_EMPLEADO = resultado.RUN_EMPLEADO,
                NOMBRE = resultado.NOMBRE,
                APELLIDO_MATERNO = resultado.APELLIDO_MATERNO,
                APELLIDO_PATERNO = resultado.APELLIDO_PATERNO,
                CARGO = resultado.CARGO,
                DIRECCION = resultado.DIRECCION,
                EMAIL = resultado.EMAIL,
                TELEFONO = resultado.TELEFONO,
                FECHA_NACIMIENTO = resultado.FECHA_NACIMIENTO,
                COMUNA_ID = resultado.COMUNA_ID,
                COMUNA_NOMBRE = resultado.COMUNA.NOMBRE_COMUNA,
                ESTADO_ID = resultado.ESTADO_ID,
                NUMERO_SUCURSAL = resultado.NUMERO_SUCURSAL,
                SUCURSAL_DIRRECCION = resultado.SUCURSAL.DIRECCION
            };
            return empleado;
        }

        public void AgregarEmpleado(TR_empleado empleado)
        {
            var dato = db.EMPLEADO.Create();
            var usuario = db.USUARIO.Create();
            var contrasenaEncriptada = encriptacion.Encriptar(empleado.CONTRASENA);

            usuario.USUARIO1 = empleado.RUN_EMPLEADO;
            usuario.CONTRASENA = contrasenaEncriptada;
            usuario.TIPO_USUARIO_CODIGO = empleado.TIPO_USUARIO_CODIGO;
            usuario.ESTADO_ID = empleado.ESTADO_ID;

            dato.RUN_EMPLEADO = empleado.RUN_EMPLEADO;
            dato.NOMBRE = empleado.NOMBRE;
            dato.APELLIDO_MATERNO = empleado.APELLIDO_MATERNO;
            dato.APELLIDO_PATERNO = empleado.APELLIDO_PATERNO;
            dato.TELEFONO = empleado.TELEFONO;
            dato.EMAIL = empleado.EMAIL;
            dato.DIRECCION = empleado.DIRECCION;
            dato.FECHA_NACIMIENTO = empleado.FECHA_NACIMIENTO;
            dato.CARGO = empleado.CARGO;
            dato.USUARIO = empleado.RUN_EMPLEADO;
            dato.NUMERO_SUCURSAL = empleado.NUMERO_SUCURSAL;
            dato.COMUNA_ID = empleado.COMUNA_ID;
            dato.ESTADO_ID = empleado.ESTADO_ID;

            db.USUARIO.Add(usuario);
            db.EMPLEADO.Add(dato);
            db.SaveChanges();
        }

        public void EliminarEmpleado(string id)
        {
            var Empleado = db.EMPLEADO.FirstOrDefault(x=>x.RUN_EMPLEADO == id);
            var usuario = db.USUARIO.FirstOrDefault(x=>x.USUARIO1 == id);
            
            db.EMPLEADO.Remove(Empleado);
            db.USUARIO.Remove(usuario);
            db.SaveChanges();
        }

        public void ActualizarEmpleado(TR_empleado empleado)
        {
            var resultado = db.EMPLEADO.Find(empleado.RUN_EMPLEADO);
            var usuario = db.USUARIO.Find(empleado.RUN_EMPLEADO);

            db.Entry(usuario).CurrentValues.SetValues(empleado);
            db.Entry(resultado).CurrentValues.SetValues(empleado);
            db.Entry(resultado).State = EntityState.Modified;
            db.Entry(usuario).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool ExisteEmpleado(string id)
        {
            var resultado = db.EMPLEADO.FirstOrDefault(x => x.RUN_EMPLEADO== id);
            if (resultado != null)
            {
                return true;
            }
            return false;
        }
    }
}
