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
    public class FlightController : ApiController
    {
        private FlightLogic flightLogic = new FlightLogic();

        /// <summary>
        /// Protocolos de obtener todos los vuelos
        /// </summary>
        /// <returns></returns>
        [Route("api/flight")]
        [HttpGet]
        public IHttpActionResult GetFlights()
        {
            List<object> list = new List<object>();
            list = flightLogic.GetFlights();
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
        /// protocolo de obtener un vuelo especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/flight/{id}")]
        [HttpGet]
        public IHttpActionResult GetFlight(string id)
        {
            if (!flightLogic.ExistFlight(id))
            {
                //No se encontró el recurso code 404
                return NotFound();
            }
            FlightData user = flightLogic.GetFlight(id);
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
        /// Protocolo de añadir un nuevo vuelo
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("api/flight/add")]
        [HttpPost]
        public IHttpActionResult AddFlight([FromBody] FlightData data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (flightLogic.AddFlight(data))
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
        ///// <returns></returns>
        [Route("api/flight/close")]
        [HttpPut]
        public IHttpActionResult CloseFlight([FromBody] FlightData data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (!flightLogic.ExistFlight(data.Codigo))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (flightLogic.CloseFlight(data))
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

        [Route("api/flight/open")]
        [HttpPut]
        public IHttpActionResult OpenFlight([FromBody] FlightData data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (!flightLogic.ExistFlight(data.Codigo))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (flightLogic.OpenFlight(data))
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
        [Route("api/flight/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteFlight(string id)
        {
            if (!flightLogic.ExistFlight(id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (flightLogic.DeleteFlight(id))
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

