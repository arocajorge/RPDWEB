//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class in_movi_inven_tipo
    {
        public in_movi_inven_tipo()
        {
            this.in_movi_inven_tipo_x_tb_bodega = new HashSet<in_movi_inven_tipo_x_tb_bodega>();
            this.in_parametro = new HashSet<in_parametro>();
            this.in_parametro1 = new HashSet<in_parametro>();
            this.in_parametro2 = new HashSet<in_parametro>();
            this.in_parametro3 = new HashSet<in_parametro>();
            this.in_parametro4 = new HashSet<in_parametro>();
            this.in_parametro5 = new HashSet<in_parametro>();
            this.in_parametro6 = new HashSet<in_parametro>();
            this.in_parametro7 = new HashSet<in_parametro>();
            this.in_parametro8 = new HashSet<in_parametro>();
            this.in_parametro9 = new HashSet<in_parametro>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdMovi_inven_tipo { get; set; }
        public string Codigo { get; set; }
        public string tm_descripcion { get; set; }
        public string cm_tipo_movi { get; set; }
        public string cm_interno { get; set; }
        public string cm_descripcionCorta { get; set; }
        public string Estado { get; set; }
        public Nullable<int> IdTipoCbte { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string nom_pc { get; set; }
        public string ip { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string MotiAnula { get; set; }
        public Nullable<bool> Genera_Movi_Inven { get; set; }
        public Nullable<bool> Genera_Diario_Contable { get; set; }
    
        public virtual ICollection<in_movi_inven_tipo_x_tb_bodega> in_movi_inven_tipo_x_tb_bodega { get; set; }
        public virtual ICollection<in_parametro> in_parametro { get; set; }
        public virtual ICollection<in_parametro> in_parametro1 { get; set; }
        public virtual ICollection<in_parametro> in_parametro2 { get; set; }
        public virtual ICollection<in_parametro> in_parametro3 { get; set; }
        public virtual ICollection<in_parametro> in_parametro4 { get; set; }
        public virtual ICollection<in_parametro> in_parametro5 { get; set; }
        public virtual ICollection<in_parametro> in_parametro6 { get; set; }
        public virtual ICollection<in_parametro> in_parametro7 { get; set; }
        public virtual ICollection<in_parametro> in_parametro8 { get; set; }
        public virtual ICollection<in_parametro> in_parametro9 { get; set; }
    }
}
