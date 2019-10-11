using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.negocio.Clases;
using TR.negocio.Conexión;
using TR.negocio.Validaciones;

namespace TR.servicio.Controllers
{
    public class AccesoController : ApiController
    {
        private ConexionEntities Conn = new ConexionEntities();
        private Validaciones validaciones = new Validaciones(); 

        //Servicio que permite verificar el inicio de sesión de un usuario
        [HttpPost]
        public IHttpActionResult PostAcceso(TR_Acceso acceso)
        {
            try
            {
                var result = Conn.Connection.USUARIO.FirstOrDefault(x => x.USUARIO1 == acceso.USUARIO1 && x.CONTRASENA == acceso.CONTRASENA);

                if (ModelState.IsValid)
                {
                    if (result != null)
                    {
                        return Ok(validaciones.ValidarDatos(result.ESTADO_ID, result.TIPO_USUARIO_CODIGO));
                    }
                    return BadRequest("Las credenciales ingresadas no son correctas");
                }
            }
            catch (Exception)
            {
                return BadRequest("Ha ocurrido un error al momento de iniciar sesión");
            }
            return BadRequest();
        }
        
        //Servicio que permite registrar a un cliente en el sistema
        [HttpGet]
        public IHttpActionResult PostCliente(TR.dato.CLIENTE cliente)
        {
            if (ModelState.IsValid)
            {
                if (UserExist(cliente.RUN_CLIENTE))
                {
                    var val1 = validaciones.ValidateEmpty(cliente.APELLIDO_MATERNO);
                    var val2 = validaciones.ValidateEmpty(cliente.APELLIDO_PATERNO);
                    var val3 = validaciones.ValidateEmpty(cliente.DIRECCION);
                    var val4 = validaciones.ValidateEmpty(cliente.EMAIL);
                    var val5 = validaciones.ValidateEmpty(cliente.NOMBRE);
                    var val6 = validaciones.ValidateEmpty(cliente.RUN_CLIENTE);

                    if (!val1 && !val2 && !val3 && !val4 && !val5 && !val6)
                    {
                        Conn.Connection.CLIENTE.Add(cliente);
                        Conn.Connection.SaveChanges();
                        return Ok("Su cuenta ha sido registrada exitosamente");
                    }
                    return BadRequest("Todos los campos deben estar completos");
                }
                return BadRequest("El run ingresado ya se encuentra registrado en el sistema");
            }
            return BadRequest("Ha ocurrido un error al momento de crear su cuenta de usuario. Por favor, intentelo más tarde");
        }

        private bool UserExist(string id)
        {
            var result = Conn.Connection.CLIENTE.FirstOrDefault(x=>x.RUN_CLIENTE == id);

            if (result == null)
            {
                return true;
            }
            return false;
        }
    }
}
