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
    
    public partial class SPINV_GetStock_Result
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public decimal IdProducto { get; set; }
        public string IdUnidadMedida { get; set; }
        public double Stock { get; set; }
        public double UltimoCosto { get; set; }
        public int IdFecha { get; set; }
        public string pr_descripcion { get; set; }
        public string pr_codigo { get; set; }
        public string IdCategoria { get; set; }
        public Nullable<int> IdGrupo { get; set; }
        public Nullable<int> IdSubGrupo { get; set; }
        public Nullable<int> IdLinea { get; set; }
        public string ca_Categoria { get; set; }
        public string nom_grupo { get; set; }
        public string nom_linea { get; set; }
    }
}
