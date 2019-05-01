using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_LoginUsers.Models;
using DataAccess;
using tecAirlinesServices;
using tecAirlinesServices.Logic;
using tecAirlinesServices.Models;

namespace tecAirlinesServices.Controllers
{
    public class PayController : ApiController
    {
        private PayLogic reservationLogic = new PayLogic();

       

        /// <summary>
        /// Protocolo de añadir un reserva vuelo
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("api/pay/add")]
        [HttpPost]
        public IHttpActionResult AddTarget([FromBody] PayData data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (reservationLogic.AddTarget(data))
            {
                //petición correcta y se ha creado un nuevo recurso code 201
                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                //No se pudo crear el recurso por un error interno code 500
                return InternalServerError();
            }

        }

       



    }
}

