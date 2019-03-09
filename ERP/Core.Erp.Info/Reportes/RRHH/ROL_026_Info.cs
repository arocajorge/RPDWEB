﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.Reportes.RRHH
{
    public class ROL_026_Info
    {
        public int IdEmpresa { get; set; }
        public int pe_anio { get; set; }
        public decimal IdEmpleado { get; set; }
        public int IdSucursal { get; set; }
        public int IdNomina_Tipo { get; set; }
        public string Su_CodigoEstablecimiento { get; set; }
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
    }
}