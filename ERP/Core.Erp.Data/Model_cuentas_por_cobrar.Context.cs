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
    
    public partial class Entities_cuentas_por_cobrar : DbContext
    {
        public Entities_cuentas_por_cobrar()
            : base("name=Entities_cuentas_por_cobrar")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cxc_Catalogo> cxc_Catalogo { get; set; }
        public virtual DbSet<cxc_CatalogoTipo> cxc_CatalogoTipo { get; set; }
        public virtual DbSet<cxc_cobro_tipo> cxc_cobro_tipo { get; set; }
        public virtual DbSet<cxc_cobro_tipo_motivo> cxc_cobro_tipo_motivo { get; set; }
        public virtual DbSet<cxc_Parametro> cxc_Parametro { get; set; }
        public virtual DbSet<vwcxc_cartera_x_cobrar> vwcxc_cartera_x_cobrar { get; set; }
        public virtual DbSet<cxc_cobro_tipo_Param_conta_x_sucursal> cxc_cobro_tipo_Param_conta_x_sucursal { get; set; }
        public virtual DbSet<cxc_cobro_x_ct_cbtecble> cxc_cobro_x_ct_cbtecble { get; set; }
        public virtual DbSet<cxc_cobro> cxc_cobro { get; set; }
        public virtual DbSet<vwcxc_cobro> vwcxc_cobro { get; set; }
        public virtual DbSet<cxc_cobro_det> cxc_cobro_det { get; set; }
        public virtual DbSet<vwcxc_cobro_det> vwcxc_cobro_det { get; set; }
    }
}
