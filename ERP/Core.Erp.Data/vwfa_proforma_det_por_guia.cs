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
    
    public partial class vwfa_proforma_det_por_guia
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public decimal IdProforma { get; set; }
        public int Secuencia { get; set; }
        public decimal IdProducto { get; set; }
        public double pd_cantidad { get; set; }
        public double pd_precio { get; set; }
        public double pd_por_descuento_uni { get; set; }
        public double pd_descuento_uni { get; set; }
        public double pd_precio_final { get; set; }
        public double pd_subtotal { get; set; }
        public string IdCod_Impuesto { get; set; }
        public double pd_por_iva { get; set; }
        public double pd_iva { get; set; }
        public double pd_total { get; set; }
        public bool anulado { get; set; }
        public string pr_descripcion { get; set; }
        public string nom_presentacion { get; set; }
        public string lote_num_lote { get; set; }
        public Nullable<System.DateTime> lote_fecha_vcto { get; set; }
        public decimal IdCliente { get; set; }
        public Nullable<bool> se_distribuye { get; set; }
        public string tp_ManejaInven { get; set; }
        public string IdCentroCosto { get; set; }
        public string cc_Descripcion { get; set; }
        public Nullable<decimal> NumCotizacion { get; set; }
        public Nullable<decimal> NumOPr { get; set; }
    }
}
