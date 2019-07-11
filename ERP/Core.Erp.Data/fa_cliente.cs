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
    
    public partial class fa_cliente
    {
        public fa_cliente()
        {
            this.fa_cliente_contactos = new HashSet<fa_cliente_contactos>();
            this.fa_cliente_x_fa_Vendedor_x_sucursal = new HashSet<fa_cliente_x_fa_Vendedor_x_sucursal>();
            this.fa_factura = new HashSet<fa_factura>();
            this.fa_notaCreDeb = new HashSet<fa_notaCreDeb>();
            this.fa_parametro = new HashSet<fa_parametro>();
            this.fa_proforma = new HashSet<fa_proforma>();
            this.fa_guia_remision = new HashSet<fa_guia_remision>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdCliente { get; set; }
        public string Codigo { get; set; }
        public decimal IdPersona { get; set; }
        public int Idtipo_cliente { get; set; }
        public string IdTipoCredito { get; set; }
        public int cl_plazo { get; set; }
        public double cl_Cupo { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string Estado { get; set; }
        public string IdCtaCble_cxc_Credito { get; set; }
        public bool es_empresa_relacionada { get; set; }
        public string FormaPago { get; set; }
        public bool EsClienteExportador { get; set; }
        public int IdNivel { get; set; }
    
        public virtual ICollection<fa_cliente_contactos> fa_cliente_contactos { get; set; }
        public virtual fa_cliente_tipo fa_cliente_tipo { get; set; }
        public virtual fa_formaPago fa_formaPago { get; set; }
        public virtual fa_NivelDescuento fa_NivelDescuento { get; set; }
        public virtual fa_TerminoPago fa_TerminoPago { get; set; }
        public virtual ICollection<fa_cliente_x_fa_Vendedor_x_sucursal> fa_cliente_x_fa_Vendedor_x_sucursal { get; set; }
        public virtual ICollection<fa_factura> fa_factura { get; set; }
        public virtual ICollection<fa_notaCreDeb> fa_notaCreDeb { get; set; }
        public virtual ICollection<fa_parametro> fa_parametro { get; set; }
        public virtual ICollection<fa_proforma> fa_proforma { get; set; }
        public virtual ICollection<fa_guia_remision> fa_guia_remision { get; set; }
    }
}
