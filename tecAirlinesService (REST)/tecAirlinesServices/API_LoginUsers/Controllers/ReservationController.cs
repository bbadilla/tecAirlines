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
    public class ReservationController : ApiController
    {
        private ReservationLogic reservationLogic = new ReservationLogic();

        /// <summary>
        /// Protocolos de obtener todos los vuelos
        /// </summary>
        /// <returns></returns>
        [Route("api/reservation")]
        [HttpGet]
        public IHttpActionResult GetReservations()
        {
            List<object> list = new List<object>();
            list = reservationLogic.GetReservations();
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
        /// protocolo de obtener un reserva especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/reservation/{id}")]
        [HttpGet]
        public IHttpActionResult GetReservation(int id)
        {
            if (!reservationLogic.ExistReservation(id))
            {
                //No se encontró el recurso code 404
                return NotFound();
            }
            ReservationData user = reservationLogic.GetReservation(id);
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
        /// Protocolo de añadir un reserva vuelo
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("api/reservation/add")]
        [HttpPost]
        public IHttpActionResult AddReservation([FromBody] ReservationData data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (reservationLogic.AddReservation(data))
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
        /// Protocolo para actualizar un avion
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        //[Route("api/reservation")]
        [HttpPut]
        public IHttpActionResult UpdateReservation([FromBody] ReservationData data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (!reservationLogic.ExistReservation(data.Codigo))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (reservationLogic.UpdateReservation(data))
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
        /// Protocolo para eliminar un avion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/reservation/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteReservation(int id)
        {
            if (!reservationLogic.ExistReservation(id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (reservationLogic.DeleteReservation(id))
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

