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
    
    public partial class Table_LuceneDBIndexAddress
    {
        public Table_LuceneDBIndexAddress()
        {
            this.Table_ProcessedFiles = new HashSet<Table_ProcessedFiles>();
            this.Table_Schedule_LuceneDBIndexAddress = new HashSet<Table_Schedule_LuceneDBIndexAddress>();
            this.Table_ProcessedFiles1 = new HashSet<Table_ProcessedFiles>();
            this.Table_Schedule_LuceneDBIndexAddress1 = new HashSet<Table_Schedule_LuceneDBIndexAddress>();
        }
    
        public long Id { get; set; }
        public string Roll_Number { get; set; }
        public Nullable<System.DateTime> Date_From { get; set; }
        public Nullable<System.DateTime> Date_To { get; set; }
        public string DB_Path { get; set; }
        public string Folder_Path { get; set; }
        public Nullable<System.DateTime> Creation_Date { get; set; }
        public Nullable<int> Finalized { get; set; }
    
        public virtual ICollection<Table_ProcessedFiles> Table_ProcessedFiles { get; set; }
        public virtual ICollection<Table_Schedule_LuceneDBIndexAddress> Table_Schedule_LuceneDBIndexAddress { get; set; }
        public virtual ICollection<Table_ProcessedFiles> Table_ProcessedFiles1 { get; set; }
        public virtual ICollection<Table_Schedule_LuceneDBIndexAddress> Table_Schedule_LuceneDBIndexAddress1 { get; set; }
    }
}
