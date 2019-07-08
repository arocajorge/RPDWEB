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
    
    public partial class in_Ajuste
    {
        public in_Ajuste()
        {
            this.in_AjusteDet = new HashSet<in_AjusteDet>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdAjuste { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public Nullable<int> IdMovi_inven_tipo_ing { get; set; }
        public Nullable<int> IdMovi_inven_tipo_egr { get; set; }
        public Nullable<decimal> IdNumMovi_ing { get; set; }
        public Nullable<decimal> IdNumMovi_egr { get; set; }
        public string IdCatalogo_Estado { get; set; }
        public bool Estado { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Observacion { get; set; }
        public string IdUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string IdUsuarioModificacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string IdUsuarioAnulacion { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
        public string MotivoAnulacion { get; set; }
    
        public virtual in_Catalogo in_Catalogo { get; set; }
        public virtual in_movi_inven_tipo in_movi_inven_tipo { get; set; }
        public virtual in_movi_inven_tipo in_movi_inven_tipo1 { get; set; }
        public virtual ICollection<in_AjusteDet> in_AjusteDet { get; set; }
        public virtual in_Ing_Egr_Inven in_Ing_Egr_Inven { get; set; }
        public virtual in_Ing_Egr_Inven in_Ing_Egr_Inven1 { get; set; }
    }
}
