using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_LoginUsers.Models
{
    public class PayData
    {
        public int Numero { get; set; }
        public int Contraseña { get; set; }
        public System.DateTime Expiracion { get; set; }
        public string Titular { get; set; }
        public int C_Reserva { get; set; }
    }
}