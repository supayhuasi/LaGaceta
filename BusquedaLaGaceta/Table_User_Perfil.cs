//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusquedaLaGaceta
{
    using System;
    using System.Collections.Generic;
    
    public partial class Table_User_Perfil
    {
        public long id { get; set; }
        public long id_user { get; set; }
        public long id_perfil { get; set; }
    
        public virtual Table_User_Perfil Table_User_Perfil1 { get; set; }
        public virtual Table_User_Perfil Table_User_Perfil2 { get; set; }
    }
}
