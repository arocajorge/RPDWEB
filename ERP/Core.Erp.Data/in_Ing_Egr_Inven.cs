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
    
    public partial class in_Ing_Egr_Inven
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public in_Ing_Egr_Inven()
        {
            this.in_Ing_Egr_Inven_det = new HashSet<in_Ing_Egr_Inven_det>();
            this.in_transferencia = new HashSet<in_transferencia>();
            this.in_transferencia1 = new HashSet<in_transferencia>();
            this.in_Ing_Egr_Inven_distribucion = new HashSet<in_Ing_Egr_Inven_distribucion>();
            this.in_Ing_Egr_Inven_distribucion1 = new HashSet<in_Ing_Egr_Inven_distribucion>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdMovi_inven_tipo { get; set; }
        public decimal IdNumMovi { get; set; }
        public Nullable<int> IdBodega { get; set; }
        public string signo { get; set; }
        public string CodMoviInven { get; set; }
        public string cm_observacion { get; set; }
        public System.DateTime cm_fecha { get; set; }
        public string IdUsuario { get; set; }
        public string Estado { get; set; }
        public string MotivoAnulacion { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltModi { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdusuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string nom_pc { get; set; }
        public string ip { get; set; }
        public Nullable<int> IdMotivo_Inv { get; set; }
        public Nullable<decimal> IdResponsable { get; set; }
    
        public virtual in_Motivo_Inven in_Motivo_Inven { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<in_Ing_Egr_Inven_det> in_Ing_Egr_Inven_det { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<in_transferencia> in_transferencia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<in_transferencia> in_transferencia1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<in_Ing_Egr_Inven_distribucion> in_Ing_Egr_Inven_distribucion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<in_Ing_Egr_Inven_distribucion> in_Ing_Egr_Inven_distribucion1 { get; set; }
    }
}
