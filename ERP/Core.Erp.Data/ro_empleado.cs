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
    
    public partial class ro_empleado
    {
        public ro_empleado()
        {
            this.ro_Acta_Finiquito = new HashSet<ro_Acta_Finiquito>();
            this.ro_archivos_bancos_generacion_x_empleado = new HashSet<ro_archivos_bancos_generacion_x_empleado>();
            this.ro_cargaFamiliar = new HashSet<ro_cargaFamiliar>();
            this.ro_contrato = new HashSet<ro_contrato>();
            this.ro_DocumentoxEmp = new HashSet<ro_DocumentoxEmp>();
            this.ro_empleado_proyeccion_gastos = new HashSet<ro_empleado_proyeccion_gastos>();
            this.ro_empleado1 = new HashSet<ro_empleado>();
            this.ro_empleado11 = new HashSet<ro_empleado>();
            this.ro_empleado_x_ro_rubro = new HashSet<ro_empleado_x_ro_rubro>();
            this.ro_empleado_x_ro_tipoNomina = new HashSet<ro_empleado_x_ro_tipoNomina>();
            this.ro_empleado_x_rubro_acumulado = new HashSet<ro_empleado_x_rubro_acumulado>();
            this.ro_empleado_x_titulos = new HashSet<ro_empleado_x_titulos>();
            this.ro_EmpleadoNovedadCargaMasiva_det = new HashSet<ro_EmpleadoNovedadCargaMasiva_det>();
            this.ro_Historico_Liquidacion_Vacaciones = new HashSet<ro_Historico_Liquidacion_Vacaciones>();
            this.ro_historico_vacaciones_x_empleado = new HashSet<ro_historico_vacaciones_x_empleado>();
            this.ro_horario_planificacion_det = new HashSet<ro_horario_planificacion_det>();
            this.ro_HorasProfesores_det = new HashSet<ro_HorasProfesores_det>();
            this.ro_marcaciones_x_empleado = new HashSet<ro_marcaciones_x_empleado>();
            this.ro_nomina_x_horas_extras_det = new HashSet<ro_nomina_x_horas_extras_det>();
            this.ro_NominasPagosCheques_det = new HashSet<ro_NominasPagosCheques_det>();
            this.ro_participacion_utilidad_empleado = new HashSet<ro_participacion_utilidad_empleado>();
            this.ro_permiso_x_empleado = new HashSet<ro_permiso_x_empleado>();
            this.ro_permiso_x_empleado1 = new HashSet<ro_permiso_x_empleado>();
            this.ro_rol_detalle = new HashSet<ro_rol_detalle>();
            this.ro_SancionesPorMarcaciones_det = new HashSet<ro_SancionesPorMarcaciones_det>();
            this.ro_Solicitud_Vacaciones_x_empleado = new HashSet<ro_Solicitud_Vacaciones_x_empleado>();
            this.ro_empleado_x_jornada = new HashSet<ro_empleado_x_jornada>();
            this.ro_empleado_Novedad = new HashSet<ro_empleado_Novedad>();
            this.ro_empleado_Novedad1 = new HashSet<ro_empleado_Novedad>();
            this.ro_empleado_x_division_x_area = new HashSet<ro_empleado_x_division_x_area>();
            this.ro_prestamo = new HashSet<ro_prestamo>();
        }
    
        public int IdEmpresa { get; set; }
        public decimal IdEmpleado { get; set; }
        public Nullable<decimal> IdEmpleado_Supervisor { get; set; }
        public decimal IdPersona { get; set; }
        public int IdSucursal { get; set; }
        public string IdTipoEmpleado { get; set; }
        public string em_codigo { get; set; }
        public string Codigo_Biometrico { get; set; }
        public string em_lugarNacimiento { get; set; }
        public string em_CarnetIees { get; set; }
        public string em_cedulaMil { get; set; }
        public Nullable<System.DateTime> em_fechaSalida { get; set; }
        public Nullable<System.DateTime> em_fechaIngaRol { get; set; }
        public string em_tipoCta { get; set; }
        public string em_NumCta { get; set; }
        public string em_estado { get; set; }
        public Nullable<int> IdCodSectorial { get; set; }
        public int IdDepartamento { get; set; }
        public string IdTipoSangre { get; set; }
        public Nullable<int> IdCargo { get; set; }
        public string IdCtaCble_Emplea { get; set; }
        public string IdCiudad { get; set; }
        public string em_mail { get; set; }
        public string IdTipoLicencia { get; set; }
        public Nullable<int> IdBanco { get; set; }
        public Nullable<int> IdArea { get; set; }
        public Nullable<int> IdDivision { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transaccion { get; set; }
        public string IdUsuarioUltModi { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string MotivoAnulacion { get; set; }
        public double por_discapacidad { get; set; }
        public string carnet_conadis { get; set; }
        public Nullable<double> talla_pant { get; set; }
        public string talla_camisa { get; set; }
        public Nullable<double> talla_zapato { get; set; }
        public string em_status { get; set; }
        public string IdCondicionDiscapacidadSRI { get; set; }
        public string IdTipoIdentDiscapacitadoSustitutoSRI { get; set; }
        public string IdentDiscapacitadoSustitutoSRI { get; set; }
        public string IdAplicaConvenioDobleImposicionSRI { get; set; }
        public string IdTipoResidenciaSRI { get; set; }
        public string IdTipoSistemaSalarioNetoSRI { get; set; }
        public bool es_AcreditaHorasExtras { get; set; }
        public string IdTipoAnticipo { get; set; }
        public Nullable<double> ValorAnticipo { get; set; }
        public string CodigoSectorial { get; set; }
        public Nullable<double> em_AnticipoSueldo { get; set; }
        public bool Marca_Biometrico { get; set; }
        public Nullable<int> IdHorario { get; set; }
        public bool Tiene_ingresos_compartidos { get; set; }
        public bool Pago_por_horas { get; set; }
        public Nullable<double> Valor_maximo_horas_vesp { get; set; }
        public Nullable<double> Valor_maximo_horas_mat { get; set; }
        public Nullable<double> Valor_horas_vespertina { get; set; }
        public Nullable<double> Valor_horas_matutino { get; set; }
        public Nullable<double> Valor_horas_brigada { get; set; }
        public Nullable<double> Valor_hora_adicionales { get; set; }
        public Nullable<double> Valor_hora_control_salida { get; set; }
        public bool GozaMasDeQuinceDiasVaciones { get; set; }
        public double DiasVacaciones { get; set; }
        public Nullable<decimal> IdEmpleadoPAdre { get; set; }
    
        public virtual ICollection<ro_Acta_Finiquito> ro_Acta_Finiquito { get; set; }
        public virtual ICollection<ro_archivos_bancos_generacion_x_empleado> ro_archivos_bancos_generacion_x_empleado { get; set; }
        public virtual ICollection<ro_cargaFamiliar> ro_cargaFamiliar { get; set; }
        public virtual ro_catalogo ro_catalogo { get; set; }
        public virtual ro_catalogo ro_catalogo1 { get; set; }
        public virtual ro_catalogo ro_catalogo2 { get; set; }
        public virtual ro_catalogo ro_catalogo3 { get; set; }
        public virtual ICollection<ro_contrato> ro_contrato { get; set; }
        public virtual ro_Departamento ro_Departamento { get; set; }
        public virtual ro_Division ro_Division { get; set; }
        public virtual ICollection<ro_DocumentoxEmp> ro_DocumentoxEmp { get; set; }
        public virtual ICollection<ro_empleado_proyeccion_gastos> ro_empleado_proyeccion_gastos { get; set; }
        public virtual ICollection<ro_empleado> ro_empleado1 { get; set; }
        public virtual ro_empleado ro_empleado2 { get; set; }
        public virtual ICollection<ro_empleado> ro_empleado11 { get; set; }
        public virtual ro_empleado ro_empleado3 { get; set; }
        public virtual ICollection<ro_empleado_x_ro_rubro> ro_empleado_x_ro_rubro { get; set; }
        public virtual ICollection<ro_empleado_x_ro_tipoNomina> ro_empleado_x_ro_tipoNomina { get; set; }
        public virtual ICollection<ro_empleado_x_rubro_acumulado> ro_empleado_x_rubro_acumulado { get; set; }
        public virtual ICollection<ro_empleado_x_titulos> ro_empleado_x_titulos { get; set; }
        public virtual ro_EmpleadoFoto ro_EmpleadoFoto { get; set; }
        public virtual ICollection<ro_EmpleadoNovedadCargaMasiva_det> ro_EmpleadoNovedadCargaMasiva_det { get; set; }
        public virtual ICollection<ro_Historico_Liquidacion_Vacaciones> ro_Historico_Liquidacion_Vacaciones { get; set; }
        public virtual ICollection<ro_historico_vacaciones_x_empleado> ro_historico_vacaciones_x_empleado { get; set; }
        public virtual ICollection<ro_horario_planificacion_det> ro_horario_planificacion_det { get; set; }
        public virtual ICollection<ro_HorasProfesores_det> ro_HorasProfesores_det { get; set; }
        public virtual ICollection<ro_marcaciones_x_empleado> ro_marcaciones_x_empleado { get; set; }
        public virtual ICollection<ro_nomina_x_horas_extras_det> ro_nomina_x_horas_extras_det { get; set; }
        public virtual ICollection<ro_NominasPagosCheques_det> ro_NominasPagosCheques_det { get; set; }
        public virtual ICollection<ro_participacion_utilidad_empleado> ro_participacion_utilidad_empleado { get; set; }
        public virtual ICollection<ro_permiso_x_empleado> ro_permiso_x_empleado { get; set; }
        public virtual ICollection<ro_permiso_x_empleado> ro_permiso_x_empleado1 { get; set; }
        public virtual ICollection<ro_rol_detalle> ro_rol_detalle { get; set; }
        public virtual ICollection<ro_SancionesPorMarcaciones_det> ro_SancionesPorMarcaciones_det { get; set; }
        public virtual ICollection<ro_Solicitud_Vacaciones_x_empleado> ro_Solicitud_Vacaciones_x_empleado { get; set; }
        public virtual ro_cargo ro_cargo { get; set; }
        public virtual ICollection<ro_empleado_x_jornada> ro_empleado_x_jornada { get; set; }
        public virtual ICollection<ro_empleado_Novedad> ro_empleado_Novedad { get; set; }
        public virtual ICollection<ro_empleado_Novedad> ro_empleado_Novedad1 { get; set; }
        public virtual ICollection<ro_empleado_x_division_x_area> ro_empleado_x_division_x_area { get; set; }
        public virtual ICollection<ro_prestamo> ro_prestamo { get; set; }
    }
}
