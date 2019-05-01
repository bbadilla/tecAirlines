using API_LoginUsers.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tecAirlinesServices.Models;

namespace tecAirlinesServices.Logic
{
    public class PayLogic
    {
      
        /// <summary>
        /// Agrega un nuevo reservacion
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddTarget(PayData data)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                //Reserva newReservation = new Reserva();
                //newReservation.Codigo = data.Codigo;
                //newReservation.Chequeo = data.Chequeo;
                //newReservation.Equipaje = data.Equipaje;
                //newReservation.C_Vuelo = data.C_Vuelo;

                try
                {
                    //entities.Reservas.Add(newReservation);
                    //entities.SaveChanges();
                    int entity = entities.udsp_ins_pago(data.Numero, data.Contraseña, data.Expiracion, data.Titular, data.C_Reserva);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

       

    }
}