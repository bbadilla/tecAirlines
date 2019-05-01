using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tecAirlinesServices.Models
{
    public class FlightData
    {
        public string Codigo { get; set; }
        public Nullable<bool> Estado { get; set; }
        public int C_Economico { get; set; }
        public int C_Ejecutivo { get; set; }
        public Nullable<System.DateTime> F_Salida { get; set; }
        public Nullable<System.DateTime> F_Llegada { get; set; }
        public string A_Salida { get; set; }
        public string A_Llegada { get; set; }
        public int Millas { get; set; }
        public int ID_Aeronave { get; set; }

    }
}