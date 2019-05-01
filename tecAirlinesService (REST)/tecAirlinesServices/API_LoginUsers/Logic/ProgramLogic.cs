using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tecAirlinesServices.Models;

namespace tecAirlinesServices.Logic
{
    public class ProgramLogic
    {
        /// <summary>
        /// Lista de programas
        /// </summary>
        /// <returns></returns>
        public List<object> GetPrograms()
        {
            List<Object> dataList = new List<object>();
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var programList = entities.Programas.ToList();
                    int n = programList.Count;
                    if (n == 0)
                    {
                        dataList = null;
                        return dataList;
                    }
                    else
                    {

                        for (int i = 0; i < programList.Count; ++i)
                        {
                            ProgramData data = new ProgramData();
                            data.C_Usuario = programList.ElementAt(i).C_Usuario;
                            data.ID_Universidad = programList.ElementAt(i).ID_Universidad;
                            data.Millas = programList.ElementAt(i).Millas;
                           
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
        /// Get de un programa de un usuario especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProgramData GetProgram(string id)
        {
            ProgramData program = new ProgramData();
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    if (!this.ExistProgram(id))
                    {
                        program = null;
                        return program;
                    }
                    var programx = entities.Programas.Find(id);
                    program.C_Usuario = programx.C_Usuario;
                    program.ID_Universidad = programx.ID_Universidad;
                    program.Millas = programx.Millas;
                    

                    return program;

                }
                catch (Exception)
                {
                    program = null;
                    return program;
                }
            }
        }

        /// <summary>
        /// //Verifica si un avion existe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistProgram(string id)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                var i = entities.Programas.Find(id);
                if (i == null) return false;
                else return true;
            }
        }

        /// <summary>
        /// Agrega un nuevo Programa
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddProgram(ProgramData data)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                Programa newProgram = new Programa();
                newProgram.C_Usuario = data.C_Usuario;
                newProgram.ID_Universidad = data.ID_Universidad;
                newProgram.Millas = data.Millas;
            
                try
                {
                    entities.Programas.Add(newProgram);
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
        /// Elimina un programa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteProgram(string id)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var ms = entities.Programas.Find(id);
                    entities.Programas.Remove(ms);
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
        /// Actualizar un praogra
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateProgram(ProgramData data)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var program = entities.Programas.Find(data.C_Usuario);

                    program.C_Usuario = data.C_Usuario;
                    program.ID_Universidad = data.ID_Universidad;
                    program.Millas = data.Millas;
          
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