﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR.negocio.Procedimientos.Reservas;

namespace TR.negocio.Clases.Reserva
{
    public class TR_factura
    {
        //ATRIBUTOS
        private Pro_factura procedimiento = new Pro_factura();

        //CONSTRUCTORES
        public TR_factura()
        {
        }

        public TR_factura(decimal nUMERO_FACTURA, decimal? vALOR_NETO, decimal? iVA, decimal? tOTAL, decimal rESERVA_ID)
        {
            NUMERO_FACTURA = nUMERO_FACTURA;
            VALOR_NETO = vALOR_NETO;
            IVA = iVA;
            TOTAL = tOTAL;
            RESERVA_ID = rESERVA_ID;
        }

        //PROPIEDADES
        public decimal NUMERO_FACTURA { get; set; }
        public Nullable<decimal> VALOR_NETO { get; set; }
        public Nullable<decimal> IVA { get; set; }
        public Nullable<decimal> TOTAL { get; set; }
        public decimal RESERVA_ID { get; set; }

        //MÉTODOS
        public List<TR_factura> ListarFactura()
        {
            var listado = procedimiento.LIstarFactura();
            return listado.ToList();
        }

        public TR_factura BuscarFactura(decimal id)
        {
            try
            {
                var resultado = procedimiento.BuscarFactura(id);
                return resultado;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string AgregarFactura(TR_factura factura)
        {
            try
            {
                procedimiento.AgregarFactura(factura);
                return "OK";
            }
            catch (NullReferenceException)
            {
                return "Todos los campos deben estar completos";
            }
            catch (InvalidCastException)
            {
                return "El tipo de formato enviado no corresponde";
            }
            catch (DbUpdateException)
            {
                return "El código de la reserva ingresado ya se encuentra registrado";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de registrar";
            }
        }

        public string EliminarFactura(decimal id)
        {
            try
            {
                procedimiento.EliminarFactura(id);
                return "OK";
            }
            catch (Exception)
            {
                return "El código de la factura no arrojó resultado";
            }
        }

        public string ActualizarFactura(decimal id, TR_factura factura)
        {
            try
            {
                var resultado = procedimiento.ExisteFactura(id);
                if (resultado == true)
                {
                    procedimiento.ActualizarFactura(id, factura);
                    return "OK";
                }
                return "El código de la factura no arrojó resultados";
            }
            catch (NullReferenceException)
            {
                return "Todos los campos deben estar completos";
            }
            catch (InvalidCastException)
            {
                return "El tipo de formato enviado no corresponde";
            }
            catch (DbUpdateException)
            {
                return "El código de la reserva ingresado ya se encuentra registrado";
            }
            catch (Exception)
            {
                return "Ha ocurrido un error al momento de registrar";
            }
        }
    }
}
