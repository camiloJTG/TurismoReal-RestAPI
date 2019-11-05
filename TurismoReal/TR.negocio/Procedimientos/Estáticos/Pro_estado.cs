using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.dato.TurismoReal;
using TR.negocio.Clases;
using TR.negocio.Seguridad;

namespace TR.negocio.Procedimientos
{
    public class Pro_estado
    {
        private Entities db = new Entities();
        private Numero randon = new Numero();

        public List<TR_estado> ListarEstado()
        {
            var listado = db.ESTADO.Select(x=> new TR_estado
            {
                CODIGO = x.CODIGO,
                DESCRIPCION = x.DESCRIPCION,
                ENTIDAD = x.ENTIDAD,
                ESTADO_ID = x.ESTADO_ID
            });
            return listado.ToList();
        }

        public TR_estado BuscarEstado(int id)
        {
            var resultado = db.ESTADO.FirstOrDefault(x => x.ESTADO_ID == id);
            TR_estado estado = new TR_estado
            {
                CODIGO = resultado.CODIGO,
                ENTIDAD = resultado.ENTIDAD,
                DESCRIPCION = resultado.DESCRIPCION,
                ESTADO_ID = resultado.ESTADO_ID
            };

            return estado;
        }

        public void AgregarEstado(TR_estado estado)
        {
            var Dataestado = db.ESTADO.Create();

            Dataestado.ESTADO_ID = randon.numeroAleatorio();
            Dataestado.ENTIDAD = estado.ENTIDAD;
            Dataestado.CODIGO = estado.CODIGO;
            Dataestado.DESCRIPCION = estado.DESCRIPCION;

            db.ESTADO.Add(Dataestado);
            db.SaveChanges();
        }

        public void EliminarEstado(int id)
        {
            var resultado = db.ESTADO.FirstOrDefault(x=>x.ESTADO_ID == id);
            db.ESTADO.Remove(resultado);
            db.SaveChanges();
        }

        public void ActualizarEstado(decimal id, TR_estado estado)
        {
            var resultado = db.ESTADO.Find(id);
            TR_estado e = new TR_estado(id, estado.ENTIDAD,estado.CODIGO,estado.DESCRIPCION);

            db.Entry(resultado).CurrentValues.SetValues(e);
            db.Entry(resultado).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool ExisteEstado(decimal id)
        {
            var resultado = db.ESTADO.FirstOrDefault(x=>x.ESTADO_ID == id);
            if (resultado != null)
            {
                return true;
            }
            return false;
        }
    }
}
