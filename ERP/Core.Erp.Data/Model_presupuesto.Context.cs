﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities_presupuesto : DbContext
    {
        public Entities_presupuesto()
            : base("name=Entities_presupuesto")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<pre_RubroTipo> pre_RubroTipo { get; set; }
        public virtual DbSet<pre_Rubro> pre_Rubro { get; set; }
        public virtual DbSet<vwpre_Rubro> vwpre_Rubro { get; set; }
        public virtual DbSet<pre_PresupuestoPeriodo> pre_PresupuestoPeriodo { get; set; }
        public virtual DbSet<pre_Presupuesto> pre_Presupuesto { get; set; }
        public virtual DbSet<pre_PresupuestoDet> pre_PresupuestoDet { get; set; }
        public virtual DbSet<vwpre_Presupuesto> vwpre_Presupuesto { get; set; }
        public virtual DbSet<vwpre_PresupuestoDet> vwpre_PresupuestoDet { get; set; }
    }
}
