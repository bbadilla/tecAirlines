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
    public class ProgramController : ApiController
    {
        private ProgramLogic programLogic = new ProgramLogic();

        /// <summary>
        /// Protocolos de obtener todos los programas
        /// </summary>
        /// <returns></returns>
        [Route("api/program")]
        [HttpGet]
        public IHttpActionResult GetPrograms()
        {
            List<object> list = new List<object>();
            list = programLogic.GetPrograms();
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
        /// protocolo de obtener un programa de un usuario especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/program/{id}")]
        [HttpGet]
        public IHttpActionResult GetProgram(string id)
        {
            if (!programLogic.ExistProgram(id))
            {
                //No se encontró el recurso code 404
                return NotFound();
            }
            ProgramData user = programLogic.GetProgram(id);
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
        /// Protocolo de añadir un nuevo programa
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("api/program/add")]
        [HttpPost]
        public IHttpActionResult AddProgram([FromBody] ProgramData data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (programLogic.AddProgram(data))
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
        /// Protocolo para actualizar un programa
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        //[Route("api/airship/update")]
        [HttpPut]
        public IHttpActionResult UpdateFlight([FromBody] ProgramData data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (!programLogic.ExistProgram(data.C_Usuario))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (programLogic.UpdateProgram(data))
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
        [Route("api/program/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteProgram(string id)
        {
            if (!programLogic.ExistProgram(id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (programLogic.DeleteProgram(id))
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

