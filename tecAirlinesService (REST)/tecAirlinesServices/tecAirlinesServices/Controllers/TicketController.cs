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
    public class TicketController : ApiController
    {
        private TicketLogic ticketLogic = new TicketLogic();

        /// <summary>
        /// Protocolos de obtener todos los tickets
        /// </summary>
        /// <returns></returns>
        [Route("api/ticket")]
        [HttpGet]
        public IHttpActionResult GetTickets()
        {
            List<object> list = new List<object>();
            list = ticketLogic.GetTickets();
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

        /// <summary>
        /// protocolo de obtener un tiquete especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/ticket/{id}")]
        [HttpGet]
        public IHttpActionResult GetTicket(int id)
        {
            if (!ticketLogic.ExistTicket(id))
            {
                //No se encontró el recurso code 404
                return NotFound();
            }
            TicketData user = ticketLogic.GetTicket(id);
            if (user != null)
            {
                // ok code 200
                return Ok(user);
            }
            else
            {
                //No se pudo crear el recurso por un error interno code 500
                return InternalServerError();
            }
        }

        /// <summary>
        /// Protocolo de añadir un nuevo ticket
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("api/ticket/add")]
        [HttpPost]
        public IHttpActionResult AddTicket([FromBody] TicketData data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (ticketLogic.AddTicket(data))
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

        /// <summary>
        /// Protocolo para actualizar un tiquete
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        //[Route("api/airship/update")]
        [HttpPut]
        public IHttpActionResult UpdateTicket([FromBody] TicketData data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (!ticketLogic.ExistTicket(data.C_Reserva))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (ticketLogic.UpdateTicket(data))
            {
                //petición correcta y se ha creado un nuevo recurso code 200 ok
                return Ok();
            }
            else
            {
                //No se pudo crear el recurso por un error  code 500
                return InternalServerError();
            }

        }

        /// <summary>
        /// Protocolo para eliminar un tiquete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/ticket/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteTicket(int id)
        {
            if (!ticketLogic.ExistTicket(id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (ticketLogic.DeleteTicket(id))
            {
                //Se completó la solicitud con exito code 200 ok
                return Ok();
            }
            else
            {
                //No se completó la solicitud por un error interno code 500
                return InternalServerError();
            }

        }



    }
}

