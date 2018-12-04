﻿using Core.Erp.Bus.General;
using Core.Erp.Bus.Presupuesto;
using Core.Erp.Info.Helps;
using Core.Erp.Info.Presupuesto;
using Core.Erp.Web.Helps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Erp.Web.Areas.Presupuesto.Controllers
{
    public class PresupuestoController : Controller
    {
        // GET: Presupuesto/Presupuesto
        #region Variables
        tb_sucursal_Bus bus_sucursal = new tb_sucursal_Bus();
        pre_Presupuesto_Bus bus_Presupuesto  = new pre_Presupuesto_Bus();
        pre_Presupuesto_x_grupo_Bus bus_Presupuesto_x_grupo = new pre_Presupuesto_x_grupo_Bus();
        pre_Presupuesto_x_grupo_det_Bus bus_Presupuesto_x_grupo_det = new pre_Presupuesto_x_grupo_det_Bus();

        pre_GrupoDet_List Lista_x_grupo_det = new pre_GrupoDet_List();
        string mensaje = string.Empty;
        #endregion

        #region Index
        public ActionResult Index()
        {
            cl_filtros_Info model = new cl_filtros_Info
            {
                IdEmpresa = string.IsNullOrEmpty(SessionFixed.IdEmpresa) ? 0 : Convert.ToInt32(SessionFixed.IdEmpresa),
                IdSucursal = string.IsNullOrEmpty(SessionFixed.IdSucursal) ? 0 : Convert.ToInt32(SessionFixed.IdSucursal)
            };

            CargarCombos(model.IdEmpresa);
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(cl_filtros_Info model)
        {
            CargarCombos(model.IdEmpresa);
            return View(model);
        }

        private void CargarCombos(int IdEmpresa)
        {
            try
            {
                var lst_sucursal = bus_sucursal.get_list(IdEmpresa, false);
                ViewBag.lst_sucursal = lst_sucursal;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_Presupuesto(DateTime? FechaInicio, DateTime? FechaFin, int IdSucursal)
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            ViewBag.FechaInicio = FechaInicio == null ? DateTime.Now.Date.AddMonths(-1) : Convert.ToDateTime(FechaInicio);
            ViewBag.FechaFin = FechaFin == null ? DateTime.Now.Date : Convert.ToDateTime(FechaFin);
            ViewBag.IdSucursal = IdSucursal == 0 ? 0 : Convert.ToInt32(IdSucursal);

            List<pre_Presupuesto_Info> model = bus_Presupuesto.GetList(IdEmpresa, IdSucursal, ViewBag.FechaInicio, ViewBag.FechaFin, true);

            CargarCombos(IdEmpresa);
            return PartialView("_GridViewPartial_Presupuesto", model);
        }
        #endregion

        #region Acciones
        public ActionResult Nuevo(int IdEmpresa = 0)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion

            pre_Presupuesto_Info model = new pre_Presupuesto_Info
            {
                IdEmpresa = IdEmpresa,
                IdSucursal = string.IsNullOrEmpty(SessionFixed.IdSucursal) ? 0 : Convert.ToInt32(SessionFixed.IdSucursal),
                IdUsuarioCreacion = SessionFixed.IdUsuario,
                FechaInicio = DateTime.Now.Date.AddMonths(-1),
                FechaFin = DateTime.Now.Date
            };

            CargarCombos(model.IdEmpresa);

            return View(model);
        }
        [HttpPost]
        public ActionResult Nuevo(pre_Presupuesto_Info model)
        {
            //if (!Validar(model, ref mensaje))
            //{
            //    CargarCombosAccion(model.IdEmpresa, model.IdSucursal);
            //    ViewBag.mensaje = mensaje;
            //    SessionFixed.IdTransaccionSessionActual = model.IdTransaccionSession.ToString();
            //    return View(model);
            //}
            if (!bus_Presupuesto.GuardarBD(model))
            {
                CargarCombos(model.IdEmpresa);
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Modificar(int IdEmpresa = 0, int IdPresupuesto = 0)
        {
            CargarCombos(IdEmpresa);

            pre_Presupuesto_Info model = new pre_Presupuesto_Info();
            model = bus_Presupuesto.GetInfo(IdEmpresa, IdPresupuesto);

            if (model == null)
                return RedirectToAction("Index");

            CargarCombos(model.IdEmpresa);
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(pre_Presupuesto_Info model)
        {
            model.IdUsuarioModificacion = Session["IdUsuario"].ToString();

            if (!bus_Presupuesto.ModificarBD(model))
            {
                CargarCombos(model.IdEmpresa);
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Anular(int IdEmpresa = 0, decimal IdPresupuesto = 0)
        {
            pre_Presupuesto_Info model = bus_Presupuesto.GetInfo(IdEmpresa, Convert.ToInt32(IdPresupuesto));
            if (model == null)
                return RedirectToAction("Index");

            CargarCombos(model.IdEmpresa);
            return View(model);
        }
        [HttpPost]
        public ActionResult Anular(pre_Presupuesto_Info model)
        {
            model.IdUsuarioAnulacion = SessionFixed.IdUsuario.ToString();
            if (!bus_Presupuesto.AnularBD(model))
            {
                ViewBag.mensaje = "No se ha podido anular el registro";
                CargarCombos(model.IdEmpresa);
                return View(model);
            };
            return RedirectToAction("Index");
        }
        #endregion
    }


    /*
    public class pre_Presupuesto_x_grupo_det_Lista
    {
        string Variable = "pre_Presupuesto_x_grupo_det_Info";
        public List<pre_Presupuesto_x_grupo_det_Info> get_list(decimal IdTransaccionSession)
        {

            if (HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] == null)
            {
                List<pre_Presupuesto_x_grupo_det_Info> list = new List<pre_Presupuesto_x_grupo_det_Info>();

                HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<pre_Presupuesto_x_grupo_det_Info>)HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()];
        }

        public void set_list(List<pre_Presupuesto_x_grupo_det_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
        }

        public void AddRow(pre_Presupuesto_x_grupo_det_Info info_det, decimal IdTransaccionSession)
        {
            List<pre_Presupuesto_x_grupo_det_Info> list = get_list(IdTransaccionSession);
            info_det.Secuencia = list.Count == 0 ? 1 : list.Max(q => q.Secuencia) + 1;
            info_det.IdRubro = info_det.IdRubro;
            info_det.Cantidad = info_det.Cantidad;
            info_det.Monto = info_det.Monto;

            list.Add(info_det);
        }

        public void UpdateRow(pre_Presupuesto_x_grupo_det_Info info_det, decimal IdTransaccionSession)
        {
            pre_Presupuesto_x_grupo_det_Info edited_info = get_list(IdTransaccionSession).Where(m => m.Secuencia == info_det.Secuencia).First();
            edited_info.IdRubro = info_det.IdRubro;
            edited_info.Cantidad = info_det.Cantidad;
            edited_info.Monto = info_det.Monto;
        }

        public void DeleteRow(int Secuencia, decimal IdTransaccionSession)
        {
            List<pre_Presupuesto_x_grupo_det_Info> list = get_list(IdTransaccionSession);
            list.Remove(list.Where(m => m.Secuencia == Secuencia).First());
        }
    }*/
}