//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data.Reportes.Base
{
    using System;
    
    public partial class SPCXP_018_Result
    {
        public int IdEmpresa { get; set; }
        public int IdTipoCbte_Ogiro { get; set; }
        public decimal IdCbteCble_Ogiro { get; set; }
        public int IdSucursal { get; set; }
        public string Su_Descripcion { get; set; }
        public string co_factura { get; set; }
        public decimal IdProveedor { get; set; }
        public string pe_nombreCompleto { get; set; }
        public string co_observacion { get; set; }
        public System.DateTime co_FechaFactura { get; set; }
        public System.DateTime co_FechaFactura_vct { get; set; }
        public string Codigo { get; set; }
        public double co_subtotal_iva { get; set; }
        public double co_subtotal_siniva { get; set; }
        public double co_valoriva { get; set; }
        public double co_total { get; set; }
        public double ValorRetencion { get; set; }
        public double ValorNC { get; set; }
        public double ValorAbono { get; set; }
        public Nullable<double> Saldo { get; set; }
        public Nullable<int> IdClaseProveedor { get; set; }
        public string descripcion_clas_prove { get; set; }
        public Nullable<int> DiasVcto { get; set; }
    }
}