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
    
    public partial class ro_Historico_Liquidacion_Vacaciones_Det
    {
        public int IdEmpresa { get; set; }
        public decimal IdEmpleado { get; set; }
        public int IdLiquidacion { get; set; }
        public int Sec { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public double Total_Remuneracion { get; set; }
        public double Total_Vacaciones { get; set; }
        public double Valor_Cancelar { get; set; }
    
        public virtual ro_Historico_Liquidacion_Vacaciones ro_Historico_Liquidacion_Vacaciones { get; set; }
    }
}
