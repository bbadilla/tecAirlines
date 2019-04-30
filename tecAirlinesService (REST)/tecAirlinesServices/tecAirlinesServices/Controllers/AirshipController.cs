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
    public class AirshipController : ApiController
    {
        private AirshipLogic airshipLogic = new AirshipLogic();

        /// <summary>
        /// Protocolos de obtener todos los aviones
        /// </summary>
        /// <returns></returns>
        [Route("api/airship")]
        [HttpGet]
        public IHttpActionResult GetAirships()
        {
            List<object> list = new List<object>();
            list = airshipLogic.GetAirships();
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
        /// protocolo de obtener un avion especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/airship/{id}")]
        [HttpGet]
        public IHttpActionResult GetAirship(int id)
        {
            if (!airshipLogic.ExistAirship(id))
            {
                //No se encontró el recurso code 404
                return NotFound();
            }
            AirshipData user = airshipLogic.GetAirship(id);
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
        /// Protocolo de añadir un nuevo avion
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("api/airship/add")]
        [HttpPost]
        public IHttpActionResult AddAirship([FromBody] AirshipData data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (airshipLogic.AddAirship(data))
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
        public IHttpActionResult UpdateAirship([FromBody] AirshipData data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (!airshipLogic.ExistAirship(data.Identificador))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (airshipLogic.UpdateAirship(data))
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
        [Route("api/airship/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteAirship(int id)
        {
            if (!airshipLogic.ExistAirship(id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (airshipLogic.DeleteAirship(id))
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

