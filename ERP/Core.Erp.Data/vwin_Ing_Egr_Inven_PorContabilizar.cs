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
    
    public partial class vwin_Ing_Egr_Inven_PorContabilizar
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdMovi_inven_tipo { get; set; }
        public decimal IdNumMovi { get; set; }
        public int Secuencia { get; set; }
        public Nullable<int> IdEmpresa_inv { get; set; }
        public Nullable<int> IdSucursal_inv { get; set; }
        public Nullable<int> IdBodega_inv { get; set; }
        public Nullable<int> IdMovi_inven_tipo_inv { get; set; }
        public Nullable<decimal> IdNumMovi_inv { get; set; }
        public Nullable<int> secuencia_inv { get; set; }
        public string IdCtaCtble_Inve { get; set; }
        public string IdCtaCtble_Costo { get; set; }
        public string IdCtaCble_Motivo { get; set; }
        public string P_IdCtaCble_transitoria_transf_inven { get; set; }
        public double Valor { get; set; }
        public string Estado { get; set; }
        public Nullable<bool> EsTransferencia { get; set; }
        public string IdCentroCosto { get; set; }
        public string IdCtaCble_MotivoDet { get; set; }
        public string IdCtaCble_CostoProducto { get; set; }
    }
}
