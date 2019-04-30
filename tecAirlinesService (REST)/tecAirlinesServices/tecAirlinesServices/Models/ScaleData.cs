using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tecAirlinesServices.Models
{
    public class ScaleData
    {
        public string C_Vuelo { get; set; }
        public string A_Salida { get; set; }
        public string A_Llegada { get; set; }
        public System.DateTime F_Salida { get; set; }
        public System.DateTime F_Llegada { get; set; }
    }
}