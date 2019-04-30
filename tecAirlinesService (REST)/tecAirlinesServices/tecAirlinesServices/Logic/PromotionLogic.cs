using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tecAirlinesServices.Models;

namespace tecAirlinesServices.Logic
{
    public class PromotionLogic
    {
        /// <summary>
        /// Lista de promociones
        /// </summary>
        /// <returns></returns>
        public List<object> GetPromotions()
        {
            List<Object> dataList = new List<object>();
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var promotionList = entities.Promocions.ToList();
                    int n = promotionList.Count;
                    if (n == 0)
                    {
                        dataList = null;
                        return dataList;
                    }
                    else
                    {

                        for (int i = 0; i < promotionList.Count; ++i)
                        {
                            PromotionData data = new PromotionData();
                            data.C_Usuario = promotionList.ElementAt(i).C_Usuario;
                            data.C_Vuelo = promotionList.ElementAt(i).C_Vuelo;
                            data.F_Inicio = promotionList.ElementAt(i).F_Inicio;
                            data.F_Fin = promotionList.ElementAt(i).F_Fin;
                            data.Porcentaje = promotionList.ElementAt(i).Porcentaje;
                            data.Imagen = promotionList.ElementAt(i).Imagen;
                           
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
        /// Get de una promocion especifica
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PromotionData GetPromotion(string id)
        {
            PromotionData promotion = new PromotionData();
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    if (!this.ExistPromotion(id))
                    {
                        promotion = null;
                        return promotion;
                    }
                    var promox = entities.Promocions.Find(id);
                    promotion.C_Usuario = promox.C_Usuario;
                    promotion.C_Vuelo = promox.C_Vuelo;
                    promotion.F_Inicio = promox.F_Inicio;
                    promotion.F_Fin = promox.F_Fin;
                    promotion.Porcentaje = promox.Porcentaje;
                    promotion.Imagen = promox.Imagen;

                    return promotion;

                }
                catch (Exception)
                {
                    promotion = null;
                    return promotion;
                }
            }
        }

        /// <summary>
        /// //Verifica si una promocion existe existe
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ExistPromotion(string id)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                var i = entities.Promocions.Find(id);
                if (i == null) return false;
                else return true;
            }
        }

        /// <summary>
        /// Agrega un nueva promocion
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool AddPromotion(PromotionData data)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                Promocion newPromotion = new Promocion();
                newPromotion.C_Usuario = data.C_Usuario;
                newPromotion.C_Vuelo = data.C_Vuelo;
                newPromotion.F_Inicio = data.F_Inicio;
                newPromotion.F_Fin = data.F_Fin;
                newPromotion.Porcentaje = data.Porcentaje;
                newPromotion.Imagen = data.Imagen;

                try
                {
                    entities.Promocions.Add(newPromotion);
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
        /// Elimina un promocion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeletePromotion(string id)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var ms = entities.Promocions.Find(id);
                    entities.Promocions.Remove(ms);
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
        /// Actualizar una promocion
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdatePromotion(PromotionData data)
        {
            using (tecAirlinesEntities entities = new tecAirlinesEntities())
            {
                try
                {
                    var promotion = entities.Promocions.Find(data.C_Vuelo);

                    promotion.C_Usuario = data.C_Usuario;
                    promotion.C_Vuelo = data.C_Vuelo;
                    promotion.F_Inicio = data.F_Inicio;
                    promotion.F_Fin = data.F_Fin;
                    promotion.Porcentaje = data.Porcentaje;
                    promotion.Imagen = data.Imagen;
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