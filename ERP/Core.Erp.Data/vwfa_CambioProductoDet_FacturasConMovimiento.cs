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
    
    public partial class vwfa_CambioProductoDet_FacturasConMovimiento
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public decimal IdCambio { get; set; }
        public int Secuencia_ca { get; set; }
        public Nullable<int> IdEmpresa_eg { get; set; }
        public Nullable<int> IdSucursal_eg { get; set; }
        public Nullable<int> IdMovi_inven_tipo_eg { get; set; }
        public Nullable<decimal> IdNumMovi_eg { get; set; }
        public Nullable<int> Secuencia_eg { get; set; }
        public double CantidadCambio { get; set; }
        public double Costo { get; set; }
        public string IdUnidadMedida_sinConversion { get; set; }
        public Nullable<decimal> IdProducto { get; set; }
        public Nullable<int> IdBodega_eg { get; set; }
    }
}
