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
    public class PaqueteProductoController : ApiController
    {
        private ConexionEntities con = new ConexionEntities();
        private Validaciones validaciones = new Validaciones();

        [HttpGet]
        public IEnumerable<TR_PaqueteProducto> GetPaquete()
        {
            var list = con.Connection.PAQUETE_PRODUCTO.Select(x=> new TR_PaqueteProducto {
                PAQUETE_ID = x.PAQUETE_ID,
                TOTAL = x.TOTAL,
                TRASLADO = x.TRASLADO,
                DEPARTAMENTO_DIRECCION = x.DEPARTAMENTO.DIRECCION,
                DEPARTAMENTO_NOMBRE = x.DEPARTAMENTO.NOMBRE,
                DEPARTAMENTO_SUPERFICIE = x.DEPARTAMENTO.SUPERFICIE,
                DEPARTAMENTO_VALOR = x.DEPARTAMENTO.VALOR,
                TOUR_ITINERARIO = x.TOUR.ITINERARIO_TOUR,
                TOUR_NOMBRE = x.TOUR.NOMBRE_TOUR,
                TOUR_VALOR = x.TOUR.VALOR_TOUR
            });

            return list.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetProducto(int id)
        {
            var result = con.Connection.PAQUETE_PRODUCTO.Where(x => x.PAQUETE_ID == id).Select(x=>new TR_PaqueteProducto {
                PAQUETE_ID = x.PAQUETE_ID,
                TOTAL = x.TOTAL,
                TRASLADO = x.TRASLADO,
                DEPARTAMENTO_DIRECCION = x.DEPARTAMENTO.DIRECCION,
                DEPARTAMENTO_NOMBRE = x.DEPARTAMENTO.NOMBRE,
                DEPARTAMENTO_SUPERFICIE = x.DEPARTAMENTO.SUPERFICIE,
                DEPARTAMENTO_VALOR = x.DEPARTAMENTO.VALOR,
                TOUR_ITINERARIO = x.TOUR.ITINERARIO_TOUR,
                TOUR_NOMBRE = x.TOUR.NOMBRE_TOUR,
                TOUR_VALOR = x.TOUR.VALOR_TOUR
            }); ;
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult PostPaquete(TR.dato.PAQUETE_PRODUCTO producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    con.Connection.PAQUETE_PRODUCTO.Add(producto);
                    con.Connection.SaveChanges();
                    return Ok("Se ha agregado exitosamente un nuevo paquete de producto");
                }
                return BadRequest("El modelo de clases no es correcto. Verifique si los campos son válidos");
            }
            catch (Exception)
            {

                return BadRequest("Ha ocurrido un error al momento de agregar un paquete de producto. Verifique que todos los campos estén correctos");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteProducto(int id)
        {
            var result = con.Connection.PAQUETE_PRODUCTO.FirstOrDefault(x=>x.PAQUETE_ID == id);

            if (result != null)
            {
                con.Connection.PAQUETE_PRODUCTO.Remove(result);
                con.Connection.SaveChanges();
                return Ok("El paquete ha sido eliminado correctamente");
            }
            return BadRequest("El código ingresado no se encuentra registrado dentro de la plataforma");
        }
    }
}
