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
        public int Costo { get; set; }
        public Nullable<System.DateTime> F_Salida { get; set; }
        public Nullable<System.DateTime> F_Llegada { get; set; }
        public int Millas { get; set; }
        public int ID_Aeronave { get; set; }
        public int A_Economicos { get; set; }
        public int A_Ejecutivos { get; set; }
    }
}