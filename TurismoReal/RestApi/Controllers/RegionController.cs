using RestApi.Models.TR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TR.Lógica;

namespace RestApi.Controllers
{
    public class RegionController : ApiController
    {
        private Entities db = new Entities();

        [HttpGet]
        public IHttpActionResult GetRegionById(int id)
        {
            var data = db.REGION.FirstOrDefault(u => u.REGION_ID == id);

            if (data != null)
            {
                Region region = new Region
                {
                    NOMBRE_REGION = data.NOMBRE_REGION,
                    REGION_CARDINAL = data.REGION_CARDINAL,
                    REGION_ID = data.REGION_ID
                };

                return Ok(region);
            }
            return BadRequest();
        }
    }
}
