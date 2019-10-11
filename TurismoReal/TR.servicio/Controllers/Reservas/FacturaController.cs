using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases;
using TR.negocio.Conexión;
using TR.negocio.Validaciones;

namespace TR.servicio.Controllers.Reservas
{
    public class FacturaController : ApiController
    {
        ConexionEntities con = new ConexionEntities();
        Validaciones validaciones = new Validaciones();

        [HttpGet]
        public IEnumerable<TR_Factura> GetFactura()
        {
            var list = con.Connection.FACTURA.Select(x=> new TR_Factura {
                RESERVA_ID = x.RESERVA.RESERVA_ID,
                RESERVA_FECHA_HORA_ACTUALIZACION = x.RESERVA.FECHA_HORA_ACTUALIZACION,
                RESERVA_FECHA_HORA_RESERVA = x.RESERVA.FECHA_HORA_RESERVA,
                CLIENTE_APELLIDO_MATERNO = x.CLIENTE.APELLIDO_MATERNO,
                CLIENTE_APELLIDO_PATERNO = x.CLIENTE.APELLIDO_PATERNO,
                CLIENTE_NOMBRE = x.CLIENTE.NOMBRE,
                CLIENTE_RUN = x.CLIENTE.RUN_CLIENTE,
                IVA = x.IVA,
                NUMERO_FACTURA = x.NUMERO_FACTURA,
                TOTAL = x.TOTAL,
                VALOR_NETO = x.VALOR_NETO
            });
            return list.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetFactura(int id)
        {
            var result = con.Connection.FACTURA.Where(x=>x.NUMERO_FACTURA == id).Select(x=>new TR_Factura {
                RESERVA_ID = x.RESERVA.RESERVA_ID,
                RESERVA_FECHA_HORA_ACTUALIZACION = x.RESERVA.FECHA_HORA_ACTUALIZACION,
                RESERVA_FECHA_HORA_RESERVA = x.RESERVA.FECHA_HORA_RESERVA,
                CLIENTE_APELLIDO_MATERNO = x.CLIENTE.APELLIDO_MATERNO,
                CLIENTE_APELLIDO_PATERNO = x.CLIENTE.APELLIDO_PATERNO,
                CLIENTE_NOMBRE = x.CLIENTE.NOMBRE,
                CLIENTE_RUN = x.CLIENTE.RUN_CLIENTE,
                IVA = x.IVA,
                NUMERO_FACTURA = x.NUMERO_FACTURA,
                TOTAL = x.TOTAL,
                VALOR_NETO = x.VALOR_NETO
            });

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("El código de la factura ingresada no es correcta");
        }

        [HttpPost]
        public IHttpActionResult PostFactura(TR.dato.FACTURA factura)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (FacturaBusqueda(factura.NUMERO_FACTURA))
                    {
                        con.Connection.FACTURA.Add(factura);
                        con.Connection.SaveChanges();
                        return Ok("Factura agregada correctamente");
                    }
                    return BadRequest("El código ingresado ya se encuentra registrado dentro de la platafoma");
                }
            }
            catch (Exception)
            {

                return BadRequest("Ha ocurrido un error al momento de ingresar una nueva factura. Verifique que todos los campos estén rellenos");
            }
            return BadRequest("Ha ocurrido un error al momento de ingresar una nueva factura");
        }

        [HttpDelete]
        public IHttpActionResult DeleteFactura(decimal id)
        {
            var result = con.Connection.FACTURA.FirstOrDefault(x=>x.NUMERO_FACTURA == id);

            if (result != null)
            {
                con.Connection.FACTURA.Remove(result);
                con.Connection.SaveChanges();
                return Ok("Factura eliminada correctamente");
            }
            return BadRequest("El código ingresado no existe dentro de la plataforma");
        }

        private bool FacturaBusqueda(decimal val)
        {
            var result = con.Connection.FACTURA.FirstOrDefault(x => x.NUMERO_FACTURA == val);
            if (result == null)
            {
                return true;
            }
            return false;
        }
    }
}
