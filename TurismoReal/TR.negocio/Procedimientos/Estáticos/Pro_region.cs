using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.dato.TurismoReal;
using TR.negocio.Clases.Estáticos;

namespace TR.negocio.Procedimientos.Estáticos
{
    public class Pro_region
    {
        private readonly Entities db = new Entities();

        public List<TR_region> ListadoRegion()
        {
            var listado = db.REGION.Select(x => new TR_region
            {
                NOMBRE_REGION = x.NOMBRE_REGION,
                REGION_CARDINAL = x.REGION_CARDINAL,
                REGION_ID = x.REGION_ID
            });
            return listado.ToList();
        }

        public TR_region BuscarRegion(decimal id)
        {
            var resultado = db.REGION.FirstOrDefault();
            TR_region region = new TR_region
            {
                NOMBRE_REGION = resultado.NOMBRE_REGION,
                REGION_CARDINAL = resultado.REGION_CARDINAL,
                REGION_ID = resultado.REGION_ID
            };
            return region;
        }

        public void AgregarRegion(TR_region region)
        {
            var dato = db.REGION.Create();
            dato.NOMBRE_REGION = region.NOMBRE_REGION;
            dato.REGION_CARDINAL = region.REGION_CARDINAL ;
            dato.REGION_ID = region.REGION_ID;

            db.REGION.Add(dato);
            db.SaveChanges();
        }

        public void EliminarRegion(decimal id)
        {
            var resultado = db.REGION.FirstOrDefault(x=>x.REGION_ID == id);
            db.REGION.Remove(resultado);
            db.SaveChanges();
        }

        public void ActualizarRegion(TR_region region)
        {
            var resultado = db.REGION.Find(region.REGION_ID);
            db.Entry(resultado).CurrentValues.SetValues(region);
            db.Entry(resultado).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool ExisteComuna(decimal id)
        {
            var resultado = db.REGION.FirstOrDefault(x => x.REGION_ID == id);
            if (resultado != null)
            {
                return true;
            }
            return false;
        }
    }
}
