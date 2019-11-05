using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.dato.TurismoReal;
using TR.negocio.Clases.Listado;
using TR.negocio.Clases.Productos;
using TR.negocio.Seguridad;

namespace TR.negocio.Procedimientos.Productos
{
    public class Pro_sucursal
    {
        private Entities db = new Entities();
        private Numero numero = new Numero();

        public List<TR_listadoSucursal> ListadoSucursal()
        {
            var listado = db.SUCURSAL.Select(x=> new TR_listadoSucursal
            {
                NUMERO_SUCURSAL = x.NUMERO_SUCURSAL,
                DIRECCION = x.DIRECCION,
                TELEFONO = x.TELEFONO,
                RUN_EMPLEADO = x.RUN_EMPLEADO,
                COMUNA_ID = x.COMUNA_ID,
                NOMBRE_COMUNA = x.COMUNA.NOMBRE_COMUNA,
                PROVINCIA_ID = x.COMUNA.PROVINCIA_ID,
                NOMBRE_PROVINCIA = x.COMUNA.PROVINCIA.NOMBRE_PROVINCIA,
                REGION_ID = x.COMUNA.PROVINCIA.REGION_ID,
                NOMBRE_REGION = x.COMUNA.PROVINCIA.REGION.NOMBRE_REGION,
                REGION_CARDINAL = x.COMUNA.PROVINCIA.REGION.REGION_CARDINAL
            });
            return listado.ToList();
        }

        public TR_listadoSucursal BuscarSucursal(decimal id)
        {
            var resultado = db.SUCURSAL.FirstOrDefault(x=>x.NUMERO_SUCURSAL == id);
            TR_listadoSucursal sucursal = new TR_listadoSucursal
            {
                NUMERO_SUCURSAL = resultado.NUMERO_SUCURSAL,
                DIRECCION = resultado.DIRECCION,
                TELEFONO = resultado.TELEFONO,
                RUN_EMPLEADO = resultado.RUN_EMPLEADO,
                COMUNA_ID = resultado.COMUNA_ID,
                NOMBRE_COMUNA = resultado.COMUNA.NOMBRE_COMUNA,
                PROVINCIA_ID = resultado.COMUNA.PROVINCIA_ID,
                NOMBRE_PROVINCIA = resultado.COMUNA.PROVINCIA.NOMBRE_PROVINCIA,
                REGION_ID = resultado.COMUNA.PROVINCIA.REGION_ID,
                NOMBRE_REGION = resultado.COMUNA.PROVINCIA.REGION.NOMBRE_REGION,
                REGION_CARDINAL = resultado.COMUNA.PROVINCIA.REGION.REGION_CARDINAL
            };
            return sucursal;
        }

        public void AgregarSucursal(TR_sucursal sucursal)
        {
            var dato = db.SUCURSAL.Create();

            dato.NUMERO_SUCURSAL = numero.numeroAleatorio();
            dato.DIRECCION = sucursal.DIRECCION;
            dato.TELEFONO = sucursal.TELEFONO;
            dato.RUN_EMPLEADO = sucursal.RUN_EMPLEADO;
            dato.COMUNA_ID = sucursal.COMUNA_ID;

            db.SUCURSAL.Add(dato);
            db.SaveChanges();
        }

        public void EliminarSucursal(decimal id)
        {
            var resultado = db.SUCURSAL.FirstOrDefault(x=>x.NUMERO_SUCURSAL == id);
            db.SUCURSAL.Remove(resultado);
            db.SaveChanges();
        }

        public void ActualizarSucural(decimal id, TR_sucursal sucursal)
        {
            var resultado = db.SUCURSAL.Find(id);

            db.Entry(resultado).CurrentValues.SetValues(sucursal);
            db.Entry(resultado).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool ExisteSucursal(decimal id)
        {
            var resultado = db.SUCURSAL.FirstOrDefault(x => x.NUMERO_SUCURSAL == id);
            if (resultado != null)
            {
                return true;
            }
            return false;
        }
    }
}
