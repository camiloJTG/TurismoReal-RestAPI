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
    public class Pro_servicio
    {
        private readonly Entities db = new Entities();
        private Numero numero = new Numero();

        public List<TR_servicio> ListadoServicio()
        {
            var listado = db.SERVICIO.Select(x => new TR_servicio
            {
                SERVICIO_ID = x.SERVICIO_ID,
                DESCRIPCION = x.DESCRIPCION,
                NOMBRE = x.NOMBRE
            });
            return listado.ToList();
        }

        public TR_servicio BuscarServicio(decimal id)
        {
            var resultado = db.SERVICIO.FirstOrDefault(x=>x.SERVICIO_ID == id);
            TR_servicio servicio = new TR_servicio
            {
                SERVICIO_ID = resultado.SERVICIO_ID,
                DESCRIPCION = resultado.DESCRIPCION,
                NOMBRE = resultado.NOMBRE
            };
            return servicio;
        }

        public void AgregarServicio(TR_servicio servicio)
        {
            var data = db.SERVICIO.Create();

            data.DESCRIPCION = servicio.DESCRIPCION;
            data.NOMBRE = servicio.NOMBRE;
            data.SERVICIO_ID = numero.numeroAleatorio();

            db.SERVICIO.Add(data);
            db.SaveChanges();
        }

        public void EliminarServicio(decimal id)
        {
            var resultado = db.SERVICIO.FirstOrDefault(x=>x.SERVICIO_ID == id);
            db.SERVICIO.Remove(resultado);
            db.SaveChanges();
        }

        public void ActualizarServicio(decimal id, TR_servicio servicio)
        {
            var resultado = db.SERVICIO.Find(id);
            TR_servicio s = new TR_servicio(id, servicio.NOMBRE, servicio.DESCRIPCION);
            db.Entry(resultado).CurrentValues.SetValues(s);
            db.Entry(resultado).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool ExisteServicio(decimal id)
        {
            var resultado = db.SERVICIO.FirstOrDefault(x => x.SERVICIO_ID == id);
            if (resultado != null)
            {
                return true;
            }
            return false;
        }
    }
}
