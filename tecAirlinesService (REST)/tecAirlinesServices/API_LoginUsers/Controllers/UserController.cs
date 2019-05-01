using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DataAccess;
using tecAirlinesServices;
using tecAirlinesServices.Logic;
using tecAirlinesServices.Models;

namespace tecAirlinesServices.Controllers
{
    //[EnableCors(origins: "http://localhost:57363", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private UserLogic userLogic = new UserLogic();
        private ProgramLogic  programLogic = new ProgramLogic();
        private ReservationLogic reservationLogic = new ReservationLogic();

        /// <summary>
        /// Protocolos de obtener todos los usuarios
        /// </summary>
        /// <returns></returns>
        [Route("api/user")]
        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            List<object> list = new List<object>();
            list = userLogic.GetUsers();
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
        /// protocolo de obtener un usuario especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/user/{id}/{id2}")]
        [HttpGet]
        public IHttpActionResult GetUser(string id, string id2)
        {
            if (!userLogic.ExistUser(id))
            {
                //No se encontró el recurso code 404
                return NotFound();
            }
            UserData user = userLogic.GetUser(id, id2);
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
        /// Protocolo de añadir un nuevo usuario
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("api/user/add")]
        [HttpPost]
        public IHttpActionResult AddUser([FromBody] UserData data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (userLogic.AddUser(data))
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
        /// Protocolo para actualizar un usuario
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        //[Route("api/user/update")]
        [HttpPut]
        public IHttpActionResult UpdateEmployee([FromBody] ReservationData data)
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
        /// Protocolo para eliminar un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/user/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteEmployee(string id)
        {
            if (!userLogic.ExistUser(id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (userLogic.DeleteUser(id))
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

