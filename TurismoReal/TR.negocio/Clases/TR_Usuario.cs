using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases
{
    public class TR_Usuario
    {
        public string USUARIO1 { get; set; }
        public string CONTRASENA { get; set; }
        public string ESTADO_DESCRIPCION { get; set; }
        public string ESTADO_ENTIDAD { get; set; }
        public string TIPO_USUARIO_DESCRIPCION { get; set; }
        public TR_TipoUsuario TipoUsuario { get; set; } 
    }
}
