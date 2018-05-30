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
    
    public partial class ro_rol
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ro_rol()
        {
            this.ro_rol_detalle = new HashSet<ro_rol_detalle>();
        }
    
        public int IdEmpresa { get; set; }
        public int IdNominaTipo { get; set; }
        public int IdNominaTipoLiqui { get; set; }
        public int IdPeriodo { get; set; }
        public string Descripcion { get; set; }
        public string Observacion { get; set; }
        public string Cerrado { get; set; }
        public System.DateTime FechaIngresa { get; set; }
        public string UsuarioIngresa { get; set; }
        public Nullable<System.DateTime> FechaModifica { get; set; }
        public string UsuarioModifica { get; set; }
        public Nullable<System.DateTime> FechaAnula { get; set; }
        public string UsuarioAnula { get; set; }
        public string MotivoAnula { get; set; }
        public string UsuarioCierre { get; set; }
        public Nullable<System.DateTime> FechaCierre { get; set; }
        public string IdCentroCosto { get; set; }
    
        public virtual ro_Nomina_Tipo ro_Nomina_Tipo { get; set; }
        public virtual ro_Nomina_Tipoliqui ro_Nomina_Tipoliqui { get; set; }
        public virtual ro_periodo ro_periodo { get; set; }
        public virtual ro_periodo_x_ro_Nomina_TipoLiqui ro_periodo_x_ro_Nomina_TipoLiqui { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ro_rol_detalle> ro_rol_detalle { get; set; }
    }
}
