//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class VWCAJ_002_ingresos
    {
        public int IdEmpresa { get; set; }
        public decimal IdConciliacion_Caja { get; set; }
        public int IdTipocbte { get; set; }
        public decimal IdCbteCble { get; set; }
        public Nullable<double> valor_disponible { get; set; }
        public double valor_aplicado { get; set; }
        public double cr_Valor { get; set; }
        public string pe_nombreCompleto { get; set; }
        public string cm_observacion { get; set; }
        public System.DateTime cm_fecha { get; set; }
    }
}
