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
    
    public partial class fa_guia_remision_det_x_factura
    {
        public int IdEmpresa_guia { get; set; }
        public int IdSucursal_guia { get; set; }
        public int IdBodega_guia { get; set; }
        public decimal IdGuiaRemision_guia { get; set; }
        public int Secuencia_guia { get; set; }
        public int IdEmpresa_fact { get; set; }
        public int IdSucursal_fact { get; set; }
        public int IdBodega_fact { get; set; }
        public decimal IdCbteVta_fact { get; set; }
        public int Secuencia_fact { get; set; }
        public string observacion { get; set; }
    
        public virtual fa_factura_det fa_factura_det { get; set; }
        public virtual fa_guia_remision_det fa_guia_remision_det { get; set; }
    }
}
