//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class fa_TipoNota
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public fa_TipoNota()
        {
            this.fa_notaCreDeb = new HashSet<fa_notaCreDeb>();
            this.fa_parametro = new HashSet<fa_parametro>();
            this.fa_TipoNota_x_Empresa_x_Sucursal = new HashSet<fa_TipoNota_x_Empresa_x_Sucursal>();
        }
    
        public int IdTipoNota { get; set; }
        public string CodTipoNota { get; set; }
        public string Tipo { get; set; }
        public string No_Descripcion { get; set; }
        public Nullable<bool> GeneraMoviInven { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string nom_pc { get; set; }
        public string ip { get; set; }
        public string Estado { get; set; }
        public string MotiAnula { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fa_notaCreDeb> fa_notaCreDeb { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fa_parametro> fa_parametro { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fa_TipoNota_x_Empresa_x_Sucursal> fa_TipoNota_x_Empresa_x_Sucursal { get; set; }
    }
}
