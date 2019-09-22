using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace RestApi.Controllers
{
    public class UsuarioController : ApiController
    {
        private Entities db = new Entities();

        //GET api/Usuario
        public IQueryable<USUARIO> GetClientes()
        {
            return db.USUARIO;
        }

        //POST api/Cliente
        [ResponseType(typeof(USUARIO))]
        public IHttpActionResult PostClientes(USUARIO usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.USUARIO.Add(usuario);
                db.SaveChanges();
                return CreatedAtRoute("DefaultApi", new { id = usuario.USUARIO1 }, usuario);
            }
            catch (DbEntityValidationException ex)
            {

                foreach (var validation in ex.EntityValidationErrors)
                {
                    foreach (var va in validation.ValidationErrors)
                    {
                        Trace.TraceInformation("propiedad:  {0} DbValidationError: {1}", va.PropertyName,va.ErrorMessage);
                    }
                }
            }
            return CreatedAtRoute("DefaultApi", new { id = usuario.USUARIO1 }, usuario);
        }
    }
}
