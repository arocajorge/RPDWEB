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
    
    public partial class in_Ing_Egr_Inven
    {
        public in_Ing_Egr_Inven()
        {
            this.in_devolucion_inven = new HashSet<in_devolucion_inven>();
            this.in_devolucion_inven1 = new HashSet<in_devolucion_inven>();
            this.in_Ing_Egr_Inven_det = new HashSet<in_Ing_Egr_Inven_det>();
            this.in_Ing_Egr_Inven_distribucion = new HashSet<in_Ing_Egr_Inven_distribucion>();
            this.in_Ing_Egr_Inven_distribucion1 = new HashSet<in_Ing_Egr_Inven_distribucion>();
            this.in_transferencia = new HashSet<in_transferencia>();
            this.in_transferencia1 = new HashSet<in_transferencia>();
            this.In_consignacion = new HashSet<In_consignacion>();
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
    
        public virtual ICollection<in_devolucion_inven> in_devolucion_inven { get; set; }
        public virtual ICollection<in_devolucion_inven> in_devolucion_inven1 { get; set; }
        public virtual ICollection<in_Ing_Egr_Inven_det> in_Ing_Egr_Inven_det { get; set; }
        public virtual ICollection<in_Ing_Egr_Inven_distribucion> in_Ing_Egr_Inven_distribucion { get; set; }
        public virtual ICollection<in_Ing_Egr_Inven_distribucion> in_Ing_Egr_Inven_distribucion1 { get; set; }
        public virtual in_Motivo_Inven in_Motivo_Inven { get; set; }
        public virtual ICollection<in_transferencia> in_transferencia { get; set; }
        public virtual ICollection<in_transferencia> in_transferencia1 { get; set; }
        public virtual ICollection<In_consignacion> In_consignacion { get; set; }
    }
}
