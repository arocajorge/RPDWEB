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
    
    public partial class cp_orden_giro
    {
        public cp_orden_giro()
        {
            this.cp_orden_giro_pagos_sri = new HashSet<cp_orden_giro_pagos_sri>();
            this.cp_retencion = new HashSet<cp_retencion>();
            this.cp_orden_giro_det = new HashSet<cp_orden_giro_det>();
            this.cp_orden_giro_x_in_Ing_Egr_Inven = new HashSet<cp_orden_giro_x_in_Ing_Egr_Inven>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdCbteCble_Ogiro { get; set; }
        public int IdTipoCbte_Ogiro { get; set; }
        public string IdOrden_giro_Tipo { get; set; }
        public decimal IdProveedor { get; set; }
        public System.DateTime co_fechaOg { get; set; }
        public string co_serie { get; set; }
        public string co_factura { get; set; }
        public System.DateTime co_FechaFactura { get; set; }
        public Nullable<System.DateTime> co_FechaContabilizacion { get; set; }
        public System.DateTime co_FechaFactura_vct { get; set; }
        public int co_plazo { get; set; }
        public string co_observacion { get; set; }
        public double co_subtotal_iva { get; set; }
        public double co_subtotal_siniva { get; set; }
        public double co_baseImponible { get; set; }
        public double co_Por_iva { get; set; }
        public double co_valoriva { get; set; }
        public Nullable<int> IdCod_ICE { get; set; }
        public double co_total { get; set; }
        public double co_valorpagar { get; set; }
        public string co_vaCoa { get; set; }
        public Nullable<int> IdIden_credito { get; set; }
        public Nullable<int> IdCod_101 { get; set; }
        public Nullable<decimal> IdTipoFlujo { get; set; }
        public string IdTipoServicio { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string Estado { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public string MotivoAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public Nullable<int> IdSucursal { get; set; }
        public Nullable<int> IdBodega { get; set; }
        public string PagoLocExt { get; set; }
        public string PaisPago { get; set; }
        public string ConvenioTributacion { get; set; }
        public string PagoSujetoRetencion { get; set; }
        public Nullable<double> BseImpNoObjDeIva { get; set; }
        public Nullable<System.DateTime> fecha_autorizacion { get; set; }
        public string Num_Autorizacion { get; set; }
        public string Num_Autorizacion_Imprenta { get; set; }
        public Nullable<bool> cp_es_comprobante_electronico { get; set; }
        public string Tipodoc_a_Modificar { get; set; }
        public string estable_a_Modificar { get; set; }
        public string ptoEmi_a_Modificar { get; set; }
        public string num_docu_Modificar { get; set; }
        public string aut_doc_Modificar { get; set; }
        public Nullable<int> IdTipoMovi { get; set; }
    
        public virtual cp_codigo_SRI cp_codigo_SRI { get; set; }
        public virtual cp_codigo_SRI cp_codigo_SRI1 { get; set; }
        public virtual cp_codigo_SRI cp_codigo_SRI2 { get; set; }
        public virtual cp_pais_sri cp_pais_sri { get; set; }
        public virtual cp_proveedor cp_proveedor { get; set; }
        public virtual ICollection<cp_orden_giro_pagos_sri> cp_orden_giro_pagos_sri { get; set; }
        public virtual ICollection<cp_retencion> cp_retencion { get; set; }
        public virtual ICollection<cp_orden_giro_det> cp_orden_giro_det { get; set; }
        public virtual ICollection<cp_orden_giro_x_in_Ing_Egr_Inven> cp_orden_giro_x_in_Ing_Egr_Inven { get; set; }
    }
}
