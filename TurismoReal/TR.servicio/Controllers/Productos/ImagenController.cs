using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases;
using TR.negocio.Conexión;
using TR.negocio.Validaciones;

namespace TR.servicio.Controllers.Productos
{
    public class ImagenController : ApiController
    {
        private ConexionEntities con = new ConexionEntities();
        private Validaciones validaciones = new Validaciones();

        [HttpGet]
        public IEnumerable<TR_Imagen> GetImagen()
        {
            var list = con.Connection.IMAGEN.Select(x=> new TR_Imagen {
                DEPARTAMENTO_ID = x.DEPARTAMENTO_ID,
                ENTORNO_ID = x.ENTORNO_ID,
                IMAGEN_ENCODE64 = x.IMAGEN_ENCODE64,
                IMAGEN_ID = x.IMAGEN_ID,
                NOMBRE_IMAGEN = x.NOMBRE_IMAGEN,
                TOUR_ID = x.TOUR_ID
            });
            return list.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetImagen(int id)
        {
            var result = con.Connection.IMAGEN.Where(x=>x.IMAGEN_ID == id).Select(x=> new TR_Imagen {
                IMAGEN_ID = x.IMAGEN_ID,
                DEPARTAMENTO_ID = x.DEPARTAMENTO_ID,
                ENTORNO_ID = x.ENTORNO_ID,
                IMAGEN_ENCODE64 = x.IMAGEN_ENCODE64,
                NOMBRE_IMAGEN = x.NOMBRE_IMAGEN,
                TOUR_ID = x.TOUR_ID
            });

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("El código ingresado no se encuentra registrado en el sistema");
            {

            }
        }

        [HttpPost]
        public IHttpActionResult PostImagen(TR.dato.IMAGEN imagen)
        {
            try
            {
                if (!validaciones.ValidateEmpty(imagen.NOMBRE_IMAGEN))
                {
                    con.Connection.IMAGEN.Add(imagen);
                    con.Connection.SaveChanges();
                    return Ok("Imagen registrada correctamente");
                }
                return BadRequest("Todos los campos deben estar completos");
            }
            catch (Exception)
            {

                return BadRequest("Ha ocurrido un error al momento de ingresar una nueva imagen. Por favor, intentelo más tarde");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteImagen(int id)
        {
            var result = con.Connection.IMAGEN.FirstOrDefault(x=>x.IMAGEN_ID == id);

            if (result != null)
            {
                con.Connection.IMAGEN.Remove(result);
                con.Connection.SaveChanges();
                return Ok("Imagen eliminada correctamente");
            }
            return BadRequest("Ha ocurrido un error al momento de eliminar la imagen");
        }
    }
}
