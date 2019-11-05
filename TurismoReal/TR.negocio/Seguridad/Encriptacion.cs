using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Seguridad
{
    public class Encriptacion
    {
        public string Encriptar(string cadena)
        {
            string resultado = String.Empty;
            Byte[] encriptar = Encoding.Unicode.GetBytes(cadena);
            resultado = Convert.ToBase64String(encriptar);
            return resultado;
        }

        public string Desencriptar(string cadena)
        {
            string resultado = String.Empty;
            Byte[] desencriptar = Convert.FromBase64String(cadena);
            resultado = Encoding.Unicode.GetString(desencriptar);
            return resultado;
        }
    }
}
