using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.dato.TurismoReal;
using TR.negocio.Clases.Productos;
using TR.negocio.Seguridad;

namespace TR.negocio.Procedimientos.Usuarios
{
    public class Pro_tour
    {
        private readonly Entities db = new Entities();
        private Numero numero = new Numero();

        public List<TR_tour> ListarTour()
        {
            var listado = db.TOUR.Select(x => new TR_tour
            {
                ITINERARIO_TOUR = x.ITINERARIO_TOUR,
                NOMBRE_TOUR = x.NOMBRE_TOUR,
                TOUR_ID = x.TOUR_ID,
                VALOR_TOUR = x.VALOR_TOUR
            });
            return listado.ToList();
        }

        public TR_tour BuscarTour(decimal id)
        {
            var resultado = db.TOUR.FirstOrDefault(x=>x.TOUR_ID == id);

            TR_tour tour = new TR_tour
            {
                TOUR_ID = resultado.TOUR_ID,
                ITINERARIO_TOUR = resultado.ITINERARIO_TOUR,
                NOMBRE_TOUR = resultado.NOMBRE_TOUR,
                VALOR_TOUR = resultado.VALOR_TOUR
            };
            return tour;
        }

        public void AgregarTour(TR_tour tour)
        {
            var dato = db.TOUR.Create();

            dato.TOUR_ID = numero.numeroAleatorio();
            dato.ITINERARIO_TOUR = tour.ITINERARIO_TOUR;
            dato.NOMBRE_TOUR = tour.NOMBRE_TOUR;
            dato.VALOR_TOUR = tour.VALOR_TOUR;

            db.TOUR.Add(dato);
            db.SaveChanges();
        }

        public void EliminarTour(decimal id)
        {
            var resultado = db.TOUR.FirstOrDefault(x=>x.TOUR_ID == id);
            db.TOUR.Remove(resultado);
            db.SaveChanges();
        }

        public void ActualizarTour(decimal id, TR_tour tour)
        {
            var resultado = db.TOUR.Find(tour.TOUR_ID);
            TR_tour t = new TR_tour(id, tour.VALOR_TOUR, tour.ITINERARIO_TOUR, tour.NOMBRE_TOUR);
            db.Entry(resultado).CurrentValues.SetValues(t);
            db.Entry(resultado).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool ExisteTour(decimal id)
        {
            var resultado = db.TOUR.FirstOrDefault(x => x.TOUR_ID == id);
            if (resultado != null)
            {
                return true;
            }
            return false;
        }
    }
}
