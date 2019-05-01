using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess;
using tecAirlinesServices;
using tecAirlinesServices.Logic;
using tecAirlinesServices.Models;

namespace tecAirlinesServices.Controllers
{
    public class AirportController : ApiController
    {
        private AirportLogic airshipLogic = new AirportLogic();

        /// <summary>
        /// Protocolos de obtener todos los aviones
        /// </summary>
        /// <returns></returns>
        [Route("api/airport")]
        [HttpGet]
        public IHttpActionResult GetAirships()
        {
            List<object> list = new List<object>();
            list = airshipLogic.GetAirports();
            if (list == null)
            {
                //La respuesta no tiene contenido code 204
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                // ok code 200
                return Ok(list);
            }

        }

    }
}
