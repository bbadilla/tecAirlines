using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tecAirlinesServices.Models;

namespace tecAirlinesServices.Logic
{
    public class TicketLogic
    {
        /// <summary>
        /// Lista de tickets
        /// </summary>
        /// <returns></returns>
        public List<object> GetTickets()
        {
            List<Object> dataList = new List<object>();
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var ticketsList = entities.Tiquetes.ToList();
                    int n = ticketsList.Count;
                    if (n == 0)
                    {
                        dataList = null;
                        return dataList;
                    }
                    else
                    {

                        for (int i = 0; i < ticketsList.Count; ++i)
                        {
                            TicketData data = new TicketData();
                            data.C_Reserva = ticketsList.ElementAt(i).C_Reserva;
                            data.N_Asiento = ticketsList.ElementAt(i).N_Asiento;
                          
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
        /// Get de un vuelo especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TicketData GetTicket(int id)
        {
            TicketData ticket = new TicketData();
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    if (!this.ExistTicket(id))
                    {
                        ticket = null;
                        return ticket;
                    }
                    var ticketx = entities.Tiquetes.Find(id);
                    ticket.C_Reserva = ticketx.C_Reserva;
                    ticket.N_Asiento = ticketx.N_Asiento;

                    return ticket;

                }
                catch (Exception)
                {
                    ticket = null;
                    return ticket;
                }
            }
        }

        /// <summary>
        /// //Verifica si un ticket existe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistTicket(int id)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                var i = entities.Tiquetes.Find(id);
                if (i == null) return false;
                else return true;
            }
        }

        /// <summary>
        /// Agrega un nuevo tiquete
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddTicket(TicketData data)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                Tiquete newTicket = new Tiquete();
                newTicket.C_Reserva = data.C_Reserva;
                newTicket.N_Asiento = data.N_Asiento;

                try
                {
                    entities.Tiquetes.Add(newTicket);
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
        /// Elimina un tiquete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteTicket(int id)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var ms = entities.Tiquetes.Find(id);
                    entities.Tiquetes.Remove(ms);
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
        /// Actualizar un tiquete
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateTicket(TicketData data)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var ticket = entities.Tiquetes.Find(data.C_Reserva);

                    ticket.C_Reserva = data.C_Reserva;
                    ticket.N_Asiento = data.N_Asiento;
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