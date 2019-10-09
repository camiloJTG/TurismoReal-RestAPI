using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.negocio.Validaciones
{
    public class Validaciones
    {
        public bool ValidateEmpty(string descripcion)
        {
            var toUpper = descripcion.ToUpper();
            var withoutSpace = ReducirEspacios(toUpper);

            if (String.IsNullOrEmpty(withoutSpace))
            {
                return true;
            }
            return false;
        }

        private string ReducirEspacios(string descripcion)
        {
            while (descripcion.Contains(" "))
            {
                descripcion = descripcion.Replace(" ", "");
            }
            return descripcion;
        }

        public bool largeRun(string run)
        {
            var data = ReducirEspacios(run);

            if (data.Length > 9 && data.Length < 9)
            {
                return true;
            }
            return false;
        }

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
