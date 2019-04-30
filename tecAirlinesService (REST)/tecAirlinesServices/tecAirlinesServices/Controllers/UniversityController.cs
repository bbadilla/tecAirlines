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
    public class UniversityController : ApiController
    {
        private UniversityLogic universityLogic = new UniversityLogic();

        /// <summary>
        /// Protocolos de obtener todos los universidades
        /// </summary>
        /// <returns></returns>
        [Route("api/university")]
        [HttpGet]
        public IHttpActionResult GetUniversitys()
        {
            List<object> list = new List<object>();
            list = universityLogic.GetUniversitys();
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
        /// protocolo de obtener un universidad especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/university/{id}")]
        [HttpGet]
        public IHttpActionResult GetUniversity(int id)
        {
            if (!universityLogic.ExistUniversity(id))
            {
                //No se encontró el recurso code 404
                return NotFound();
            }
            UniversityData user = universityLogic.GetUniversity(id);
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
        /// Protocolo de añadir un nuevo universidad
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("api/university/add")]
        [HttpPost]
        public IHttpActionResult AddUniversity([FromBody] UniversityData data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (universityLogic.AddUniversity(data))
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
        /// Protocolo para actualizar un universidad
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        //[Route("api/airship/update")]
        [HttpPut]
        public IHttpActionResult UpdateUniversity([FromBody] UniversityData data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (!universityLogic.ExistUniversity(data.Identificador))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (universityLogic.UpdateUniversity(data))
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
        /// Protocolo para eliminar un universidad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/university/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteUniversity(int id)
        {
            if (!universityLogic.ExistUniversity(id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (universityLogic.DeleteUniversity(id))
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

