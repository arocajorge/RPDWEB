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
    
    public partial class ct_cbtecble
    {
        public ct_cbtecble()
        {
            this.ct_anio_fiscal_x_cuenta_utilidad = new HashSet<ct_anio_fiscal_x_cuenta_utilidad>();
            this.ct_cbtecble_Reversado = new HashSet<ct_cbtecble_Reversado>();
            this.ct_cbtecble_Reversado1 = new HashSet<ct_cbtecble_Reversado>();
            this.ct_cbtecble_det = new HashSet<ct_cbtecble_det>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdTipoCbte { get; set; }
        public decimal IdCbteCble { get; set; }
        public string CodCbteCble { get; set; }
        public int IdPeriodo { get; set; }
        public System.DateTime cb_Fecha { get; set; }
        public double cb_Valor { get; set; }
        public string cb_Observacion { get; set; }
        public string cb_Estado { get; set; }
        public int cb_Anio { get; set; }
        public int cb_mes { get; set; }
        public string IdUsuario { get; set; }
        public string IdUsuarioAnu { get; set; }
        public string cb_MotivoAnu { get; set; }
        public string IdUsuarioUltModi { get; set; }
        public Nullable<System.DateTime> cb_FechaAnu { get; set; }
        public Nullable<System.DateTime> cb_FechaTransac { get; set; }
        public Nullable<System.DateTime> cb_FechaUltModi { get; set; }
    
        public virtual ct_anio_fiscal ct_anio_fiscal { get; set; }
        public virtual ICollection<ct_anio_fiscal_x_cuenta_utilidad> ct_anio_fiscal_x_cuenta_utilidad { get; set; }
        public virtual ct_cbtecble_tipo ct_cbtecble_tipo { get; set; }
        public virtual ct_periodo ct_periodo { get; set; }
        public virtual ICollection<ct_cbtecble_Reversado> ct_cbtecble_Reversado { get; set; }
        public virtual ICollection<ct_cbtecble_Reversado> ct_cbtecble_Reversado1 { get; set; }
        public virtual ICollection<ct_cbtecble_det> ct_cbtecble_det { get; set; }
    }
}
