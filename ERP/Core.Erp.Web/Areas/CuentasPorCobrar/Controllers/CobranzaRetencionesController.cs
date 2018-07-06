﻿using DevExpress.Web.Mvc;
using Core.Erp.Info.CuentasPorCobrar;
using Core.Erp.Web.Helps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Erp.Bus.CuentasPorCobrar;
using Core.Erp.Info.Helps;
using Core.Erp.Bus.General;

namespace Core.Erp.Web.Areas.CuentasPorCobrar.Controllers
{
    public class CobranzaRetencionesController : Controller
    {
        cxc_cobro_Bus bus_cobro = new cxc_cobro_Bus();
        cxc_cobro_det_Bus bus_det = new cxc_cobro_det_Bus();
        cxc_cobro_tipo_Bus bus_cobro_tipo = new cxc_cobro_tipo_Bus();
        cxc_cobro_det_ret_List List_det = new cxc_cobro_det_ret_List();
        string mensaje = string.Empty;
        #region Index
        public ActionResult Index()
        {
            cl_filtros_Info model = new cl_filtros_Info
            {
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal)
            };
            cargar_combos();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(cl_filtros_Info model)
        {
            cargar_combos();
            return View(model);
        }
        private void cargar_combos()
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            tb_sucursal_Bus bus_sucursal = new tb_sucursal_Bus();
            var lst_sucursal = bus_sucursal.get_list(IdEmpresa, false);
            ViewBag.lst_sucursal = lst_sucursal;
        }

        private void cargar_combos_det()
        {
            var lst_retenciones = bus_cobro_tipo.get_list_retenciones(false);
            ViewBag.lst_retenciones = lst_retenciones;
        }

        private bool validar(cxc_cobro_Info i_validar, ref string msg)
        {
            i_validar.IdEntidad = i_validar.IdCliente;            
            i_validar.cr_TotalCobro = i_validar.lst_det.Sum(q => q.dc_ValorPago);
            i_validar.IdCaja = i_validar.IdCaja == 0 ? 1 : i_validar.IdCaja;
            i_validar.lst_det.ForEach(q => { q.IdEmpresa = i_validar.IdEmpresa; q.IdSucursal = i_validar.IdSucursal; q.IdCobro = i_validar.IdCobro; q.IdBodega_Cbte = i_validar.IdBodega; q.IdCbte_vta_nota = i_validar.IdCbteVta; q.dc_TipoDocumento = i_validar.vt_tipoDoc; });
            if (i_validar.lst_det.Count == 0)
            {
                msg = "No ha ingresado valores para realizar la retención";
                return false;
            }
            if (i_validar.lst_det.Where(q => q.dc_ValorPago == 0).Count() > 0)
            {
                msg = "Existen documentos con valor aplicado 0";
                return false;
            }
            string observacion = "Retención./ "+i_validar.vt_NumFactura+" # Ret./"+i_validar.cr_NumDocumento;
            
            i_validar.cr_observacion = observacion;
            i_validar.cr_fechaCobro = i_validar.cr_fecha;
            i_validar.cr_fechaDocu = i_validar.cr_fecha;            

            i_validar.IdBanco = null;
            i_validar.cr_Banco = null;
            return true;
        }


        [ValidateInput(false)]
        public ActionResult GridViewPartial_cobranza_ret( DateTime? fecha_ini , DateTime? fecha_fin, int IdSucursal = 0)
        {
            ViewBag.fecha_ini = fecha_ini == null ? DateTime.Now.Date.AddMonths(-1) : fecha_ini;
            ViewBag.fecha_fin = fecha_fin == null ? DateTime.Now.Date : fecha_fin;
            ViewBag.IdSucursal = IdSucursal;
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            List<cxc_cobro_Info> model =  bus_cobro.get_list_para_retencion(IdEmpresa, IdSucursal, Convert.ToDateTime(fecha_ini), Convert.ToDateTime(fecha_fin));
            cargar_combos_det();
            return PartialView("_GridViewPartial_cobranza_ret", model);
        }
        #endregion

