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
    public class PromotionController : ApiController
    {
        private PromotionLogic promotionLogic = new PromotionLogic();

        /// <summary>
        /// Protocolos de obtener todos los promociones
        /// </summary>
        /// <returns></returns>
        [Route("api/promotion")]
        [HttpGet]
        public IHttpActionResult GetPromotions()
        {
            List<object> list = new List<object>();
            list = promotionLogic.GetPromotions();
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
        /// protocolo de obtener un promocion especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/promotion/{id}")]
        [HttpGet]
        public IHttpActionResult GetPromotion(string id)
        {
            if (!promotionLogic.ExistPromotion(id))
            {
                //No se encontró el recurso code 404
                return NotFound();
            }
            PromotionData user = promotionLogic.GetPromotion(id);
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
        /// Protocolo de añadir un nueva promocion
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("api/promotion/add")]
        [HttpPost]
        public IHttpActionResult AddPromotion([FromBody] PromotionData data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (promotionLogic.AddPromotion(data))
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
        public IHttpActionResult UpdatePromotion([FromBody] PromotionData data)
        {
            if (data == null)
            {
                //Bad request code 400
                return BadRequest();
            }
            if (!promotionLogic.ExistPromotion(data.C_Vuelo))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (promotionLogic.UpdatePromotion(data))
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
        [Route("api/promotion/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteFlight(string id)
        {
            if (!promotionLogic.ExistPromotion(id))
            {
                //petición correcta pero no pudo ser procesada porque no existe el archivo code 404
                return NotFound();
            }
            if (promotionLogic.DeletePromotion(id))
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

