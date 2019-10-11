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

namespace TR.servicio.Controllers.Productos
{
    public class DepartamentoController : ApiController
    {
        private ConexionEntities con = new ConexionEntities();
        private Validaciones validaciones = new Validaciones();

        [HttpGet]
        public IEnumerable<TR_Departamento> GetDepartamentos()
        {
            var list = con.Connection.DEPARTAMENTO.Select(x => new TR_Departamento {
                DEPARTAMENTO_ID = x.DEPARTAMENTO_ID,
                DIRECCION = x.DIRECCION,
                FECHA_CREACION = x.FECHA_CREACION,
                NOMBRE = x.NOMBRE,
                SUPERFICIE = x.SUPERFICIE,
                VALOR = x.VALOR,
                CONDICIONES_USO = x.CONDICIONES_USO,
                COMUNA_ID = x.COMUNA.COMUNA_ID,
                COMUNA_NOMBRE = x.COMUNA.NOMBRE_COMUNA,
                ESTADO_DESCRIPCION = x.ESTADO.DESCRIPCION,
                ESTADO_ENTIDAD = x.ESTADO.ENTIDAD,
                ESTADO_ID = x.ESTADO.ESTADO_ID
            });
            return list.ToList();
        }

        [HttpGet]
        public IHttpActionResult GetDepartamentos(int id)
        {
            var result = con.Connection.DEPARTAMENTO.Where(x=>x.DEPARTAMENTO_ID == id).Select(x=> new TR_Departamento{
                DEPARTAMENTO_ID = x.DEPARTAMENTO_ID,
                DIRECCION = x.DIRECCION,
                FECHA_CREACION = x.FECHA_CREACION,
                NOMBRE = x.NOMBRE,
                SUPERFICIE = x.SUPERFICIE,
                VALOR = x.VALOR,
                CONDICIONES_USO = x.CONDICIONES_USO,
                COMUNA_ID = x.COMUNA.COMUNA_ID,
                COMUNA_NOMBRE = x.COMUNA.NOMBRE_COMUNA,
                ESTADO_DESCRIPCION = x.ESTADO.DESCRIPCION,
                ESTADO_ENTIDAD = x.ESTADO.ENTIDAD,
                ESTADO_ID = x.ESTADO.ESTADO_ID
            });

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("El código ingresado no se encuentra registrado en la base de datos");
        }

        [HttpPost]
        public IHttpActionResult PostDepartamento(TR.dato.DEPARTAMENTO departamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (DepartmentExists(departamento.DEPARTAMENTO_ID))
                    {
                        var val1 = validaciones.ValidateEmpty(departamento.NOMBRE);
                        var val2 = validaciones.ValidateEmpty(departamento.DIRECCION);
                        var val3 = validaciones.ValidateEmpty(departamento.SUPERFICIE);
                        var val4 = validaciones.ValidateEmpty(departamento.CONDICIONES_USO);

                        if (!val1 && !val2 && !val3 && !val4)
                        {
                            con.Connection.DEPARTAMENTO.Add(departamento);
                            con.Connection.SaveChanges();
                            return Ok("Departamento registrado correctamente");
                        }
                        return BadRequest("Todos los campos deben estar completos");
                    }
                    return BadRequest("El código del departamento ingresado ya exite");
                }
                return BadRequest("Error al ingresar un nuevo departamento, por favor intentelo nuevamente");
            }
            catch (ArgumentNullException)
            {

                return BadRequest("Todos los campos deben deben estar completos");
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteDepartamento(int id)
        {
            var result = con.Connection.DEPARTAMENTO.FirstOrDefault(x=>x.DEPARTAMENTO_ID == id);

            if (result != null)
            {
                con.Connection.DEPARTAMENTO.Remove(result);
                con.Connection.SaveChanges();
                return Ok("Departamento eliminado correctamente");
            }
            return BadRequest("El código del departamento ingresado no se encuentra registrado dentro de la base de datos");
        }

        [HttpPut]
        public IHttpActionResult PutUsuario(int id, TR.dato.DEPARTAMENTO departamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Ha ocurrido un error al momento de actualizar el departamento. Por favor, intentelo más tarde");
            }
            if (id != departamento.DEPARTAMENTO_ID)
            {
                return BadRequest("El código del departamento que desea actualizar no se encuentra registrado");
            }

            con.Connection.Entry(departamento).State = EntityState.Modified;

            try
            {
                con.Connection.SaveChanges();
                return Ok("Departamento actualizado correctamente");
            }
            catch (DbUpdateConcurrencyException)
            {

                return BadRequest("Error al momento de actualizar el departamento");
            }
        }

        private bool DepartmentExists(decimal id)
        {
            var result = con.Connection.DEPARTAMENTO.FirstOrDefault(x => x.DEPARTAMENTO_ID == id);
            if (result == null)
            {
                return true;
            }
            return false;
        }
    }
}
