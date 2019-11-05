using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.negocio.Clases.Usuarios;
using TR.negocio.Procedimientos.Usuarios;
using TR.negocio.Seguridad;

namespace TR.negocio.Validaciones.Usuarios
{
    public class Val_acceso
    {
        private Pro_acceso procedimiento = new Pro_acceso();
        private Token token = new Token();

        public string ValidarAcceso(TR_acceso acceso)
        {
            try
            {
                var resultado = procedimiento.ExisteUsuario(acceso);
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
