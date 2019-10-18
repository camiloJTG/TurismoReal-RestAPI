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
        public TR_Estado estado { get; set; }

        public List<TR_Usuario> ListarUsuarios(string data, string data2, string data3)
        {
            List<TR_Usuario> list = new List<TR_Usuario>();
            TR_Usuario usuario = new TR_Usuario();

            usuario.USUARIO1 = data;
            usuario.CONTRASENA = data2;
            usuario.estado.DESCRIPCION = data3;
            list.Add(usuario);

            return list.ToList();
        }
    }
}
