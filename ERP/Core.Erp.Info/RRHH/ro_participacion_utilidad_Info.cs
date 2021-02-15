﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Info.RRHH
{
   public class ro_participacion_utilidad_Info
    {
        public int IdEmpresa { get; set; }
        public decimal IdTransaccionSession { get; set; }
        public int IdUtilidad { get; set; }
       
        [Required(ErrorMessage = "El campo período es obligatorio")]
        public int IdPeriodo { get; set; }
        [Required(ErrorMessage = "La base de utilidad es obligatoria")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Ingrese solo numeros")]
        public double BaseUtilidad { get; set; }

        [Required(ErrorMessage = "El monto de utilidad es obligatorio")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Ingrese solo numeros")]
        public double Utilidad { get; set; }
        [Required(ErrorMessage = "El monto individual es obligatorio")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Ingrese solo numeros")]
        public double UtilidadDerechoIndividual { get; set; }
        [Required(ErrorMessage = "El monto por carga es obligatorio")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Ingrese solo numeros")]
        public double UtilidadCargaFamiliar { get; set; }
        public double LimiteDistribucionUtilidad { get; set; }
        public Nullable<System.DateTime> FechaIngresa { get; set; }
        public string UsuarioIngresa { get; set; }
        public string Observacion { get; set; }
        public string IdUsuarioModifica { get; set; }
        public Nullable<System.DateTime> Fecha_ultima_modif { get; set; }
        public string IdUsuario_anula { get; set; }
        public Nullable<System.DateTime> Fecha_anulacion { get; set; }
        public String Estado { get; set; }
        public bool EstadoBool { get; set; }
        // vista
        public string Cerrado { get; set; }
        public string Procesado { get; set; }
        public System.DateTime pe_FechaIni { get; set; }
        public System.DateTime pe_FechaFin { get; set; }
        public string Descripcion { get; set; }
        public int IdSucursal { get; set; }

        public List<ro_participacion_utilidad_empleado_Info> detalle { get; set; }
        public ro_participacion_utilidad_Info()
        {
            detalle = new List<ro_participacion_utilidad_empleado_Info>();
        }
    }

    public class ro_participacion_calculo_Info
    {
        public double BaseUtilidad { get; set; }
        public double Utilidad { get; set; }
        public double UtilidadDerechoIndividual { get; set; }
        public double UtilidadCargaFamiliar { get; set; }
    }
}
