﻿using Core.Erp.Bus.General;
using Core.Erp.Bus.RRHH;
using Core.Erp.Info.General;
using Core.Erp.Info.Helps;
using Core.Erp.Info.RRHH;
using Core.Erp.Web.Helps;
using Core.Erp.Web.Reportes.RRHH;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Core.Erp.Web.Areas.Reportes.Controllers
{
    [SessionTimeout]
    public class RRHHReportesController : Controller
    {
        #region Metodos ComboBox bajo demanda
        tb_persona_Bus bus_persona = new tb_persona_Bus();
        public ActionResult CmbEmpleado_RRHH()
        {
            cl_filtros_Info model = new cl_filtros_Info();
            return PartialView("_CmbEmpleado_RRHH", model);
        }
        public List<tb_persona_Info> get_list_bajo_demanda(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            return bus_persona.get_list_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa), cl_enumeradores.eTipoPersona.EMPLEA.ToString());
        }
        public tb_persona_Info get_info_bajo_demanda(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_persona.get_info_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa), cl_enumeradores.eTipoPersona.EMPLEA.ToString());
        }
        #endregion
        public ActionResult ROL_001(int IdNomina_Tipo = 0, int IdNomina_TipoLiqui= 0, int IdPeriodo=0)
        {
            ROL_001_Rpt model = new ROL_001_Rpt();
            model.p_IdEmpresa.Value = Convert.ToInt32(SessionFixed.IdEmpresa);
            model.p_IdNomina.Value = IdNomina_Tipo;
            model.p_IdNominaTipo.Value = IdNomina_TipoLiqui;
            model.p_IdPeriodo.Value = IdPeriodo;
            model.usuario = SessionFixed.IdUsuario.ToString();
            model.empresa = SessionFixed.NomEmpresa.ToString();
            return View(model);
        }
        public ActionResult ROL_002(int IdNomina_Tipo = 0, int IdNomina_TipoLiqui = 0, int IdPeriodo = 0)
        {
            ROL_002_Rpt model = new ROL_002_Rpt();
            model.p_IdEmpresa.Value = Convert.ToInt32(SessionFixed.IdEmpresa);
            model.p_IdNomina.Value = IdNomina_Tipo;
            model.p_IdNominaTipo.Value = IdNomina_TipoLiqui;
            model.p_IdPeriodo.Value = IdPeriodo;
            model.empresa.Value = SessionFixed.NomEmpresa.ToString();
            return View(model);
        }
        public ActionResult ROL_003(decimal IdEmpleado=0, decimal IdNovedad=0)
        {
            ROL_003_Rpt model = new ROL_003_Rpt();
            model.p_IdEmpresa.Value = Convert.ToInt32(SessionFixed.IdEmpresa);
            model.p_IdEmpleado.Value = IdEmpleado;
            model.p_IdNovedad.Value = IdNovedad;
            model.usuario = SessionFixed.IdUsuario.ToString();
            model.empresa = SessionFixed.NomEmpresa.ToString();
            return View(model);
        }
        public ActionResult ROL_004(int IdUtilidad=0)
        {
            ROL_004_Rpt model = new ROL_004_Rpt();
            model.p_IdEmpresa.Value = Convert.ToInt32(SessionFixed.IdEmpresa);
            model.p_IdUtilidad.Value = IdUtilidad;
            model.usuario = SessionFixed.IdUsuario.ToString();
            model.empresa = SessionFixed.NomEmpresa.ToString();
            return View(model);
        }
        public ActionResult ROL_005(decimal IdActaFiniquito = 0)
        {
            ROL_005_Rpt model = new ROL_005_Rpt();
            model.p_IdEmpresa.Value = Convert.ToInt32(SessionFixed.IdEmpresa);
            model.p_IdActaFiniquito.Value = IdActaFiniquito;
            model.usuario = SessionFixed.IdUsuario.ToString();
            model.empresa = SessionFixed.NomEmpresa.ToString();
            return View(model);
        }
        public ActionResult ROL_006( decimal IdEmpleado = 0)
        {
            ROL_006_Rpt model = new ROL_006_Rpt();
            model.p_IdEmpresa.Value = Convert.ToInt32(SessionFixed.IdEmpresa);
            model.p_IdEmpleado.Value = IdEmpleado;
            model.usuario = SessionFixed.IdUsuario.ToString();
            model.empresa = SessionFixed.NomEmpresa.ToString();
            return View(model);
        }
        public ActionResult ROL_007(decimal IdEmpleado = 0, int IdSolicitud = 0)
        {
            ROL_007_Rpt model = new ROL_007_Rpt();
            model.p_IdEmpresa.Value = Convert.ToInt32(SessionFixed.IdEmpresa);
            model.p_IdEmpleado.Value = IdEmpleado;
            model.p_IdSolicitud.Value = IdSolicitud;
            model.usuario = SessionFixed.IdUsuario.ToString();
            model.empresa = SessionFixed.NomEmpresa.ToString();
            return View(model);
        }
        public ActionResult ROL_008(decimal IdPrestamo = 0 )
        {
            ROL_008_Rpt model = new ROL_008_Rpt();
            model.p_IdEmpresa.Value = Convert.ToInt32(SessionFixed.IdEmpresa);
            model.p_IdPrestamo.Value = IdPrestamo;
            model.usuario = SessionFixed.IdUsuario.ToString();
            model.empresa = SessionFixed.NomEmpresa.ToString();
            return View(model);
        }
        public ActionResult ROL_009( DateTime? fecha_ini, DateTime? fecha_fin, bool mostrar_nov_can = false, bool mostrar_nov_pen = false, bool mostrar_todas_nov = false)
        {
            cl_filtros_Info model = new cl_filtros_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa)

            };
            cargar_combos(model.IdEmpresa);
            ROL_009_Rpt report = new ROL_009_Rpt();
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_fecha_inicio.Value = model.fecha_ini;
            report.p_fecha_fin.Value = model.fecha_fin;
            report.p_can.Value = mostrar_nov_can;
            report.p_pen.Value = mostrar_nov_pen;
            report.p_todas.Value = mostrar_todas_nov;
            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();
            ViewBag.Report = report;
            return View(model);
        }
        public ActionResult ROL_010()
        {
            ROL_010_Rpt model = new ROL_010_Rpt();
            model.p_IdEmpresa.Value = Convert.ToInt32(SessionFixed.IdEmpresa);
            model.usuario = SessionFixed.IdUsuario.ToString();
            model.empresa = SessionFixed.NomEmpresa.ToString();
            return View(model);
        }
        public ActionResult ROL_011( int IdHorasExtras =0)
        {
            ROL_011_Rpt model = new ROL_011_Rpt();
            model.p_IdEmpresa.Value = Convert.ToInt32(SessionFixed.IdEmpresa);
            model.p_IdHorasExtras.Value = IdHorasExtras;
            model.usuario = SessionFixed.IdUsuario.ToString();
            model.empresa = SessionFixed.NomEmpresa.ToString();
            return View(model);
        }
        private void cargar_combos(int IdEmpresa)
        {
            ro_nomina_tipo_Bus bus_nomina = new ro_nomina_tipo_Bus();
            var lst_nomina = bus_nomina.get_list(IdEmpresa, false);
            ViewBag.lst_nomina = lst_nomina;
        }
        public ActionResult ROL_012( )
        {
            cl_filtros_Info model = new cl_filtros_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa)
            };
            ROL_012_Rpt report = new ROL_012_Rpt();
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_fecha_inicio.Value = model.fecha_ini;
            report.p_fecha_fin.Value = model.fecha_fin;
            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();
            ViewBag.Report = report;
            return View(model);
        }
        [HttpPost]
        public ActionResult ROl_012(cl_filtros_Info model)
        {
            ROL_012_Rpt report = new ROL_012_Rpt();
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_fecha_inicio.Value = model.fecha_ini;
            report.p_fecha_fin.Value = model.fecha_fin;
            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();
            ViewBag.Report = report;
            return View(model);
        }
        public ActionResult ROL_013()
        {
            cl_filtros_Info model = new cl_filtros_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdNomina = 1
            };
            cargar_combos(model.IdEmpresa);
            ROL_013_Rpt report = new ROL_013_Rpt();
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdNomina.Value = model.IdNomina;
            report.p_IdEmpleado.Value = model.IdEmpleado;
            report.p_fecha_inicio.Value = model.fecha_ini;
            report.p_fecha_fin.Value = model.fecha_fin;
            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();
            ViewBag.Report = report;
            return View(model);
        }
        [HttpPost]
        public ActionResult ROL_013(cl_filtros_Info model)
        {
            ROL_013_Rpt report = new ROL_013_Rpt();
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdNomina.Value = model.IdNomina;
            report.p_IdEmpleado.Value = model.IdEmpleado;
            report.p_fecha_inicio.Value = model.fecha_ini;
            report.p_fecha_fin.Value = model.fecha_fin;
            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();
            ViewBag.Report = report;
            cargar_combos(model.IdEmpresa);

            return View(model);
        }
        public ActionResult ROL_014()
        {
            cl_filtros_Info model = new cl_filtros_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdTipoNomina = 0
            };
            cargar_combos(model.IdEmpresa);
            ROL_014_Rpt report = new ROL_014_Rpt();
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdTipoNomina.Value = model.IdTipoNomina;
            ViewBag.Report = report;
            return View(model);
        }
        [HttpPost]
        public ActionResult ROL_014(cl_filtros_Info model)
        {
            ROL_014_Rpt report = new ROL_014_Rpt();
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdTipoNomina.Value = model.IdTipoNomina;
            ViewBag.Report = report;
            return View(model);
        }
        public ActionResult ROL_015()
        {
            cl_filtros_Info model = new cl_filtros_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdEmpleado = 0
                
            };
            ROL_015_Rpt report = new ROL_015_Rpt();
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdEmpleado.Value = model.IdEmpleado;
            report.p_fechaInicio.Value = model.fecha_ini;
            report.p_fechaFin.Value = model.fecha_fin;
            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();
            ViewBag.Report = report;
            return View(model);
        }
        [HttpPost]
        public ActionResult ROL_015(cl_filtros_Info model)
        {
            ROL_015_Rpt report = new ROL_015_Rpt();
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdEmpleado.Value = model.IdEmpleado;
            report.p_fechaInicio.Value = model.fecha_ini;
            report.p_fechaFin.Value = model.fecha_fin;
            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();
            ViewBag.Report = report;
            return View(model);
        }
        public ActionResult ROL_016()
        {
            cl_filtros_Info model = new cl_filtros_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdEmpleado = 0

            };
            ROL_016_Rpt report = new ROL_016_Rpt();
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdEmpleado.Value = model.IdEmpleado;
            report.p_fecha_ini.Value = model.fecha_ini;
            report.p_fecha_fin.Value = model.fecha_fin;
            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();
            ViewBag.Report = report;
            return View(model);
        }
        [HttpPost]
        public ActionResult ROL_016(cl_filtros_Info model)
        {
            ROL_016_Rpt report = new ROL_016_Rpt();
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdEmpleado.Value = model.IdEmpleado;
            report.p_fecha_ini.Value = model.fecha_ini;
            report.p_fecha_fin.Value = model.fecha_fin;
            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();
            ViewBag.Report = report;
            return View(model);
        }
    }
}