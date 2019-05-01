using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tecAirlinesServices.Models;

namespace tecAirlinesServices.Logic
{
    public class AirportLogic
    {
        /// <summary>
        /// Lista de aviones
        /// </summary>
        /// <returns></returns>
        public List<object> GetAirports()
        {
            List<Object> dataList = new List<object>();
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var airshipList = entities.airports.ToList();
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
                            AirportData data = new AirportData();
                            data.Nombre = airshipList.ElementAt(i).Nombre;
                            data.Codigo = airshipList.ElementAt(i).Codigo;
                            data.N_Pais = airshipList.ElementAt(i).N_Pais;
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
    }
}


    