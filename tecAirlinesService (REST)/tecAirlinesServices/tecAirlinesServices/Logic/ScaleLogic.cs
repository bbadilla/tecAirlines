using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tecAirlinesServices.Models;

namespace tecAirlinesServices.Logic
{
    public class ScaleLogic
    {
        /// <summary>
        /// Lista de escalas
        /// </summary>
        /// <returns></returns>
        public List<object> GetScales()
        {
            List<Object> dataList = new List<object>();
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var scaleList = entities.Escalas.ToList();
                    int n = scaleList.Count;
                    if (n == 0)
                    {
                        dataList = null;
                        return dataList;
                    }
                    else
                    {

                        for (int i = 0; i < scaleList.Count; ++i)
                        {
                            ScaleData data = new ScaleData();
                            data.C_Vuelo = scaleList.ElementAt(i).C_Vuelo;
                            data.A_Salida = scaleList.ElementAt(i).A_Salida;
                            data.A_Llegada = scaleList.ElementAt(i).A_Llegada;
                            data.F_Salida = scaleList.ElementAt(i).F_Salida;
                            data.F_Llegada = scaleList.ElementAt(i).F_Llegada;


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
        /// Get de un escala especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ScaleData GetScale(string id)
        {
            ScaleData scale = new ScaleData();
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    if (!this.ExistScale(id))
                    {
                        scale = null;
                        return scale;
                    }
                    var escalax = entities.Escalas.Find(id);
                    scale.C_Vuelo = escalax.C_Vuelo;
                    scale.A_Salida = escalax.A_Salida;
                    scale.A_Llegada = escalax.A_Llegada;
                    scale.F_Salida = escalax.F_Salida;
                    scale.F_Llegada = escalax.F_Llegada;

                    return scale;

                }
                catch (Exception)
                {
                    scale = null;
                    return scale;
                }
            }
        }

        /// <summary>
        /// //Verifica si un escala existe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistScale(string id)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                var i = entities.Escalas.Find(id);
                if (i == null) return false;
                else return true;
            }
        }

        /// <summary>
        /// Agrega un nuevo escala
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddScale(ScaleData data)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                Escala newScale = new Escala();
                newScale.C_Vuelo = data.C_Vuelo;
                newScale.A_Salida = data.A_Salida;
                newScale.A_Llegada = data.A_Llegada;
                newScale.F_Salida = data.F_Salida;
                newScale.F_Llegada = data.F_Llegada;


                try
                {
                    entities.Escalas.Add(newScale);
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
        /// Elimina un escala
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteScale(string id)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var ms = entities.Escalas.Find(id);
                    entities.Escalas.Remove(ms);
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
        /// Actualizar un escala
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateScale(ScaleData data)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var scale = entities.Escalas.Find(data.C_Vuelo);

                    scale.C_Vuelo = data.C_Vuelo;
                    scale.A_Salida = data.A_Salida;
                    scale.A_Llegada = data.A_Llegada;
                    scale.F_Salida = data.F_Salida;
                    scale.F_Llegada = data.F_Llegada;

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