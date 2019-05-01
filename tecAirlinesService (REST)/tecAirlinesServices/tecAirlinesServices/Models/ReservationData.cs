using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tecAirlinesServices.Models
{
    public class ReservationData
    {
        public int Codigo { get; set; }
        public string C_Usuario { get; set; }
        public bool Chequeo { get; set; }
        public bool Pago { get; set; }
        public int Equipaje { get; set; }
        public string C_Vuelo { get; set; }
    }
}