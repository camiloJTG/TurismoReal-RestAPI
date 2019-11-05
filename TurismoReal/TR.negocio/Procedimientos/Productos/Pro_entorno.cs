using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.dato.TurismoReal;
using TR.negocio.Clases.Productos;
using TR.negocio.Seguridad;

namespace TR.negocio.Procedimientos.Productos
{
    public class Pro_entorno
    {
        private readonly Entities db = new Entities();
        private Numero numero = new Numero();

        public List<TR_entorno> ListarEntorno()
        {
            var listado = db.ENTORNO.Select(x => new TR_entorno
            {
                ENTORNO_ID = x.ENTORNO_ID,
                IMG = x.IMG,
                NOMBRE = x.NOMBRE
            });
            return listado.ToList();
        }

        public TR_entorno BuscarEntorno(decimal id)
        {
            var resultado = db.ENTORNO.FirstOrDefault(x=>x.ENTORNO_ID == id);
            TR_entorno entorno = new TR_entorno
            {
                ENTORNO_ID = resultado.ENTORNO_ID,
                IMG = resultado.IMG,
                NOMBRE = resultado.NOMBRE
            };
            return entorno;
        }

        public void AgregarEntorno(TR_entorno entorno)
        {
            var dato = db.ENTORNO.Create();

            dato.ENTORNO_ID = numero.numeroAleatorio();
            dato.IMG = entorno.IMG;
            dato.NOMBRE = entorno.NOMBRE;

            db.ENTORNO.Add(dato);
            db.SaveChanges();
        }

        public void EliminarEntorno(decimal id)
        {
            var resultado = db.ENTORNO.FirstOrDefault(x=>x.ENTORNO_ID == id);
            db.ENTORNO.Remove(resultado);
            db.SaveChanges();
        }

        public void ActualizarEntorno(decimal id, TR_entorno entorno)
        {
            var resultado = db.ENTORNO.Find(id);
            TR_entorno e = new TR_entorno(id, entorno.NOMBRE, entorno.IMG);
            db.Entry(resultado).CurrentValues.SetValues(e);
            db.Entry(resultado).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool ExisteEntorno(decimal id)
        {
            var resultado = db.ENTORNO.FirstOrDefault(x=>x.ENTORNO_ID == id);
            if (resultado != null)
            {
                return true;
            }
            return false;
        }
    }
}
