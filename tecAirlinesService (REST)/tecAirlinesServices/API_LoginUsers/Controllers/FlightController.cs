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
        //tecAirlinesEntities entities = new tecAirlinesEntities();

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
        [Route("api/flight/{id}/{id1}")]
        [HttpGet]
        public IHttpActionResult GetFlight(string id, string id1)
        {
            //string Aux1 = entities.Vueloes.Where(e => e.A_Salida == id).ToList().First().Codigo;
            //string Aux2 = entities.Vueloes.Where(e => e.A_Llegada == id1).ToList().First().Codigo;

            //if (!flightLogic.ExistFlight(Aux1)|| !flightLogic.ExistFlight(Aux2))
            //{
            //    //No se encontró el recurso code 404
            //    return NotFound();
            //}
            FlightData user = flightLogic.GetFlight(id, id1);
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
        /// <returns></returns>
        //[Route("api/airship/update")]
        [HttpPut]
        public IHttpActionResult UpdateFlight([FromBody] FlightData data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (!flightLogic.ExistFlight_codigo(data.Codigo))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (flightLogic.UpdateFlight(data))
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
            if (!flightLogic.ExistFlight_codigo(id))
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

