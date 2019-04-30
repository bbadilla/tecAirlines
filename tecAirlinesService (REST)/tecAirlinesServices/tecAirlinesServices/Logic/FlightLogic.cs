using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tecAirlinesServices.Models;

namespace tecAirlinesServices.Logic
{
    public class FlightLogic
    {
        /// <summary>
        /// Lista de vuelos
        /// </summary>
        /// <returns></returns>
        public List<object> GetFlights()
        {
            List<Object> dataList = new List<object>();
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var flightList = entities.Vueloes.ToList();
                    int n = flightList.Count;
                    if (n == 0)
                    {
                        dataList = null;
                        return dataList;
                    }
                    else
                    {

                        for (int i = 0; i < flightList.Count; ++i)
                        {
                            FlightData data = new FlightData();
                            data.Codigo = flightList.ElementAt(i).Codigo;
                            data.Estado = flightList.ElementAt(i).Estado;
                            data.Costo = flightList.ElementAt(i).Costo;
                            data.F_Salida = flightList.ElementAt(i).F_Salida;
                            data.F_Llegada = flightList.ElementAt(i).F_Llegada;
                            data.Millas = flightList.ElementAt(i).Millas;
                            data.ID_Aeronave = flightList.ElementAt(i).ID_Aeronave;
                            data.A_Economicos = flightList.ElementAt(i).A_Economicos;
                            data.A_Ejecutivos = flightList.ElementAt(i).A_Ejecutivos;
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
        public FlightData GetFlight(string id)
        {
            FlightData flight = new FlightData();
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    if (!this.ExistFlight(id))
                    {
                        flight = null;
                        return flight;
                    }
                    var vuelox = entities.Vueloes.Find(id);
                    flight.Codigo = vuelox.Codigo;
                    flight.Estado = vuelox.Estado;
                    flight.Costo = vuelox.Costo;
                    flight.F_Salida = vuelox.F_Salida;
                    flight.F_Llegada = vuelox.F_Llegada;
                    flight.Millas = vuelox.Millas;
                    flight.ID_Aeronave = vuelox.ID_Aeronave;
                    flight.A_Economicos = vuelox.A_Economicos;
                    flight.A_Ejecutivos = vuelox.A_Ejecutivos;

                    return flight;

                }
                catch (Exception)
                {
                    flight = null;
                    return flight;
                }
            }
        }

        /// <summary>
        /// //Verifica si un avion existe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistFlight(string id)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                var i = entities.Vueloes.Find(id);
                if (i == null) return false;
                else return true;
            }
        }

        /// <summary>
        /// Agrega un nuevo vuelo
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddFlight(FlightData data)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                Vuelo newFlight= new Vuelo();
                //newFlight.Codigo = data.Codigo;
                //newFlight.Estado = data.Estado;
                //newFlight.Costo = data.Costo;
                //newFlight.F_Salida = data.F_Salida;
                //newFlight.F_Llegada = data.F_Llegada;
                //newFlight.Millas = data.Millas;
                //newFlight.ID_Aeronave = data.ID_Aeronave;
                //newFlight.A_Economicos = data.A_Economicos;
                //newFlight.A_Ejecutivos = data.A_Ejecutivos;

                try
                {
                    //entities.Vueloes.Add(newFlight);
                    //entities.SaveChanges();
                    int entity = entities.sp_ins_vuelo(data.Codigo, data.Costo, data.F_Salida, data.F_Llegada, data.Millas, data.ID_Aeronave, data.A_Economicos, data.A_Ejecutivos);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Elimina un vuelo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFlight(string id)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var ms = entities.Vueloes.Find(id);
                    entities.Vueloes.Remove(ms);
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
        /// Actualizar un vuelo
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateFlight(FlightData data)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var flight = entities.Vueloes.Find(data.Codigo);
                    
                    flight.Codigo = data.Codigo;
                    flight.Estado = data.Estado;
                    flight.Costo = data.Costo;
                    flight.F_Salida = data.F_Salida;
                    flight.F_Llegada = data.F_Llegada;
                    flight.Millas = data.Millas;
                    flight.ID_Aeronave = data.ID_Aeronave;
                    flight.A_Economicos = data.A_Economicos;
                    flight.A_Ejecutivos = data.A_Ejecutivos;
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