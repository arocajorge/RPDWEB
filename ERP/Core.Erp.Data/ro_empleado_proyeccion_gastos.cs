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
    
    public partial class ro_empleado_proyeccion_gastos
    {
        public ro_empleado_proyeccion_gastos()
        {
            this.ro_empleado_proyeccion_gastos_det = new HashSet<ro_empleado_proyeccion_gastos_det>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdTransaccion { get; set; }
        public decimal IdEmpleado { get; set; }
        public int AnioFiscal { get; set; }
        public string Observacion { get; set; }
        public bool estado { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string MotiAnula { get; set; }
    
        public virtual ICollection<ro_empleado_proyeccion_gastos_det> ro_empleado_proyeccion_gastos_det { get; set; }
        public virtual ro_empleado ro_empleado { get; set; }
    }
}
