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
    
    public partial class in_parametro
    {
        public int IdEmpresa { get; set; }
        public int IdMovi_inven_tipo_egresoBodegaOrigen { get; set; }
        public int IdMovi_inven_tipo_ingresoBodegaDestino { get; set; }
        public int IdMovi_Inven_tipo_x_Dev_Inv_x_Ing { get; set; }
        public int IdMovi_Inven_tipo_x_Dev_Inv_x_Erg { get; set; }
        public string P_Al_Conta_CtaInven_Buscar_en { get; set; }
        public string P_Al_Conta_CtaCosto_Buscar_en { get; set; }
        public string P_IdCtaCble_transitoria_transf_inven { get; set; }
        public int P_IdProductoTipo_para_lote_0 { get; set; }
        public bool P_se_crea_lote_0_al_crear_producto_matriz { get; set; }
        public int IdMovi_inven_tipo_x_distribucion_ing { get; set; }
        public int IdMovi_inven_tipo_x_distribucion_egr { get; set; }
        public int P_IdMovi_inven_tipo_default_ing { get; set; }
        public int P_IdMovi_inven_tipo_default_egr { get; set; }
        public int P_IdMovi_inven_tipo_ingreso_x_compra { get; set; }
        public int P_Dias_menores_alerta_desde_fecha_actual_rojo { get; set; }
        public int P_Dias_menores_alerta_desde_fecha_actual_amarillo { get; set; }
        public int DiasTransaccionesAFuturo { get; set; }
        public int IdMovi_inven_tipo_Cambio { get; set; }
        public int IdMovi_inven_tipo_Consignacion { get; set; }
        public int IdMovi_inven_tipo_elaboracion_egr { get; set; }
        public int IdMovi_inven_tipo_elaboracion_ing { get; set; }
    
        public virtual in_Catalogo in_Catalogo { get; set; }
        public virtual in_Catalogo in_Catalogo1 { get; set; }
        public virtual in_movi_inven_tipo in_movi_inven_tipo { get; set; }
        public virtual in_movi_inven_tipo in_movi_inven_tipo1 { get; set; }
        public virtual in_movi_inven_tipo in_movi_inven_tipo2 { get; set; }
        public virtual in_movi_inven_tipo in_movi_inven_tipo3 { get; set; }
        public virtual in_movi_inven_tipo in_movi_inven_tipo4 { get; set; }
        public virtual in_movi_inven_tipo in_movi_inven_tipo5 { get; set; }
        public virtual in_movi_inven_tipo in_movi_inven_tipo6 { get; set; }
        public virtual in_movi_inven_tipo in_movi_inven_tipo7 { get; set; }
        public virtual in_movi_inven_tipo in_movi_inven_tipo8 { get; set; }
        public virtual in_movi_inven_tipo in_movi_inven_tipo9 { get; set; }
        public virtual in_movi_inven_tipo in_movi_inven_tipo10 { get; set; }
        public virtual in_movi_inven_tipo in_movi_inven_tipo11 { get; set; }
        public virtual in_ProductoTipo in_ProductoTipo { get; set; }
    }
}
