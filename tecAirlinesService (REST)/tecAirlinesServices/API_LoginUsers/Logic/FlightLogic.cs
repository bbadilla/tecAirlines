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
                            data.C_Economico = flightList.ElementAt(i).C_Economico;
                            data.C_Ejecutivo = flightList.ElementAt(i).C_Ejecutivo;
                            data.F_Salida = flightList.ElementAt(i).F_Salida;
                            data.F_Llegada = flightList.ElementAt(i).F_Llegada;
                            data.A_Salida = flightList.ElementAt(i).A_Salida;
                            data.A_Llegada = flightList.ElementAt(i).A_Llegada;
                            data.Millas = flightList.ElementAt(i).Millas;
                            data.ID_Aeronave = flightList.ElementAt(i).ID_Aeronave;
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
        public FlightData GetFlight(string ASal, string ALle)
        {
            FlightData flight = new FlightData();
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                string id = entities.Vueloes.Where(e => e.A_Salida == ASal).ToList().First().Codigo;
                string id1 = entities.Vueloes.Where(e => e.A_Llegada == ALle).ToList().First().Codigo;
                try
                {
                    if (!this.ExistFlight(id)|| !this.ExistFlight(id1))
                    {
                        flight = null;
                        return flight;
                    }
                    var vuelox = entities.Vueloes.Find(id);
                    flight.Codigo = vuelox.Codigo;
                    flight.Estado = vuelox.Estado;
                    flight.C_Ejecutivo = vuelox.C_Ejecutivo;
                    flight.C_Economico = vuelox.C_Economico;
                    flight.F_Salida = vuelox.F_Salida;
                    flight.F_Llegada = vuelox.F_Llegada;
                    flight.A_Salida = vuelox.A_Salida;
                    flight.A_Llegada = vuelox.A_Llegada;
                    flight.Millas = vuelox.Millas;
                    flight.ID_Aeronave = vuelox.ID_Aeronave;
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
        /// //Verifica si un avion existe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistFlight_codigo(string id)
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
                    int entity = entities.udsp_ins_vuelo( data.Codigo, data.C_Ejecutivo, data.C_Economico, data.F_Salida, data.F_Llegada, data.A_Salida, data.A_Llegada, data.Millas, data.ID_Aeronave);
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
                    flight.C_Ejecutivo = data.C_Ejecutivo;
                    flight.C_Economico = data.C_Economico;
                    flight.F_Salida = data.F_Salida;
                    flight.F_Llegada = data.F_Llegada;
                    flight.A_Salida = data.A_Salida;
                    flight.A_Llegada = data.A_Llegada;
                    flight.Millas = data.Millas;
                    flight.ID_Aeronave = data.ID_Aeronave;
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