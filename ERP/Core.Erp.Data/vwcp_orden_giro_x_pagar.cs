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
    
    public partial class vwcp_orden_giro_x_pagar
    {
        public int IdEmpresa { get; set; }
        public decimal IdCbteCble_Ogiro { get; set; }
        public int IdTipoCbte_Ogiro { get; set; }
        public string IdOrden_giro_Tipo { get; set; }
        public decimal IdProveedor { get; set; }
        public string co_serie { get; set; }
        public string co_factura { get; set; }
        public System.DateTime co_FechaFactura { get; set; }
        public string co_observacion { get; set; }
        public Nullable<int> IdSucursal { get; set; }
        public System.DateTime co_fechaOg { get; set; }
        public double co_subtotal_iva { get; set; }
        public double co_subtotal_siniva { get; set; }
        public double co_baseImponible { get; set; }
        public double co_Por_iva { get; set; }
        public double co_valoriva { get; set; }
        public double co_total { get; set; }
        public double co_valorpagar { get; set; }
        public double Total_Pagado { get; set; }
        public Nullable<double> Saldo_OG { get; set; }
        public string nom_tipo_Documento { get; set; }
        public string nom_proveedor { get; set; }
        public string CodTipoCbte { get; set; }
        public string tc_TipoCbte { get; set; }
        public string IdTipo_op { get; set; }
        public string IdEstadoAprobacion { get; set; }
        public Nullable<System.DateTime> co_FechaFactura_vct { get; set; }
        public Nullable<decimal> IdTipoFlujo { get; set; }
        public string nom_flujo { get; set; }
        public decimal IdPersona { get; set; }
        public string cod_Documento { get; set; }
        public string Estado { get; set; }
        public Nullable<bool> en_conci_caja { get; set; }
        public Nullable<decimal> IdCuota { get; set; }
        public Nullable<int> Secuencia { get; set; }
        public Nullable<double> Valor_cuota { get; set; }
        public Nullable<int> IdTipoMovi { get; set; }
    }
}
