using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tecAirlinesServices.Models;

namespace tecAirlinesServices.Logic
{
    public class ReservationLogic
    {
        /// <summary>
        /// Lista de reservaciones
        /// </summary>
        /// <returns></returns>
        public List<object> GetReservations()
        {
            List<Object> dataList = new List<object>();
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var reservationList = entities.Reservas.ToList();
                    int n = reservationList.Count;
                    if (n == 0)
                    {
                        dataList = null;
                        return dataList;
                    }
                    else
                    {

                        for (int i = 0; i < reservationList.Count; ++i)
                        {
                            ReservationData data = new ReservationData();
                            data.Codigo = reservationList.ElementAt(i).Codigo;
                            data.Chequeo = reservationList.ElementAt(i).Chequeo;
                            data.Equipaje = reservationList.ElementAt(i).Equipaje;
                            data.C_Vuelo = reservationList.ElementAt(i).C_Vuelo;
                           
                            dataList.Add(data);
                        }
                        return dataList;
                    }
                }
                catch
                {

                    dataList = null;
                    return dataList;

                }

            }
        }


        /// <summary>
        /// Get de un reservacion de un cliente especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ReservationData GetReservation(int id)
        {
            ReservationData reservation = new ReservationData();
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    if (!this.ExistReservation(id))
                    {
                        reservation = null;
                        return reservation;
                    }
                    var reserx = entities.Reservas.Find(id);
                    reservation.Codigo = reserx.Codigo;
                    reservation.Chequeo = reserx.Chequeo;
                    reservation.Equipaje = reserx.Equipaje;
                    reservation.C_Vuelo = reserx.C_Vuelo;


                    return reservation;

                }
                catch (Exception)
                {
                    reservation = null;
                    return reservation;
                }
            }
        }

        /// <summary>
        /// //Verifica si un reservacion existe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistReservation(int id)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                var i = entities.Reservas.Find(id);
                if (i == null) return false;
                else return true;
            }
        }

        /// <summary>
        /// Agrega un nuevo reservacion
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddReservation(ReservationData data)
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
                    int entity = entities.udsp_ins_reserva(data.C_Usuario, data.C_Vuelo, data.C_Economico, data.C_Ejecutivo);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Elimina un reservacion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteReservation(int id)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var ms = entities.Reservas.Find(id);
                    entities.Reservas.Remove(ms);
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Actualizar un Reservacion
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateReservation(ReservationData data)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {

                    var user = entities.Reservas.Find(data.Codigo);
                    //user.Nombre = data.Nombre;
                    //user.Apellido1 = data.Apellido1;
                    //user.Apellido2 = data.Apellido2;
                    user.Chequeo = data.Chequeo;
                    user.Equipaje = data.Equipaje;
                    //user.Carne = data.Carne;
                    //user.Correo = data.Correo;
                    //user.Universidad = data.Universidad;
                    //user.Contraseña = data.Contraseña;
                    entities.SaveChanges();
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