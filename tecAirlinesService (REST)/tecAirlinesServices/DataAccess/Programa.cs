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
    
    public partial class Programa
    {
        public string C_Usuario { get; set; }
        public int ID_Universidad { get; set; }
        public Nullable<int> Millas { get; set; }
    
        public virtual Universidad Universidad { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
