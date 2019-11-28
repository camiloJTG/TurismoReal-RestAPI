using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.negocio.Procedimientos.Productos;

namespace TR.negocio.Clases.Productos
{
    public class TR_imagen
    {
        private Pro_imagen procedimiento = new Pro_imagen();

        public decimal IMAGEN_ID { get; set; }
        public string NOMBRE_IMAGEN { get; set; }
        public decimal TOUR_ID { get; set; }
        public decimal DEPARTAMENTO_ID { get; set; }
        public decimal ENTORNO_ID { get; set; }

        //MÉTODOS
        public List<TR_imagen> ListarImagen(decimal id)
        {
            var listado = procedimiento.ListarImagen(id);
            return listado.ToList();
        }

        public string AgregarImagen(TR_imagen imagen)
        {
            try
            {
                procedimiento.AgregarImagen(imagen);
                return "OK";
            }
            catch (NullReferenceException)
            {
                return "Todos los campos deben estar completos";
            }
            catch (InvalidCastException)
            {
                return "El tipo de formato enviado no corresponde";
            }
            catch (DbUpdateException)
            {
                return "No se ha podido registrar un imagen";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de registrar";
            }
        }

        public string EliminarImagen(decimal id)
        {
            try
            {
                procedimiento.EliminarImagen(id);
                return "OK";
            }
            catch (Exception)
            {
                return "El código ingresado no ha eliminado la imagen";
            }
        }
    }
}
