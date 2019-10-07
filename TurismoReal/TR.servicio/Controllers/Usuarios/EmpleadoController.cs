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
    public class EmpleadoController : ApiController
    {
        private ConexionEntities Conn = new ConexionEntities();
        private Validaciones Validaciones = new Validaciones();

        [HttpGet]
        public IEnumerable<Empleado> GetEmpleado()
        {
            var list = Conn.Connection.EMPLEADO.ToList();
            List<Empleado> ListEmpleado = new List<Empleado>();

            foreach (var i in list)
            {
                Empleado emp = new Empleado
                {
                    APELLIDO_MATERNO = i.APELLIDO_MATERNO,
                    APELLIDO_PATERNO = i.APELLIDO_PATERNO,
                    CARGO = i.CARGO,
                    DIRECCION = i.DIRECCION,
                    EMAIL = i.EMAIL,
                    NOMBRE = i.NOMBRE,
                    RUN_EMPLEADO = i.RUN_EMPLEADO,
                    FECHA_NACIMIENTO = i.FECHA_NACIMIENTO,
                    TELEFONO = i.TELEFONO,
                    COMUNA_NOMBRE = i.COMUNA.NOMBRE_COMUNA,
                    ESTADO_DESCRIPCION = i.USUARIO1.ESTADO.DESCRIPCION,
                    ESTADO_ENTIDAD = i.USUARIO1.ESTADO.ENTIDAD,
                    SUCURSAL_DIRECCION = i.SUCURSAL.DIRECCION,
                    SUCURSAL_TELEFONO = i.SUCURSAL.TELEFONO,
                    TIPO_USUARIO_DESCRIPCION = i.USUARIO1.TIPO_USUARIO.DESCRIPCION,
                    USUARIO_CONTRASENA = i.USUARIO1.CONTRASENA,
                    USUARIO_RUN = i.USUARIO1.USUARIO1
                };
                ListEmpleado.Add(emp);
            }
            return ListEmpleado.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetEmpleado(string id)
        {
            var result = Conn.Connection.EMPLEADO.FirstOrDefault(x=>x.RUN_EMPLEADO == id);

            if (result != null)
            {
                Empleado emp = new Empleado
                {
                    APELLIDO_MATERNO = result.APELLIDO_MATERNO,
                    APELLIDO_PATERNO = result.APELLIDO_PATERNO,
                    CARGO = result.CARGO,
                    DIRECCION = result.DIRECCION,
                    EMAIL = result.EMAIL,
                    NOMBRE = result.NOMBRE,
                    RUN_EMPLEADO = result.RUN_EMPLEADO,
                    FECHA_NACIMIENTO = result.FECHA_NACIMIENTO,
                    TELEFONO = result.TELEFONO,
                    COMUNA_NOMBRE = result.COMUNA.NOMBRE_COMUNA,
                    ESTADO_DESCRIPCION = result.USUARIO1.ESTADO.DESCRIPCION,
                    ESTADO_ENTIDAD = result.USUARIO1.ESTADO.ENTIDAD,
                    SUCURSAL_DIRECCION = result.SUCURSAL.DIRECCION,
                    SUCURSAL_TELEFONO = result.SUCURSAL.TELEFONO,
                    TIPO_USUARIO_DESCRIPCION = result.USUARIO1.TIPO_USUARIO.DESCRIPCION,
                    USUARIO_CONTRASENA = result.USUARIO1.CONTRASENA,
                    USUARIO_RUN = result.USUARIO1.USUARIO1
                };
                return Ok(emp);
            }
            return BadRequest("El run ingresado no se encuentra registrado en el sistema");
        }

        [HttpPost]
        public IHttpActionResult PostEmpleado(TR.dato.EMPLEADO empleado)
        {
            if (ModelState.IsValid)
            {
                if (UserExists(empleado.RUN_EMPLEADO))
                {
                    var val1 = Validaciones.ValidateEmpty(empleado.APELLIDO_MATERNO);
                    var val2 = Validaciones.ValidateEmpty(empleado.APELLIDO_PATERNO);
                    var val3 = Validaciones.ValidateEmpty(empleado.CARGO);
                    var val4 = Validaciones.ValidateEmpty(empleado.DIRECCION);
                    var val5 = Validaciones.ValidateEmpty(empleado.EMAIL);
                    var val6 = Validaciones.ValidateEmpty(empleado.NOMBRE);
                    var val7 = Validaciones.ValidateEmpty(empleado.RUN_EMPLEADO);
                    var val8 = Validaciones.ValidateEmpty(empleado.TELEFONO);

                    if (!val1 && !val2 && !val3 && !val4 && !val5 && !val6 && !val7 && val8)
                    {
                        if (Validaciones.largeRun(empleado.RUN_EMPLEADO))
                        {
                            Conn.Connection.EMPLEADO.Add(empleado);
                            Conn.Connection.SaveChanges();
                            return Ok("Empleado registro correctamente");
                        }
                        return BadRequest("Ingrese un run sin puntos ni guión");
                    }
                    return BadRequest("Todos los campos deben estar completos");
                }
                return BadRequest("El run ingresado ya se encuentra registrado en el sistema");
            }
            return BadRequest("Ha ocurrido un error al momento de registrar un nuevo empleado");
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmpleado(string id)
        {
            var result = Conn.Connection.EMPLEADO.FirstOrDefault(x=>x.RUN_EMPLEADO == id);

            if (result != null)
            {
                Conn.Connection.EMPLEADO.Remove(result);
                Conn.Connection.SaveChanges();
                return Ok("Empleado eliminado correctamente");
            }
            return BadRequest("El run ingresado no se encuentra registrado en el sistema");
        }

        [HttpPut]
        public IHttpActionResult PutUsuario(string id, TR.dato.EMPLEADO empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Ha ocurrido un error al momento de actualizar al empleado. Por favor, intentelo más tarde");
            }
            if (id != empleado.RUN_EMPLEADO)
            {
                return BadRequest("El run del empleado que desea actualizar no se encuentra registrado");
            }

            Conn.Connection.Entry(empleado).State = EntityState.Modified;

            try
            {
                Conn.Connection.SaveChanges();
                return Ok("Emepleado actualizado correctamente");
            }
            catch (DbUpdateConcurrencyException)
            {

                return BadRequest("Error al mmento de actualizar al empleado");
            }
        }

        private bool UserExists(string id)
        {
            var result = Conn.Connection.EMPLEADO.FirstOrDefault(x=>x.RUN_EMPLEADO == id);

            if (result == null)
            {
                return true;
            }
            return false;
        }
    }
}
