//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Promocion
    {
        public int Carne { get; set; }
        public string C_Vuelo { get; set; }
        public System.TimeSpan F_Inicio { get; set; }
        public System.TimeSpan F_Fin { get; set; }
        public int Porcentaje { get; set; }
        public string Imagen { get; set; }
    
        public virtual Programa Programa { get; set; }
        public virtual Vuelo Vuelo { get; set; }
    }
}