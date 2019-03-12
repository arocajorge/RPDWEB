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
    
    public partial class ro_rdep_det
    {
        public int IdEmpresa { get; set; }
        public int Id_Rdep { get; set; }
        public int Secuencia { get; set; }
        public decimal IdEmpleado { get; set; }
        public string pe_cedulaRuc { get; set; }
        public string pe_nombre { get; set; }
        public string pe_apellido { get; set; }
        public Nullable<double> Sueldo { get; set; }
        public Nullable<decimal> FondosReserva { get; set; }
        public Nullable<decimal> DecimoTercerSueldo { get; set; }
        public Nullable<double> DecimoCuartoSueldo { get; set; }
        public Nullable<decimal> Vacaciones { get; set; }
        public Nullable<double> AportePErsonal { get; set; }
        public Nullable<double> GastoAlimentacion { get; set; }
        public Nullable<double> GastoEucacion { get; set; }
        public Nullable<double> GastoSalud { get; set; }
        public Nullable<double> GastoVestimenta { get; set; }
        public Nullable<double> GastoVivienda { get; set; }
        public Nullable<double> Utilidades { get; set; }
        public Nullable<double> IngresoVarios { get; set; }
        public Nullable<double> IngresoPorOtrosEmpleaodres { get; set; }
        public Nullable<double> IessPorOtrosEmpleadores { get; set; }
        public Nullable<double> ValorImpuestoPorEsteEmplador { get; set; }
        public Nullable<double> ValorImpuestoPorOtroEmplador { get; set; }
        public Nullable<double> ExoneraionPorDiscapacidad { get; set; }
        public Nullable<double> ExoneracionPorTerceraEdad { get; set; }
        public Nullable<double> OtrosIngresosRelacionDependencia { get; set; }
        public Nullable<double> ImpuestoRentaCausado { get; set; }
        public Nullable<double> ValorImpuestoRetenidoTrabajador { get; set; }
        public Nullable<double> ImpuestoRentaAsumidoPorEsteEmpleador { get; set; }
        public Nullable<double> BaseImponibleGravada { get; set; }
        public Nullable<double> IngresosGravadorPorEsteEmpleador { get; set; }
    
        public virtual ro_empleado ro_empleado { get; set; }
        public virtual ro_rdep ro_rdep { get; set; }
    }
}
