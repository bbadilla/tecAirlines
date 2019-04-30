using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tecAirlinesServices.Models;

namespace tecAirlinesServices.Logic
{
    public class UniversityLogic
    {
        /// <summary>
        /// Lista de universidades
        /// </summary>
        /// <returns></returns>
        public List<object> GetUniversitys()
        {
            List<Object> dataList = new List<object>();
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var universityList = entities.Universidads.ToList();
                    int n = universityList.Count;
                    if (n == 0)
                    {
                        dataList = null;
                        return dataList;
                    }
                    else
                    {

                        for (int i = 0; i < universityList.Count; ++i)
                        {
                            UniversityData data = new UniversityData();
                            data.Identificador = universityList.ElementAt(i).Identificador;
                            data.Nombre = universityList.ElementAt(i).Nombre;
                            
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
        public UniversityData GetUniversity(int id)
        {
            UniversityData university = new UniversityData();
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    if (!this.ExistUniversity(id))
                    {
                        university = null;
                        return university;
                    }
                    var universityx = entities.Universidads.Find(id);
                    university.Identificador = universityx.Identificador;
                    university.Nombre = universityx.Nombre;
                    

                    return university;

                }
                catch (Exception)
                {
                    university = null;
                    return university;
                }
            }
        }

        /// <summary>
        /// //Verifica si una universidad existe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistUniversity(int id)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                var i = entities.Universidads.Find(id);
                if (i == null) return false;
                else return true;
            }
        }

        /// <summary>
        /// Agrega un nuevo universidad
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddUniversity(UniversityData data)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                Universidad newUniversity = new Universidad();
                newUniversity.Identificador = data.Identificador;
                newUniversity.Nombre = data.Nombre;
                

                try
                {
                    //entities.Universidads.Add(newUniversity);
                    //entities.SaveChanges();
                    int entity = entities.Insertar_Universidad(data.Identificador, data.Nombre);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Elimina un universidad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteUniversity(int id)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var ms = entities.Universidads.Find(id);
                    entities.Universidads.Remove(ms);
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
        /// Actualizar un universidad
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateUniversity(UniversityData data)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var university = entities.Universidads.Find(data.Identificador);

                    university.Identificador = data.Identificador;
                    university.Nombre = data.Nombre;
                   
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