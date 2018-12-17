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
    
    public partial class ct_plancta
    {
        public ct_plancta()
        {
            this.ct_anio_fiscal_x_cuenta_utilidad = new HashSet<ct_anio_fiscal_x_cuenta_utilidad>();
            this.ct_plancta1 = new HashSet<ct_plancta>();
            this.ct_cbtecble_det = new HashSet<ct_cbtecble_det>();
        }
    
        public int IdEmpresa { get; set; }
        public string IdCtaCble { get; set; }
        public string pc_Cuenta { get; set; }
        public string IdCtaCblePadre { get; set; }
        public string pc_Naturaleza { get; set; }
        public int IdNivelCta { get; set; }
        public string IdGrupoCble { get; set; }
        public string pc_Estado { get; set; }
        public string pc_EsMovimiento { get; set; }
        public string pc_clave_corta { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuario { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string MotivoAnulacion { get; set; }
    
        public virtual ICollection<ct_anio_fiscal_x_cuenta_utilidad> ct_anio_fiscal_x_cuenta_utilidad { get; set; }
        public virtual ct_grupocble ct_grupocble { get; set; }
        public virtual ICollection<ct_plancta> ct_plancta1 { get; set; }
        public virtual ct_plancta ct_plancta2 { get; set; }
        public virtual ct_plancta_nivel ct_plancta_nivel { get; set; }
        public virtual ICollection<ct_cbtecble_det> ct_cbtecble_det { get; set; }
    }
}
