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
    
    public partial class Table_Language
    {
        public Table_Language()
        {
            this.Table_StopWord = new HashSet<Table_StopWord>();
            this.Table_StopWord1 = new HashSet<Table_StopWord>();
            this.Table_StopWord2 = new HashSet<Table_StopWord>();
            this.Table_StopWord3 = new HashSet<Table_StopWord>();
        }
    
        public int ID_Language { get; set; }
        public string Language_Name { get; set; }
    
        public virtual ICollection<Table_StopWord> Table_StopWord { get; set; }
        public virtual ICollection<Table_StopWord> Table_StopWord1 { get; set; }
        public virtual ICollection<Table_StopWord> Table_StopWord2 { get; set; }
        public virtual ICollection<Table_StopWord> Table_StopWord3 { get; set; }
    }
}
