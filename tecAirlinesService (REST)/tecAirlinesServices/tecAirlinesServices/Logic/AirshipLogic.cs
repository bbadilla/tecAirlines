using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tecAirlinesServices.Models;

namespace tecAirlinesServices.Logic
{
    public class AirshipLogic
    {
        /// <summary>
        /// Lista de aviones
        /// </summary>
        /// <returns></returns>
        public List<object> GetAirships()
        {
            List<Object> dataList = new List<object>();
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var airshipList = entities.Aeronaves.ToList();
                    int n = airshipList.Count;
                    if (n == 0)
                    {
                        dataList = null;
                        return dataList;
                    }
                    else
                    {

                        for (int i = 0; i < airshipList.Count; ++i)
                        {
                            AirshipData data = new AirshipData();
                            data.Identificador = airshipList.ElementAt(i).Identificador;
                            data.Modelo = airshipList.ElementAt(i).Modelo;
                            data.Capacidad = airshipList.ElementAt(i).Capacidad;
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
        /// Get de un avion especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AirshipData GetAirship(int id)
        {
            AirshipData airship = new AirshipData();
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    if (!this.ExistAirship(id))
                    {
                        airship = null;
                        return airship;
                    }
                    var aeronavex = entities.Aeronaves.Find(id);
                    airship.Identificador = aeronavex.Identificador;
                    airship.Modelo = aeronavex.Modelo;
                    airship.Capacidad = aeronavex.Capacidad;
                    
                    return airship;

                }
                catch (Exception)
                {
                    airship = null;
                    return airship;
                }
            }
        }

        /// <summary>
        /// //Verifica si un avion existe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistAirship(int id)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                var i = entities.Aeronaves.Find(id);
                if (i == null) return false;
                else return true;
            }
        }

        /// <summary>
        /// Agrega un nuevo avion
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddAirship(AirshipData data)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                Aeronave newAirship = new Aeronave();
                newAirship.Identificador = data.Identificador;
                newAirship.Modelo = data.Modelo;
                newAirship.Capacidad = data.Capacidad;
                
                try
                {
                    entities.Aeronaves.Add(newAirship);
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
        /// Elimina un avion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteAirship(int id)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var ms = entities.Aeronaves.Find(id);
                    entities.Aeronaves.Remove(ms);
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
        /// Actualizar un avion
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateAirship(AirshipData data)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var airship = entities.Aeronaves.Find(data.Identificador);
                    airship.Identificador = data.Identificador;
                    airship.Modelo = data.Modelo;
                    airship.Capacidad = data.Capacidad;
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