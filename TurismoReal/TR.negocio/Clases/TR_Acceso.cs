using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Clases
{
    public class TR_Acceso
    {
        public string USUARIO1 { get; set; }
        public string CONTRASENA { get; set; }
        public string TIPO_USUARIO_CODIGO { get; set; }
        public decimal ESTADO_ID { get; set; }


        //VALIDACIONES
        public string ValidarDatos(decimal estado, string tipoUsuario)
        {
            if (estado == 1)
            {
                switch (tipoUsuario)
                {
                    case "A":
                        return "Administrador";
                    case "E":
                        return "Empleado";
                    case "C":
                        return "Cliente";
                    default:
                        return "Ha ocurrido un error. Intentelo nuevamente";
                }
            }
            return "El usuario ingresado tiene su cuenta deshabilitada";
        }
    }
}
