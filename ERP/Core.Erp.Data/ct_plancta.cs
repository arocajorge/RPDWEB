//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class ct_plancta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
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
        public string nom_pc { get; set; }
        public string ip { get; set; }
        public Nullable<int> IdTipo_Gasto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ct_anio_fiscal_x_cuenta_utilidad> ct_anio_fiscal_x_cuenta_utilidad { get; set; }
        public virtual ct_grupocble ct_grupocble { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ct_plancta> ct_plancta1 { get; set; }
        public virtual ct_plancta ct_plancta2 { get; set; }
        public virtual ct_plancta_nivel ct_plancta_nivel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ct_cbtecble_det> ct_cbtecble_det { get; set; }
    }
}
