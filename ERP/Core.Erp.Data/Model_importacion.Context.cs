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
    
    public partial class Entities_importacion : DbContext
    {
        public Entities_importacion()
            : base("name=Entities_importacion")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<imp_catalogo> imp_catalogo { get; set; }
        public virtual DbSet<imp_catalogo_tipo> imp_catalogo_tipo { get; set; }
        public virtual DbSet<imp_gasto> imp_gasto { get; set; }
        public virtual DbSet<imp_gasto_x_ct_plancta> imp_gasto_x_ct_plancta { get; set; }
        public virtual DbSet<imp_liquidacion> imp_liquidacion { get; set; }
        public virtual DbSet<imp_orden_compra_ext_ct_cbteble_det_gastos> imp_orden_compra_ext_ct_cbteble_det_gastos { get; set; }
        public virtual DbSet<imp_orden_compra_ext_recepcion> imp_orden_compra_ext_recepcion { get; set; }
        public virtual DbSet<imp_parametro> imp_parametro { get; set; }
        public virtual DbSet<vwimp_orden_compra_ext_con_saldo> vwimp_orden_compra_ext_con_saldo { get; set; }
        public virtual DbSet<vwimp_orden_compra_ext_det> vwimp_orden_compra_ext_det { get; set; }
        public virtual DbSet<vwimp_orden_compra_ext_recepcion> vwimp_orden_compra_ext_recepcion { get; set; }
        public virtual DbSet<vwimp_liquidacion_det_x_imp_orden_compra_ext> vwimp_liquidacion_det_x_imp_orden_compra_ext { get; set; }
        public virtual DbSet<vwimp_gastos_no_asignados> vwimp_gastos_no_asignados { get; set; }
        public virtual DbSet<imp_liquidacion_det_x_imp_orden_compra_ext> imp_liquidacion_det_x_imp_orden_compra_ext { get; set; }
        public virtual DbSet<imp_orden_compra_ext_det> imp_orden_compra_ext_det { get; set; }
        public virtual DbSet<imp_orden_compra_ext> imp_orden_compra_ext { get; set; }
        public virtual DbSet<vwimp_orden_compra_ext> vwimp_orden_compra_ext { get; set; }
        public virtual DbSet<vwimp_orden_compra_ext_ct_cbteble_det_gastos> vwimp_orden_compra_ext_ct_cbteble_det_gastos { get; set; }
    }
}
