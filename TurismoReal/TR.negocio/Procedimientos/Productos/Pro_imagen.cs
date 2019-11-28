using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.dato.TurismoReal;
using TR.negocio.Clases.Productos;

namespace TR.negocio.Procedimientos.Productos
{
    public class Pro_imagen
    {
        private Entities db = new Entities();

        public List<TR_imagen> ListarImagen(decimal id)
        {
            var listado = db.IMAGEN.Select(x=> new TR_imagen
            {
                NOMBRE_IMAGEN = x.NOMBRE_IMAGEN,
                TOUR_ID = x.TOUR_ID,
                DEPARTAMENTO_ID = x.DEPARTAMENTO_ID,
                ENTORNO_ID = x.ENTORNO_ID,
                IMAGEN_ID = x.IMAGEN_ID,
            });
            return listado.ToList();
        }

        public void AgregarImagen(TR_imagen imagen)
        {
            var img = db.IMAGEN.Create();
            img.NOMBRE_IMAGEN = imagen.NOMBRE_IMAGEN;
            img.TOUR_ID = imagen.TOUR_ID;
            img.DEPARTAMENTO_ID = imagen.DEPARTAMENTO_ID;
            img.ENTORNO_ID = imagen.ENTORNO_ID;
            img.IMAGEN_ID = img.IMAGEN_ID;

            db.IMAGEN.Add(img);
            db.SaveChanges();
        }

        public void EliminarImagen(decimal id)
        {
            var resultado = db.IMAGEN.FirstOrDefault(x=>x.IMAGEN_ID == id);
            db.IMAGEN.Remove(resultado);
            db.SaveChanges();
        }
    }
}
