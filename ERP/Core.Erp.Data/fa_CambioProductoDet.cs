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
    
    public partial class fa_CambioProductoDet
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public decimal IdCambio { get; set; }
        public int Secuencia { get; set; }
        public decimal IdCbteVta { get; set; }
        public int SecuenciaFact { get; set; }
        public decimal IdProductoFact { get; set; }
        public decimal IdProductoCambio { get; set; }
        public double Costo { get; set; }
        public double CantidadFact { get; set; }
        public double CantidadCambio { get; set; }
        public Nullable<decimal> IdDevolucion { get; set; }
    
        public virtual fa_CambioProducto fa_CambioProducto { get; set; }
        public virtual fa_factura_det fa_factura_det { get; set; }
    }
}
