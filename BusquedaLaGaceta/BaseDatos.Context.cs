﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AIEntities : DbContext
    {
        public AIEntities()
            : base("name=AIEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Table> Table { get; set; }
        public virtual DbSet<Table_ErrorImage> Table_ErrorImage { get; set; }
        public virtual DbSet<Table_File> Table_File { get; set; }
        public virtual DbSet<Table_File_Names> Table_File_Names { get; set; }
        public virtual DbSet<Table_FileType> Table_FileType { get; set; }
        public virtual DbSet<Table_Gral> Table_Gral { get; set; }
        public virtual DbSet<Table_Language> Table_Language { get; set; }
        public virtual DbSet<Table_Log> Table_Log { get; set; }
        public virtual DbSet<Table_LuceneDBIndexAddress> Table_LuceneDBIndexAddress { get; set; }
        public virtual DbSet<Table_Perfiles_Permissions> Table_Perfiles_Permissions { get; set; }
        public virtual DbSet<Table_Periods_Suplements> Table_Periods_Suplements { get; set; }
        public virtual DbSet<Table_ProcessedFiles> Table_ProcessedFiles { get; set; }
        public virtual DbSet<Table_Schedule> Table_Schedule { get; set; }
        public virtual DbSet<Table_Schedule_LuceneDBIndexAddress> Table_Schedule_LuceneDBIndexAddress { get; set; }
        public virtual DbSet<Table_StopWord> Table_StopWord { get; set; }
        public virtual DbSet<Table_Suplements> Table_Suplements { get; set; }
        public virtual DbSet<Table_User> Table_User { get; set; }
        public virtual DbSet<Table_User_Perfil> Table_User_Perfil { get; set; }
        public virtual DbSet<Table_Perfiles> Table_Perfiles { get; set; }
        public virtual DbSet<Table_Permissions> Table_Permissions { get; set; }
        public virtual DbSet<Table_TempReport> Table_TempReport { get; set; }
    }
}
