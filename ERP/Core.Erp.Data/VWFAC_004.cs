//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class VWFAC_004
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public decimal IdNota { get; set; }
        public int Secuencia { get; set; }
        public string CodTipoNota { get; set; }
        public string IdTipoDocumento { get; set; }
        public string numDocumento { get; set; }
        public decimal IdCliente { get; set; }
        public string pe_nombreCompleto { get; set; }
        public string pe_cedulaRuc { get; set; }
        public Nullable<int> pe_telefonoCasa { get; set; }
        public string pe_direccion { get; set; }
        public System.DateTime no_fecha { get; set; }
        public System.DateTime no_fecha_venc { get; set; }
        public Nullable<int> Plazo { get; set; }
        public int IdTipoNota { get; set; }
        public string sc_observacion { get; set; }
        public double sc_cantidad { get; set; }
        public double sc_Precio { get; set; }
        public double sc_subtotal { get; set; }
        public double sc_iva { get; set; }
        public double sc_total { get; set; }
        public decimal IdProducto { get; set; }
        public string nombreProducto { get; set; }
        public string bo_Descripcion { get; set; }
        public string IdUsuario { get; set; }
        public string Su_Descripcion { get; set; }
    }
}
