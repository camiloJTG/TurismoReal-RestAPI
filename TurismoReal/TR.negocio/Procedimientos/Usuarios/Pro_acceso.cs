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

        public bool ExisteUsuario(TR_acceso acceso)
        {
            var resultado = db.USUARIO.FirstOrDefault(x=>x.USUARIO1 == acceso.RUN);
            var contrasenaDesencriptada = encriptar.Desencriptar(resultado.CONTRASENA);
            if (acceso.RUN == resultado.USUARIO1 && acceso.CONTRASENA == contrasenaDesencriptada)
            {
                return true;
            }
            return false;
        }
    }
}
