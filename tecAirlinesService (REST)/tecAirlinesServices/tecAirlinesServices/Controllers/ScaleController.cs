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
    public class ScaleController : ApiController
    {
        private ScaleLogic scaleLogic = new ScaleLogic();

        /// <summary>
        /// Protocolos de obtener todos los escalas
        /// </summary>
        /// <returns></returns>
        [Route("api/scale")]
        [HttpGet]
        public IHttpActionResult GetScales()
        {
            List<object> list = new List<object>();
            list = scaleLogic.GetScales();
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
        /// protocolo de obtener un escala especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/scale/{id}")]
        [HttpGet]
        public IHttpActionResult GetScale(string id)
        {
            if (!scaleLogic.ExistScale(id))
            {
                //No se encontró el recurso code 404
                return NotFound();
            }
            ScaleData user = scaleLogic.GetScale(id);
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
        /// Protocolo de añadir un nuevo escala
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("api/scale/add")]
        [HttpPost]
        public IHttpActionResult AddScale([FromBody] ScaleData data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (scaleLogic.AddScale(data))
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
        /// Protocolo para actualizar un Escala
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        //[Route("api/airship/update")]
        [HttpPut]
        public IHttpActionResult UpdateScale([FromBody] ScaleData data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (!scaleLogic.ExistScale(data.C_Vuelo))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (scaleLogic.UpdateScale(data))
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
        [Route("api/scale/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteScale(string id)
        {
            if (!scaleLogic.ExistScale(id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (scaleLogic.DeleteScale(id))
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

