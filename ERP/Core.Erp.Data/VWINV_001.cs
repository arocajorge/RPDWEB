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
    
    public partial class VWINV_001
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdMovi_inven_tipo { get; set; }
        public decimal IdNumMovi { get; set; }
        public int Secuencia { get; set; }
        public decimal IdProducto { get; set; }
        public string pr_descripcion { get; set; }
        public string pr_codigo { get; set; }
        public string Su_Descripcion { get; set; }
        public string bo_Descripcion { get; set; }
        public string IdUnidadMedida_sinConversion { get; set; }
        public string Descripcion { get; set; }
        public double dm_cantidad_sinConversion { get; set; }
        public Nullable<double> mv_costo_sinConversion { get; set; }
        public string cm_observacion { get; set; }
        public string CodMoviInven { get; set; }
        public System.DateTime cm_fecha { get; set; }
        public string Estado { get; set; }
        public int IdMotivo_Inv { get; set; }
        public string Desc_mov_inv { get; set; }
        public string lote_num_lote { get; set; }
        public Nullable<System.DateTime> lote_fecha_vcto { get; set; }
        public string nom_presentacion { get; set; }
        public string signo { get; set; }
        public string tm_descripcion { get; set; }
        public string NomUsuario { get; set; }
    }
}
