using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.dato.TurismoReal;
using TR.negocio.Clases.Usuarios;
using TR.negocio.Seguridad;

namespace TR.negocio.Procedimientos.Usuarios
{
    public class Pro_acceso
    {
        private Entities db = new Entities();
        private Encriptacion encriptar = new Encriptacion();

        public TR_usuario ExisteUsuario(TR_acceso acceso)
        {
            var resultado = db.USUARIO.FirstOrDefault(x => x.USUARIO1 == acceso.RUN);
            var contrasenaDesencriptada = encriptar.Desencriptar(resultado.CONTRASENA);
            if (acceso.RUN == resultado.USUARIO1 && acceso.CONTRASENA == contrasenaDesencriptada)
            {
                var emp = db.EMPLEADO.FirstOrDefault(x => x.RUN_EMPLEADO == acceso.RUN);
                var cli = db.CLIENTE.FirstOrDefault(x => x.RUN_CLIENTE == acceso.RUN);
                if (emp != null)
                {
                    TR_usuario u = new TR_usuario
                    {
                        RUN_CLIENTE = emp.RUN_EMPLEADO,
                        TIPO_USUARIO_CODIGO = emp.USUARIO1.TIPO_USUARIO_CODIGO,
                        APELLIDO_MATERNO = emp.APELLIDO_MATERNO,
                        APELLIDO_PATERNO = emp.APELLIDO_PATERNO,
                        EMAIL = emp.EMAIL,
                        DIRECCION = emp.DIRECCION,
                        COMUNA_ID = emp.COMUNA_ID,
                        FECHA_NACIMIENTO = emp.FECHA_NACIMIENTO,
                        TELEFONO = emp.TELEFONO,
                        NOMBRE = emp.NOMBRE,
                        ESTADO_ID = emp.ESTADO_ID,
                        CARGO = emp.CARGO,
                        NUMERO_SUCURSAL = emp.NUMERO_SUCURSAL,
                    };
                    return u;
                }

                if (cli != null)
                {
                    TR_usuario u = new TR_usuario
                    {
                        RUN_CLIENTE = cli.RUN_CLIENTE,
                        TIPO_USUARIO_CODIGO = cli.USUARIO1.TIPO_USUARIO_CODIGO,
                        APELLIDO_MATERNO = cli.APELLIDO_MATERNO,
                        APELLIDO_PATERNO = cli.APELLIDO_PATERNO,
                        EMAIL = cli.EMAIL,
                        DIRECCION = cli.DIRECCION,
                        COMUNA_ID = cli.COMUNA_ID,
                        FECHA_NACIMIENTO = cli.FECHA_NACIMIENTO,
                        TELEFONO = cli.TELEFONO,
                        NOMBRE = cli.NOMBRE,
                        ESTADO_ID = cli.ESTADO_ID
                    };
                    return u;
                }
            }
            return null;
        }

        public bool ExisteUsuario2(TR_acceso acceso)
        {
            var resultado = db.USUARIO.FirstOrDefault(x => x.USUARIO1 == acceso.RUN);
            var contrasenaDesencriptada = encriptar.Desencriptar(resultado.CONTRASENA);
            if (acceso.RUN == resultado.USUARIO1 && acceso.CONTRASENA == contrasenaDesencriptada)
            {
                return true;
            }
            return false;
        }
    }
}
