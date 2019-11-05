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
    public class Pro_provincia
    {
        private Entities db = new Entities();

        public List<TR_provincia> ListadoProvincia()
        {
            var listado = db.PROVINCIA.Select(x=> new TR_provincia
            {
                NOMBRE_PROVINCIA = x.NOMBRE_PROVINCIA,
                PROVINCIA_ID = x.PROVINCIA_ID,
                REGION_ID = x.REGION_ID
            });
            return listado.ToList();
        }

        public TR_provincia BuscarProvincia(int id)
        {
            var resultado = db.PROVINCIA.FirstOrDefault(x=>x.PROVINCIA_ID == id);
            TR_provincia provincia = new TR_provincia
            {
                NOMBRE_PROVINCIA = resultado.NOMBRE_PROVINCIA,
                PROVINCIA_ID = resultado.PROVINCIA_ID,
                REGION_ID = resultado.REGION_ID
            };
            return provincia;
        }

        public void AgregarProvincia(TR_provincia provincia)
        {
            var dato = db.PROVINCIA.Create();
            provincia.PROVINCIA_ID = dato.PROVINCIA_ID;
            provincia.NOMBRE_PROVINCIA = dato.NOMBRE_PROVINCIA;
            provincia.REGION_ID = dato.REGION_ID;

            db.PROVINCIA.Add(dato);
            db.SaveChanges();
        }

        public void EliminarProvincia(decimal id)
        {
            var resultado = db.PROVINCIA.FirstOrDefault(x=>x.PROVINCIA_ID == id);
            db.PROVINCIA.Remove(resultado);
            db.SaveChanges();
        }

        public void ActualizarProvincia(TR_provincia provincia)
        {
            var resultado = db.PROVINCIA.Find(provincia.PROVINCIA_ID);

            db.Entry(resultado).CurrentValues.SetValues(provincia);
            db.Entry(resultado).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool ProvinciaExiste(decimal id)
        {
            var resultado = db.PROVINCIA.FirstOrDefault(x => x.PROVINCIA_ID == id);
            if (resultado != null)
            {
                return true;
            }
            return false;
        }
    }
}
