using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.negocio.Procedimientos.Usuarios;
using TR.negocio.Seguridad;

namespace TR.negocio.Clases.Usuarios
{
    public class TR_acceso
    {
        //ATRIBUTOS
        private Pro_acceso procedimiento = new Pro_acceso();
        private Token token = new Token();

        //PROPIEDADES
        public string RUN { get; set; }
        public string CONTRASENA { get; set; }

        //MÉTODOS
        public TR_usuario ValidarAcceso(TR_acceso acceso)
        {
            try
            {
                var resultado = procedimiento.ExisteUsuario(acceso);
                if (resultado != null)
                {
                    return resultado;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string ValidarAcceso2(TR_acceso acceso)
        {
            try
            {
                var resultado = procedimiento.ExisteUsuario2(acceso);
                if (resultado == true)
                {
                    var CrearToken = token.CreateToken(acceso);
                    return "Token: " + CrearToken.ToString();
                }
                return "Credenciales incorrectas";
            }
            catch (Exception)
            {
                return "Credenciales no registradas";
            }
        }
    }
}
