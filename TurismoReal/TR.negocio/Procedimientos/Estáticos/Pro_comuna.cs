using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.dato.TurismoReal;
using TR.negocio.Clases;

namespace TR.negocio.Procedimientos.Estáticos
{
    public class Pro_comuna
    {
        private Entities db = new Entities();

        public List<TR_comuna> ListadoComuna()
        {
            var listado = db.COMUNA.Select(x => new TR_comuna
            {
                COMUNA_ID = x.COMUNA_ID,
                NOMBRE_COMUNA =x.NOMBRE_COMUNA,
                PROVINCIA_ID = x.PROVINCIA_ID,
            });
            return listado.ToList();
        }

        public TR_comuna BuscarComuna(int id)
        {
            var resultado = db.COMUNA.FirstOrDefault(x=>x.COMUNA_ID == id);
            TR_comuna comuna = new TR_comuna
            {
                COMUNA_ID = resultado.COMUNA_ID,
                NOMBRE_COMUNA = resultado.NOMBRE_COMUNA,
                PROVINCIA_ID = resultado.PROVINCIA_ID
            };
            return comuna;
        }

        public void AgregarComuna(TR_comuna comuna)
        {
            var dato = db.COMUNA.Create();
            dato.COMUNA_ID = comuna.COMUNA_ID;
            dato.NOMBRE_COMUNA = comuna.NOMBRE_COMUNA;
            dato.PROVINCIA_ID = comuna.PROVINCIA_ID;

            db.COMUNA.Add(dato);
            db.SaveChanges();
        }

        public void EliminarComuna(int id)
        {
            var resultado = db.COMUNA.FirstOrDefault(x=>x.COMUNA_ID == id);
            db.COMUNA.Remove(resultado);
            db.SaveChanges();
        }

        public void ActualizarComuna(TR_comuna comuna)
        {
            var resultado = db.COMUNA.Find(comuna.COMUNA_ID);
            db.Entry(resultado).CurrentValues.SetValues(comuna);
            db.Entry(resultado).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool ExisteComuna(decimal id)
        {
            var resultado = db.COMUNA.FirstOrDefault(x=>x.COMUNA_ID == id);
            if (resultado != null)
            {
                return true;
            }
            return false;
        }
    }
}
