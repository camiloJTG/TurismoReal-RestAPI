using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.dato.TurismoReal;
using TR.negocio.Clases.Reserva;
using TR.negocio.Seguridad;

namespace TR.negocio.Procedimientos.Reservas
{
    public class Pro_factura
    {
        private Entities db = new Entities();
        private Numero numero = new Numero();

        public List<TR_factura> LIstarFactura()
        {
            var listado = db.FACTURA.Select(x=> new TR_factura
            {
                NUMERO_FACTURA = x.NUMERO_FACTURA,
                IVA = x.IVA,
                RESERVA_ID = x.RESERVA_ID,
                TOTAL = x.TOTAL,
                VALOR_NETO = x.VALOR_NETO
            });
            return listado.ToList();
        }

        public TR_factura BuscarFactura(decimal id)
        {
            var resultado = db.FACTURA.FirstOrDefault(x=>x.NUMERO_FACTURA == id);
            TR_factura factura = new TR_factura
            {
                NUMERO_FACTURA = resultado.NUMERO_FACTURA,
                IVA = resultado.IVA,
                RESERVA_ID = resultado.RESERVA_ID,
                TOTAL = resultado.TOTAL,
                VALOR_NETO = resultado.VALOR_NETO
            };
            return factura;
        }

        public void AgregarFactura(TR_factura factura)
        {
            var data = db.FACTURA.Create();

            data.NUMERO_FACTURA = numero.numeroAleatorio();
            data.IVA = factura.IVA;
            data.RESERVA_ID = factura.RESERVA_ID;
            data.TOTAL = factura.TOTAL;
            data.VALOR_NETO = factura.VALOR_NETO;

            db.FACTURA.Add(data);
            db.SaveChanges();
        }

        public void EliminarFactura(decimal id)
        {
            var resultado = db.FACTURA.FirstOrDefault(x=>x.NUMERO_FACTURA == id);
            db.FACTURA.Remove(resultado);
            db.SaveChanges();
        }

        public void ActualizarFactura(decimal id,TR_factura factura)
        {
            var resultado = db.FACTURA.Find(factura.NUMERO_FACTURA);
            TR_factura f = new TR_factura(id, factura.VALOR_NETO, factura.IVA, factura.TOTAL, factura.RESERVA_ID);
            db.Entry(resultado).CurrentValues.SetValues(f);
            db.Entry(resultado).State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool ExisteFactura(decimal id)
        {
            var resultado = db.FACTURA.FirstOrDefault(x=> x.NUMERO_FACTURA == id);
            if (resultado != null)
            {
                return true;
            }
            return false;
        }
    }
}
