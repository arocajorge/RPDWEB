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
    
    public partial class cp_codigo_SRI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cp_codigo_SRI()
        {
            this.cp_codigo_SRI_x_CtaCble = new HashSet<cp_codigo_SRI_x_CtaCble>();
            this.cp_proveedor = new HashSet<cp_proveedor>();
            this.cp_proveedor1 = new HashSet<cp_proveedor>();
            this.cp_proveedor2 = new HashSet<cp_proveedor>();
        }
    
        public int IdCodigo_SRI { get; set; }
        public string codigoSRI { get; set; }
        public string co_codigoBase { get; set; }
        public string co_descripcion { get; set; }
        public double co_porRetencion { get; set; }
        public System.DateTime co_f_valides_desde { get; set; }
        public System.DateTime co_f_valides_hasta { get; set; }
        public string co_estado { get; set; }
        public string IdTipoSRI { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string nom_pc { get; set; }
        public string ip { get; set; }
        public string MotivoAnulacion { get; set; }
    
        public virtual cp_codigo_SRI_tipo cp_codigo_SRI_tipo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cp_codigo_SRI_x_CtaCble> cp_codigo_SRI_x_CtaCble { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cp_proveedor> cp_proveedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cp_proveedor> cp_proveedor1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cp_proveedor> cp_proveedor2 { get; set; }
    }
}
