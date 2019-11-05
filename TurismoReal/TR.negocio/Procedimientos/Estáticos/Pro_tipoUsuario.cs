using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.dato.TurismoReal;
using TR.negocio.Clases;

namespace TR.negocio.Procedimientos
{
    public class Pro_tipoUsuario
    {
        private readonly Entities db = new Entities();

        public List<TR_tipoUsuario> ListadoTipoUsuario()
        {
            var resultado = db.TIPO_USUARIO.Select(x=> new TR_tipoUsuario
            {
                DESCRIPCION = x.DESCRIPCION,
                CODIGO = x.CODIGO
            });
            return resultado.ToList();
        }

        public TR_tipoUsuario BuscarTipoUsuario(string id)
        {
            var resultado = db.TIPO_USUARIO.FirstOrDefault(x=>x.CODIGO == id);
            TR_tipoUsuario TipoUsuario = new TR_tipoUsuario
            {
                CODIGO = resultado.CODIGO,
                DESCRIPCION = resultado.DESCRIPCION
            };
            return TipoUsuario;
        }

        public void AgregarTipoUsuario(string codigo, string descripcion)
        {
            var datos = db.TIPO_USUARIO.Create();
            datos.CODIGO = codigo;
            datos.DESCRIPCION = descripcion;

            db.TIPO_USUARIO.Add(datos);
            db.SaveChanges();
        }

        public void EliminarTipoUsuario(string id)
        {
            var resultado = db.TIPO_USUARIO.FirstOrDefault(x=>x.CODIGO == id);
            db.TIPO_USUARIO.Remove(resultado);
            db.SaveChanges();
        }

        public void ActualizarTipoUsuario(TR_tipoUsuario tipoUsuario)
        {
            var resultado = db.TIPO_USUARIO.Find(tipoUsuario.CODIGO);

            db.Entry(resultado).CurrentValues.SetValues(tipoUsuario);
            db.Entry(resultado).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool TipoUsuarioExiste(string id)
        {
            var resultado = db.TIPO_USUARIO.FirstOrDefault(x=>x.CODIGO == id);
            if (resultado != null)
            {
                return true;
            }
            return false;
        }
    }
}
