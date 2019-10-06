using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.dato;

namespace TR.negocio.Conexión
{
    public class ConexionEntities
    {
        private Entities db = new Entities();

        public Entities Connection { get => db; set => db = value; }
    }
}
