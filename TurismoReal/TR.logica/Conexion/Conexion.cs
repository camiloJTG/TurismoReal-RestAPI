using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.dato.TR;

namespace TR.logica.Conexion
{
    public class Conexion
    {
        private Entities db = new Entities();

        public Entities Connection { get => db; set => db = value; }
    }
}