        #region Aplicar retención
        public ActionResult AplicarRetencion(int IdSucursal = 0, int IdBodega = 0, decimal IdCbteVta = 0, string CodTipoDocumento = "")
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            cxc_cobro_Info model = bus_cobro.get_info_para_retencion(IdEmpresa, IdSucursal, IdBodega, IdCbteVta, CodTipoDocumento);
            if (model == null)            
                return RedirectToAction("Index");            
            model.lst_det = bus_det.get_list(IdEmpresa, IdSucursal, IdBodega, IdCbteVta, CodTipoDocumento);
            if (model.lst_det.Count == 0)
            {                
                model.cr_fechaCobro = DateTime.Now.Date;
                model.cr_NumDocumento = string.Empty;
            }
            else
            {
                model.IdCobro = model.lst_det[0].IdCobro;
                model.cr_fecha = model.lst_det[0].cr_fecha;
                model.cr_NumDocumento = model.lst_det[0].cr_NumDocumento;
            }
            List_det.set_list(model.lst_det);
            return View(model);
        }
        [HttpPost]
        public ActionResult AplicarRetencion(cxc_cobro_Info model)
        {
            model.lst_det = List_det.get_list();
            if (!validar(model,ref mensaje))
            {
                ViewBag.mensaje = mensaje;
                return View(model);
            }
            if (model.IdCobro != 0)
            {
                if (!bus_cobro.modificarDB(model))
                {
                    ViewBag.mensaje = "No se ha podido modificar el registro";
                    return View(model);
                }
            }
            else
                if (!bus_cobro.guardarDB(model))
            {
                ViewBag.mensaje = "No se ha podido guardar el registro";
                return View(model);
            }            
            return RedirectToAction("Index");
        }
        #endregion

        #region Json
        public JsonResult SetValorRetencion(string IdCobro_tipo = "")
        {
            var resultado = bus_cobro_tipo.get_info(IdCobro_tipo);
            if (resultado == null)
                resultado = new cxc_cobro_tipo_Info();
            return Json(resultado, JsonRequestBehavior.AllowGet);            
        }
        #endregion

        #region Acciones grilla
        public ActionResult EditingAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] cxc_cobro_det_Info info_det)
        {
            if (ModelState.IsValid)
                List_det.AddRow(info_det);
            var model = List_det.get_list();
            cargar_combos_det();
            return PartialView("_GridViewPartial_cobranza_ret_det", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] cxc_cobro_det_Info info_det)
        {
            if (ModelState.IsValid)
                List_det.UpdateRow(info_det);
            var model = List_det.get_list();
            cargar_combos_det();
            return PartialView("_GridViewPartial_cobranza_ret_det", model);
        }

        public ActionResult EditingDelete(int secuencial)
        {
            List_det.DeleteRow(secuencial);
            var model = List_det.get_list();
            cargar_combos_det();
            return PartialView("_GridViewPartial_cobranza_ret_det", model);
        }
        #endregion

        [ValidateInput(false)]
        public ActionResult GridViewPartial_cobranza_ret_det()
        {
            var model = List_det.get_list();
            cargar_combos_det();
            return PartialView("_GridViewPartial_cobranza_ret_det", model);
        }
    }

    public class cxc_cobro_det_ret_List
    {
        public List<cxc_cobro_det_Info> get_list()
        {
            if (HttpContext.Current.Session["cxc_cobro_det_ret"] == null)
            {
                List<cxc_cobro_det_Info> list = new List<cxc_cobro_det_Info>();

                HttpContext.Current.Session["cxc_cobro_det_ret"] = list;
            }
            return (List<cxc_cobro_det_Info>)HttpContext.Current.Session["cxc_cobro_det_ret"];
        }

        public void set_list(List<cxc_cobro_det_Info> list)
        {
            HttpContext.Current.Session["cxc_cobro_det_ret"] = list;
        }

        public void AddRow(cxc_cobro_det_Info info_det)
        {
            List<cxc_cobro_det_Info> list = get_list();
            info_det.secuencial = list.Count == 0 ? 1 : list.Max(q => q.secuencial) + 1;
            list.Add(info_det);
        }

        public void UpdateRow(cxc_cobro_det_Info info_det)
        {
            cxc_cobro_det_Info edited_info = get_list().Where(m => m.secuencial == info_det.secuencial).First();
            edited_info.IdCobro_tipo_det = info_det.IdCobro_tipo_det;
            edited_info.dc_ValorPago = info_det.dc_ValorPago;
        }

        public void DeleteRow(int secuencial)
        {
            List<cxc_cobro_det_Info> list = get_list();
            list.Remove(list.Where(m => m.secuencial == secuencial).First());
        }
    }
}