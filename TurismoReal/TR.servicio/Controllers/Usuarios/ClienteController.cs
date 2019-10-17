using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases;
using TR.negocio.Conexión;
using TR.negocio.Validaciones;

namespace TR.servicio.Controllers.Usuarios
{
    public class ClienteController : ApiController
    {
        private ConexionEntities con = new ConexionEntities();
        private Validaciones Validacion = new Validaciones();

        [HttpGet]
        public IEnumerable<TR_Cliente> GetCliente()
        {
            var list = con.Connection.CLIENTE.ToList();
            List<TR_Cliente> ListCliente = new List<TR_Cliente>();

            foreach (var i in list)
            {
                TR_Cliente cliente = new TR_Cliente
                {
                    APELLIDO_MATERNO = i.APELLIDO_MATERNO,
                    APELLIDO_PATERNO = i.APELLIDO_PATERNO,
                    DIRECCION = i.DIRECCION,
                    EMAIL = i.EMAIL,
                    NOMBRE = i.NOMBRE,
                    TELEFONO = i.TELEFONO,
                    FECHA_NACIMIENTO = i.FECHA_NACIMIENTO,
                    RUN_CLIENTE = i.RUN_CLIENTE,
                    USUARIO_NOMBRE = i.USUARIO1.USUARIO1,
                    USUARIO_CONTRASENA = i.USUARIO1.CONTRASENA,
                    ESTADO_DESCRIPCION = i.USUARIO1.ESTADO.DESCRIPCION,
                    ESTADO_ENTIDAD = i.USUARIO1.ESTADO.ENTIDAD,
                    TIPO_USUARIO_DESCRIPCION = i.USUARIO1.TIPO_USUARIO.DESCRIPCION
                };
                ListCliente.Add(cliente);
            }
            return ListCliente.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetCliente(string id)
        {
            try
            {
                var result = con.Connection.CLIENTE.FirstOrDefault(x => x.RUN_CLIENTE == id);

                if (result != null)
                {
                    TR_Cliente cliente = new TR_Cliente
                    {
                        APELLIDO_MATERNO = result.APELLIDO_MATERNO,
                        APELLIDO_PATERNO = result.APELLIDO_PATERNO,
                        DIRECCION = result.DIRECCION,
                        EMAIL = result.EMAIL,
                        FECHA_NACIMIENTO = result.FECHA_NACIMIENTO,
                        RUN_CLIENTE = result.RUN_CLIENTE,
                        NOMBRE = result.NOMBRE,
                        TELEFONO = result.TELEFONO,
                        USUARIO_NOMBRE = result.USUARIO1.USUARIO1,
                        USUARIO_CONTRASENA = result.USUARIO1.CONTRASENA,
                        ESTADO_DESCRIPCION = result.USUARIO1.ESTADO.DESCRIPCION,
                        ESTADO_ENTIDAD = result.USUARIO1.ESTADO.ENTIDAD,
                        TIPO_USUARIO_DESCRIPCION = result.USUARIO1.TIPO_USUARIO.DESCRIPCION
                    };
                    return Ok(cliente);
                }
                return BadRequest("El run ingresado no se encuentra registrado dentro de la base de datos");
            }
            catch (Exception)
            {
                return BadRequest("Se ha producido un error al momento de registrar un nuevo empelado");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteCliente(string id)
        {
            var result = con.Connection.CLIENTE.FirstOrDefault(x=>x.RUN_CLIENTE == id);

            if (result != null)
            {
                con.Connection.CLIENTE.Remove(result);
                con.Connection.SaveChanges();
                return Ok("Cliente eliminado");
            }
            return BadRequest("El run ingresado no se encuentra registrado dentro del sistema");
        }

        [HttpPut]
        public IHttpActionResult PutCliente(string id, TR.dato.CLIENTE cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Ha ocurrido un error al momento de actualizar al cliente. Por favor, intentelo más tarde");
            }
            if (id != cliente.RUN_CLIENTE)
            {
                return BadRequest("El run del cliente que desea actualizar no se encuentra registrado");
            }

            con.Connection.Entry(cliente).State = EntityState.Modified;

            try
            {
                con.Connection.SaveChanges();
                return Ok("Cliente actualizado correctamente");
            }
            catch (DbUpdateConcurrencyException)
            {

                return BadRequest("Error al momento de actualizar al usuario");
            }
        }
    }
}
