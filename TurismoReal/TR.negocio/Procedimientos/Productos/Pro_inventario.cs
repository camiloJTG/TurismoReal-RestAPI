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
    public class Pro_inventario
    {
        private readonly Entities db = new Entities();
        private Numero numero = new Numero();

        public List<TR_inventario> ListarInventario()
        {
            var listado = db.INVENTARIO.Select(x => new TR_inventario
            {
                DESCRIPCION = x.DESCRIPCION,
                INVENTARIO_ID = x.INVENTARIO_ID,
                NOMBRE = x.NOMBRE,
            });
            return listado.ToList();
        }

        public TR_inventario BuscarInventario(decimal id)
        {
            var resultado = db.INVENTARIO.FirstOrDefault(x => x.INVENTARIO_ID == id);
            TR_inventario inventario = new TR_inventario
            {
                INVENTARIO_ID = resultado.INVENTARIO_ID,
                DESCRIPCION = resultado.DESCRIPCION,
                NOMBRE = resultado.NOMBRE
            };
            return inventario;
        }

        public void AgregarInventario(TR_inventario inventario)
        {
            var dato = db.INVENTARIO.Create();

            dato.INVENTARIO_ID = numero.numeroAleatorio();
            dato.DESCRIPCION = inventario.DESCRIPCION;
            dato.NOMBRE = inventario.NOMBRE;

            db.INVENTARIO.Add(dato);
            db.SaveChanges();
        }

        public void EliminarInventario(decimal id)
        {
            var resultado = db.INVENTARIO.FirstOrDefault(x => x.INVENTARIO_ID == id);
            db.INVENTARIO.Remove(resultado);
            db.SaveChanges();
        }

        public void ActualizarInventario(decimal id, TR_inventario inventario)
        {
            var resultado = db.INVENTARIO.Find(id);
            TR_inventario i = new TR_inventario(id, inventario.NOMBRE, inventario.NOMBRE);

            db.Entry(resultado).CurrentValues.SetValues(i);
            db.Entry(resultado).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool ExisteInventario(decimal id)
        {
            var resultado = db.INVENTARIO.FirstOrDefault(x => x.INVENTARIO_ID == id);
            if (resultado != null)
            {
                return true;
            }
            return false;
        }
    }
}
