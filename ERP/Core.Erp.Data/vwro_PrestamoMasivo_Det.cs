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
    
    public partial class vwro_PrestamoMasivo_Det
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public decimal IdCarga { get; set; }
        public int Secuencia { get; set; }
        public Nullable<decimal> IdPrestamo { get; set; }
        public decimal IdEmpleado { get; set; }
        public decimal IdPersona { get; set; }
        public string pe_nombreCompleto { get; set; }
        public string IdRubro { get; set; }
        public string ru_descripcion { get; set; }
        public double Monto { get; set; }
        public int NumCuotas { get; set; }
    }
}
