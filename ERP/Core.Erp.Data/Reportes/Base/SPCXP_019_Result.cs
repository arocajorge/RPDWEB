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
    
    public partial class SPCXP_019_Result
    {
        public long IdRow { get; set; }
        public int IdEmpresa { get; set; }
        public decimal IdProveedor { get; set; }
        public string nom_proveedor { get; set; }
        public Nullable<double> Valor_a_pagar { get; set; }
        public Nullable<double> MontoAplicado { get; set; }
        public Nullable<double> Saldo { get; set; }
        public string Ruc_Proveedor { get; set; }
        public string representante_legal { get; set; }
        public Nullable<double> x_Vencer { get; set; }
        public Nullable<double> Vencido { get; set; }
        public Nullable<double> Vencido_1_30 { get; set; }
        public Nullable<double> Vencido_31_60 { get; set; }
        public Nullable<double> Vencido_60_90 { get; set; }
        public Nullable<double> Vencido_mayor_90 { get; set; }
        public string Su_Descripcion { get; set; }
        public int IdClaseProveedor { get; set; }
        public string descripcion_clas_prove { get; set; }
        public string EsRelacionado { get; set; }
    }
}