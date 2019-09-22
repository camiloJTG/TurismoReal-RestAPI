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
    public class ClienteController : ApiController
    {
        private Entities db = new Entities();

        //GET api/Cliente
        public IQueryable<CLIENTE> GetClientes()
        {
            return db.CLIENTE;
        }

        //GET api/Cliente/value
        [ResponseType(typeof(CLIENTE))]
        public IHttpActionResult Getuser(string id)
        {
            CLIENTE cliente = db.CLIENTE.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        //POST api/Cliente
        [ResponseType(typeof(CLIENTE))]
        public IHttpActionResult Postuser(CLIENTE cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CLIENTE.Add(cliente);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = cliente.RUN_CLIENTE}, cliente);
        }
    }
}
