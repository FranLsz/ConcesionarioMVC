//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Concesionario.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string imagen { get; set; }
        public Nullable<int> idRol { get; set; }
    
        public virtual Rol Rol { get; set; }
    }
}
