//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ct_cbtecble_Plantilla
    {
        public ct_cbtecble_Plantilla()
        {
            this.ct_cbtecble_Plantilla_det = new HashSet<ct_cbtecble_Plantilla_det>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdPlantilla { get; set; }
        public int IdTipoCbte { get; set; }
        public string cb_Observacion { get; set; }
        public string cb_Estado { get; set; }
        public string IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string IdUsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string IdUsuarioAnulacion { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
        public string MotivoAnulacion { get; set; }
    
        public virtual ct_cbtecble_tipo ct_cbtecble_tipo { get; set; }
        public virtual ICollection<ct_cbtecble_Plantilla_det> ct_cbtecble_Plantilla_det { get; set; }
    }
}
