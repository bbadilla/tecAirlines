using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tecAirlinesServices.Models
{
    public class UserData
    {
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int Telefono { get; set; }
        public Nullable<int> Carne { get; set; }
        public string Universidad { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
    }
}