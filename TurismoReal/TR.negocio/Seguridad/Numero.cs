using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Seguridad
{
    public class Numero
    {
        public decimal numeroAleatorio()
        {
            var randon = new Random();
            var numero = randon.Next(1000, 9999);
            return numero;
        }     
        
    }
}
