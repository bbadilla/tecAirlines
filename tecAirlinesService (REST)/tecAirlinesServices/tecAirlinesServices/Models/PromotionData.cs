using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tecAirlinesServices.Models
{
    public class PromotionData
    {
        public string C_Usuario { get; set; }
        public string C_Vuelo { get; set; }
        public System.DateTime F_Inicio { get; set; }
        public System.DateTime F_Fin { get; set; }
        public int Porcentaje { get; set; }
        public string Imagen { get; set; }
    }
}