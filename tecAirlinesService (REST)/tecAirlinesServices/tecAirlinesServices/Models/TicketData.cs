using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tecAirlinesServices.Models
{
    public class TicketData
    {
        public int Identificador { get; set; }
        public int C_Reserva { get; set; }
        public int Categoria { get; set; }
        public Nullable<int> N_Asiento { get; set; }
    }
}