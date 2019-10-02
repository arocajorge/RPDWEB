﻿using Core.Erp.Bus.General;
using Core.Erp.Bus.Contabilidad;
using Core.Erp.Bus.Inventario;
using Core.Erp.Info.General;
using Core.Erp.Info.Helps;
using Core.Erp.Info.Inventario;
using Core.Erp.Web.Areas.Inventario.Controllers;
using Core.Erp.Web.Helps;
using Core.Erp.Web.Reportes.Inventario;
using DevExpress.Web;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Core.Erp.Info.Contabilidad;

namespace Core.Erp.Web.Areas.Reportes.Controllers
{
    [SessionTimeout]
    public class InventarioReportesController : Controller
    {
        in_Producto_Bus bus_producto = new in_Producto_Bus();
        in_Producto_List List_decimal = new in_Producto_List();
        tb_sis_reporte_x_tb_empresa_Bus bus_rep_x_emp = new tb_sis_reporte_x_tb_empresa_Bus();
        in_Ing_Egr_Inven_Bus bus_ing_egr = new in_Ing_Egr_Inven_Bus();
        string RootReporte = System.IO.Path.GetTempPath() + "Rpt_Facturacion.repx";

        #region Metodos ComboBox bajo demanda
        public ActionResult CmbProducto_Inventario()
        {
            decimal model = new decimal();
            return PartialView("_CmbProducto_Inventario", model);
        }
        public List<in_Producto_Info> get_list_bajo_demanda(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            return bus_producto.get_list_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa), cl_enumeradores.eTipoBusquedaProducto.PORSUCURSAL, cl_enumeradores.eModulo.INV, Convert.ToInt32(SessionFixed.IdSucursal));
        }
        public in_Producto_Info get_info_bajo_demanda(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_producto.get_info_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa));
        }
        #endregion

        #region Metodos ComboBox bajo demanda centro de costo
        ct_CentroCosto_Bus bus_cc = new ct_CentroCosto_Bus();

        public ActionResult CmbCentroCosto_Inventario()
        {
            string model = string.Empty;
            return PartialView("_CmbCentroCosto_Inventario", model);
        }
        public List<ct_CentroCosto_Info> get_list_bajo_demandaCC(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            List<ct_CentroCosto_Info> Lista = bus_cc.get_list_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa), false);
            return Lista;
        }
        public ct_CentroCosto_Info get_info_bajo_demandaCC(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_cc.get_info_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa));
        }
        #endregion

        #region json

        public JsonResult cargar_bodega(int IdEmpresa = 0, int IdSucursal = 0)
        {
            tb_bodega_Bus bus_bodega = new tb_bodega_Bus();
            var resultado = bus_bodega.get_list(IdEmpresa, IdSucursal, false);

            resultado.Add(new tb_bodega_Info
            {
                IdEmpresa = IdEmpresa,
                IdBodega = 0,
                bo_Descripcion = "TODAS"
            });

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult cargar_lineas(int IdEmpresa = 0, string IdCategoria = "")
        {
            in_linea_Bus bus_linea = new in_linea_Bus();
            var resultado = bus_linea.get_list(IdEmpresa, IdCategoria, false);
            resultado.Add(new in_linea_Info
            {
                IdEmpresa = IdEmpresa,
                IdCategoria = IdCategoria,
                IdLinea = 0,
                nom_linea = "Todos"
            });
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult cargar_grupos(int IdEmpresa = 0, string IdCategoria = "", int IdLinea = 0)
        {
            in_grupo_Bus bus_grupo = new in_grupo_Bus();
            var resultado = bus_grupo.get_list(IdEmpresa, IdCategoria, IdLinea, false);
            resultado.Add(new in_grupo_Info
            {
                IdEmpresa = IdEmpresa,
                IdCategoria = IdCategoria,
                IdLinea = IdLinea,
                IdGrupo = 0,
                nom_grupo = "Todos"
            });
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult cargar_subgrupos(int IdEmpresa = 0, string IdCategoria = "", int IdLinea = 0, int IdGrupo = 0)
        {
            in_subgrupo_Bus bus_subgrupo = new in_subgrupo_Bus();
            var resultado = bus_subgrupo.get_list(IdEmpresa, IdCategoria, IdLinea, IdGrupo, false);
            resultado.Add(new in_subgrupo_Info
            {
                IdEmpresa = IdEmpresa,
                IdCategoria = IdCategoria,
                IdLinea = IdLinea,
                IdGrupo = IdGrupo,
                IdSubgrupo = 0,
                nom_subgrupo = "Todos"
            });
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult cargar_tipo_movimiento(int IdEmpresa = 0, string Signo = "")
        {
            in_movi_inven_tipo_Bus bus_tipo_mov = new in_movi_inven_tipo_Bus();
            var resultado = bus_tipo_mov.get_list(IdEmpresa, Signo, false);

            resultado.Add(new in_movi_inven_tipo_Info
            {
                IdEmpresa = IdEmpresa,
                IdMovi_inven_tipo = 0,
                tm_descripcion = "TODOS"
            });

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region GRids
        [ValidateInput(false)]
        public ActionResult GridViewPartial_producto_lst()
        {
            var model = List_decimal.get_list();
            return PartialView("_GridViewPartial_producto_lst", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] in_Producto_Info info_det)
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            if (info_det != null)
                if (info_det.IdProducto != 0)
                {
                    info_det = bus_producto.get_info(IdEmpresa, info_det.IdProducto);
                }
            List_decimal.AddRow(info_det);
            var model = List_decimal.get_list();
            return PartialView("_GridViewPartial_producto_lst", model);
        }
        public ActionResult EditingDelete(decimal IdProducto)
        {
            List_decimal.DeleteRow(IdProducto);
            var model = List_decimal.get_list();
            return PartialView("_GridViewPartial_producto_lst", model);
        }

        #endregion
        private void cargar_sucursal_check(int IdEmpresa, int[] intArray)
        {
            tb_sucursal_Bus bus_sucursal = new tb_sucursal_Bus();
            var lst_sucursal = bus_sucursal.get_list(IdEmpresa, false);
            if (intArray == null || intArray.Count() == 0)
            {
                lst_sucursal.Where(q => q.IdSucursal == Convert.ToInt32(SessionFixed.IdSucursal)).FirstOrDefault().Seleccionado = true;
            }
            else
                foreach (var item in lst_sucursal)
                {
                    item.Seleccionado = (intArray.Where(q => q == item.IdSucursal).Count() > 0 ? true : false);
                }
            ViewBag.lst_sucursal = lst_sucursal;
        }

        public ActionResult INV_001(int IdSucursal = 0, int IdMovi_inven_tipo = 0, decimal IdNumMovi = 0, string Aprobar = "")
        {
            INV_001_Rpt rpt = new INV_001_Rpt();

            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_001");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                rpt.LoadLayout(RootReporte);
            }
            #endregion
            rpt.p_IdEmpresa.Value = Convert.ToInt32(SessionFixed.IdEmpresa);
            rpt.p_IdSucursal.Value = IdSucursal;
            rpt.p_IdMovi_inven_tipo.Value = IdMovi_inven_tipo;
            rpt.p_IdNumMovi.Value = IdNumMovi;
            rpt.usuario = SessionFixed.IdUsuario;
            rpt.empresa = SessionFixed.NomEmpresa;

            in_Ing_Egr_Inven_Info model = bus_ing_egr.get_info(Convert.ToInt32(SessionFixed.IdEmpresa), IdSucursal, IdMovi_inven_tipo, IdNumMovi);
            ViewBag.Aprobar = (model == null) ? "" : ((model.IdEstadoAproba == "") || model.IdEstadoAproba == "XAPRO") ? "S" : "";
            ViewBag.SecuencialID = Convert.ToInt32(SessionFixed.IdEmpresa).ToString("00") + IdSucursal.ToString("00") + IdMovi_inven_tipo.ToString("00") + IdNumMovi.ToString("00000000");

            ViewBag.Reporte = rpt;
            return View(model);
        }

        [HttpPost]
        public ActionResult INV_001(in_Ing_Egr_Inven_Info model)
        {
            bus_ing_egr.aprobarDB(model);

            return RedirectToAction("Index", "AprobacionMovimientoInventario", new { Area = "Inventario", IdSucursal = model.IdSucursal, IdBodega = model.IdBodega });
        }

        public ActionResult INV_002(int IdSucursal = 0, int IdMovi_inven_tipo = 0, decimal IdNumMovi = 0, string Aprobar="")
        {
            INV_002_Rpt rpt = new INV_002_Rpt();
            
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_002");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                rpt.LoadLayout(RootReporte);
            }
            #endregion
            rpt.p_IdEmpresa.Value = Convert.ToInt32(SessionFixed.IdEmpresa);
            rpt.p_IdSucursal.Value = IdSucursal;
            rpt.p_IdMovi_inven_tipo.Value = IdMovi_inven_tipo;
            rpt.p_IdNumMovi.Value = IdNumMovi;
            rpt.usuario = SessionFixed.IdUsuario;
            rpt.empresa = SessionFixed.NomEmpresa;

            in_Ing_Egr_Inven_Info model = bus_ing_egr.get_info(Convert.ToInt32(SessionFixed.IdEmpresa), IdSucursal,IdMovi_inven_tipo, IdNumMovi);
            ViewBag.Aprobar = (model == null)? "" : ((model.IdEstadoAproba == "") || model.IdEstadoAproba == "XAPRO") ? "S" : "";
            ViewBag.SecuencialID = Convert.ToInt32(SessionFixed.IdEmpresa).ToString("00") + IdSucursal.ToString("00") + IdMovi_inven_tipo.ToString("00") + IdNumMovi.ToString("00000000");
            
            ViewBag.Reporte = rpt;
            return View(model);
        }

        [HttpPost]
        public ActionResult INV_002(in_Ing_Egr_Inven_Info model)
        {
            bus_ing_egr.aprobarDB(model);

            return RedirectToAction("Index", "AprobacionMovimientoInventario",new { Area = "Inventario", IdSucursal = model.IdSucursal, IdBodega = model.IdBodega});
        }

        public ActionResult INV_003()
        {

            cl_filtros_inventario_Info model = new cl_filtros_inventario_Info {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdCategoria = "",
                IdMarca = 0,
                IdProducto = 0,
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal),
                IdLinea = 0,
                IdGrupo = 0,
                IdSubGrupo = 0,
                considerarSinAprobar = false,
                InventarioFisico = false
            };

            cargar_combos(model);
            INV_003_Rpt report = new INV_003_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_003");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_IdBodega.Value = model.IdBodega;
            report.p_IdProducto.Value = model.IdProducto ?? 0;
            report.p_IdCategoria.Value = model.IdCategoria == null ? "" : model.IdCategoria;
            report.p_IdLinea.Value = model.IdLinea;
            report.p_IdGrupo.Value = model.IdGrupo;
            report.p_IdSubgrupo.Value = model.IdSubGrupo;
            report.p_IdMarca.Value = model.IdMarca;
            report.p_fecha_corte.Value = model.fecha_fin;
            report.p_mostrar_stock_0.Value = model.mostrar_saldos_en_0;
            report.p_mostrar_agrupados.Value = model.mostrar_agrupado;
            report.p_AgruparPorID.Value = model.mostrar_detallado;
            report.p_ConsiderarNoAprobados.Value = model.considerarSinAprobar;
            report.p_InventarioFisico.Value = model.InventarioFisico;
            report.usuario = SessionFixed.IdUsuario;
            report.empresa = SessionFixed.NomEmpresa;
            
            ViewBag.Report = report;
            return View(model);
        }
        [HttpPost]
        public ActionResult INV_003(cl_filtros_inventario_Info model)
        {
            INV_003_Rpt report = new INV_003_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_003");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_IdBodega.Value = model.IdBodega;
            report.p_IdProducto.Value = model.IdProducto ?? 0;
            report.p_IdCategoria.Value = model.IdCategoria;
            report.p_IdLinea.Value = model.IdLinea;
            report.p_IdGrupo.Value = model.IdGrupo;
            report.p_IdSubgrupo.Value = model.IdSubGrupo;
            report.p_fecha_corte.Value = model.fecha_fin;
            report.p_mostrar_stock_0.Value = model.mostrar_saldos_en_0;
            report.p_mostrar_agrupados.Value = model.mostrar_agrupado;
            report.p_IdMarca.Value = model.IdMarca;
            report.p_AgruparPorID.Value = model.mostrar_detallado;
            report.p_ConsiderarNoAprobados.Value = model.considerarSinAprobar;
            report.p_InventarioFisico.Value = model.InventarioFisico;
            cargar_combos(model);

            report.usuario = SessionFixed.IdUsuario;
            report.empresa = SessionFixed.NomEmpresa;

            ViewBag.Report = report;
            return View(model);
        }
        public ActionResult INV_004()
        {

            cl_filtros_inventario_Info model = new cl_filtros_inventario_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdMarca = 0,
                IdProducto = 0
            };

            cargar_combos(model);
            INV_004_Rpt report = new INV_004_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_004");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_IdBodega.Value = model.IdBodega;
            report.p_IdProducto.Value = model.IdProductoPadre == null ? 0 : model.IdProductoPadre;
            report.p_IdMarca.Value = model.IdMarca;
            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();

            ViewBag.Report = report;
            return View(model);
        }
        [HttpPost]
        public ActionResult INV_004(cl_filtros_inventario_Info model)
        {
            INV_004_Rpt report = new INV_004_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_004");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_IdBodega.Value = model.IdBodega;
            report.p_IdProducto.Value = model.IdProductoPadre == null ? 0 : model.IdProductoPadre;
            report.p_IdMarca.Value = model.IdMarca;
            cargar_combos(model);

            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();

            ViewBag.Report = report;
            return View(model);
        }

        private void cargar_combos(cl_filtros_inventario_Info model)
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            int IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal);
            tb_sucursal_Bus bus_sucursal = new tb_sucursal_Bus();
            var lst_sucursal = bus_sucursal.get_list(IdEmpresa, false);
            lst_sucursal.Add(new tb_sucursal_Info
            {
                IdEmpresa = IdEmpresa,
                IdSucursal = 0,
                Su_Descripcion = "TODAS"
            });
            ViewBag.lst_sucursal = lst_sucursal;

            tb_bodega_Bus bus_bodega = new tb_bodega_Bus();
            var lst_bodega = bus_bodega.get_list(IdEmpresa, IdSucursal, false);
            lst_bodega.Add(new tb_bodega_Info
            {
                IdEmpresa = IdEmpresa,
                IdBodega = 0,
                bo_Descripcion = "TODAS"
            });

            ViewBag.lst_bodega = lst_bodega;

            ct_CentroCosto_Bus bus_cc = new ct_CentroCosto_Bus();
            var lst_centro = bus_cc.get_list(IdEmpresa, false, true);
            ViewBag.lst_centro = lst_centro;

            in_movi_inven_tipo_Bus bus_movi = new in_movi_inven_tipo_Bus();
            var lst_movi = bus_movi.get_list(IdEmpresa, "", false);
            lst_movi.Add(new in_movi_inven_tipo_Info
            {
                IdEmpresa = IdEmpresa,
                IdMovi_inven_tipo = 0,
                tm_descripcion = "TODAS"
            });
            ViewBag.lst_movi = lst_movi;


            in_Producto_Bus bus_producto = new in_Producto_Bus();
            var lst_producto = bus_producto.get_list(IdEmpresa, false);
            ViewBag.lst_producto = lst_producto;

            in_categorias_Bus bus_categoria = new in_categorias_Bus();
            var lst_categoria = bus_categoria.get_list(IdEmpresa, false);
            lst_categoria.Add(new in_categorias_Info
            {
                IdEmpresa = model.IdEmpresa,
                IdCategoria = "",
                ca_Categoria = "Todos"
            });
            ViewBag.lst_categoria = lst_categoria;

            in_linea_Bus bus_linea = new in_linea_Bus();
            var lst_linea = bus_linea.get_list(IdEmpresa, model.IdCategoria, false);
            lst_linea.Add(new in_linea_Info
            {
                IdEmpresa = model.IdEmpresa,
                IdLinea = 0,
                nom_linea = "Todos"
            });
            ViewBag.lst_linea = lst_linea;

            in_grupo_Bus bus_grupo = new in_grupo_Bus();
            var lst_grupo = bus_grupo.get_list(IdEmpresa, model.IdCategoria, model.IdLinea, false);
            lst_grupo.Add(new in_grupo_Info
            {
                IdEmpresa = model.IdEmpresa,
                IdGrupo = 0,
                nom_grupo = "Todos"
            });
            ViewBag.lst_grupo = lst_grupo;

            in_subgrupo_Bus bus_subgrupo = new in_subgrupo_Bus();
            var lst_subgrupo = bus_subgrupo.get_list(IdEmpresa, model.IdCategoria, model.IdLinea, model.IdGrupo, false);
            lst_subgrupo.Add(new in_subgrupo_Info
            {
                IdEmpresa = model.IdEmpresa,
                IdSubgrupo = 0,
                nom_subgrupo = "Todos"
            });
            ViewBag.lst_subgrupo = lst_subgrupo;

            in_Marca_Bus bus_marca = new in_Marca_Bus();
            var lst_marca = bus_marca.get_list(IdEmpresa, false);
            lst_marca.Add(new Info.Inventario.in_Marca_Info
            {
                IdMarca = 0,
                Descripcion = "Todas"
            });
            ViewBag.lst_marca = lst_marca;

            Dictionary<string, string> lst_TipoMov = new Dictionary<string, string>();
            lst_TipoMov.Add("", "TODOS");
            lst_TipoMov.Add("+", "INGRESOS");
            lst_TipoMov.Add("-", "EGRESOS");
            ViewBag.lst_TipoMov = lst_TipoMov;

            Dictionary<string, string> lst_estado_apro = new Dictionary<string, string>();
            lst_estado_apro.Add("", "TODOS");
            lst_estado_apro.Add("APRO", "APROBADOS");
            lst_estado_apro.Add("XAPRO", "POR APROBAR");
            ViewBag.lst_estado_apro = lst_estado_apro;
        }

        public ActionResult INV_005(bool mostrar_detallado = false)
        {
            cl_filtros_inventario_Info model = new cl_filtros_inventario_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal),
            };
            cargar_combos(model);
            if (mostrar_detallado)
            {
                INV_005_detalle_Rpt model_detalle = new INV_005_detalle_Rpt();
                model_detalle.p_IdEmpresa.Value = model.IdEmpresa;
                model_detalle.p_IdSucursal.Value = model.IdSucursal;
                model_detalle.p_IdBodega.Value = model.IdBodega;
                model_detalle.p_IdProducto.Value = model.IdProducto ?? 0;
                model_detalle.p_IdUsuario.Value = SessionFixed.IdUsuario;
                model_detalle.p_fecha_ini.Value = model.fecha_ini;
                model_detalle.p_fecha_fin.Value = model.fecha_fin;
                model_detalle.p_mostrar_detallado.Value = model.mostrar_detallado;
                model_detalle.p_no_mostrar_valores_en_0.Value = model.no_mostrar_valores_en_0;

                model_detalle.usuario = SessionFixed.IdUsuario.ToString();
                model_detalle.empresa = SessionFixed.NomEmpresa.ToString();
                ViewBag.report = model_detalle;
            }
            else
            {
                INV_005_resumen_Rpt model_resumen = new INV_005_resumen_Rpt();
                model_resumen.p_IdEmpresa.Value = model.IdEmpresa;
                model_resumen.p_IdSucursal.Value = model.IdSucursal;
                model_resumen.p_IdBodega.Value = model.IdBodega;
                model_resumen.p_IdProducto.Value = model.IdProducto ?? 0;
                model_resumen.p_IdUsuario.Value = SessionFixed.IdUsuario;
                model_resumen.p_fecha_ini.Value = model.fecha_ini;
                model_resumen.p_fecha_fin.Value = model.fecha_fin;
                model_resumen.p_mostrar_detallado.Value = model.mostrar_detallado;
                model_resumen.p_no_mostrar_valores_en_0.Value = model.no_mostrar_valores_en_0;

                model_resumen.usuario = SessionFixed.IdUsuario.ToString();
                model_resumen.empresa = SessionFixed.NomEmpresa.ToString();
                ViewBag.report = model_resumen;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult INV_005(cl_filtros_inventario_Info model)
        {
            if (model.mostrar_detallado)

            {
                INV_005_detalle_Rpt report = new INV_005_detalle_Rpt();
                report.p_IdEmpresa.Value = model.IdEmpresa;
                report.p_IdSucursal.Value = model.IdSucursal;
                report.p_IdBodega.Value = model.IdBodega;
                report.p_IdProducto.Value = model.IdProducto ?? 0;
                report.p_IdUsuario.Value = SessionFixed.IdUsuario;
                report.p_fecha_ini.Value = model.fecha_ini;
                report.p_fecha_fin.Value = model.fecha_fin;
                report.p_mostrar_detallado.Value = model.mostrar_detallado;
                report.p_no_mostrar_valores_en_0.Value = model.no_mostrar_valores_en_0;
                cargar_combos(model);

                report.usuario = SessionFixed.IdUsuario.ToString();
                report.empresa = SessionFixed.NomEmpresa.ToString();
                ViewBag.Report = report;
            }
            else
            {
                INV_005_resumen_Rpt report = new INV_005_resumen_Rpt();
                report.p_IdEmpresa.Value = model.IdEmpresa;
                report.p_IdSucursal.Value = model.IdSucursal;
                report.p_IdBodega.Value = model.IdBodega;
                report.p_IdProducto.Value = model.IdProducto ?? 0;
                report.p_IdUsuario.Value = SessionFixed.IdUsuario;
                report.p_fecha_ini.Value = model.fecha_ini;
                report.p_fecha_fin.Value = model.fecha_fin;
                report.p_mostrar_detallado.Value = model.mostrar_detallado;
                report.p_no_mostrar_valores_en_0.Value = model.no_mostrar_valores_en_0;
                cargar_combos(model);

                report.usuario = SessionFixed.IdUsuario.ToString();
                report.empresa = SessionFixed.NomEmpresa.ToString();
                ViewBag.Report = report;
            }
            return View(model);
        }

        public ActionResult INV_006()
        {
            cl_filtros_inventario_Info model = new cl_filtros_inventario_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal),
                IdProducto = 0,
                IdProductoPadre = 0
            };

            cargar_combos(model);
            if (model.mostrar_detallado)
            {
                INV_006_detalle_Rpt model_detalle = new INV_006_detalle_Rpt();
                model_detalle.p_IdEmpresa.Value = model.IdEmpresa;
                model_detalle.p_IdSucursal.Value = model.IdSucursal;
                model_detalle.p_IdBodega.Value = model.IdBodega;
                model_detalle.P_IdProductoPadre.Value = model.IdProductoPadre == null ? 0 : model.IdProductoPadre;
                model_detalle.p_IdProducto.Value = model.IdProducto ?? 0;
                model_detalle.p_IdUsuario.Value = SessionFixed.IdUsuario;
                model_detalle.p_fecha_ini.Value = model.fecha_ini;
                model_detalle.p_fecha_fin.Value = model.fecha_fin;
                model_detalle.p_mostrar_detallado.Value = model.mostrar_detallado;
                model_detalle.p_no_mostrar_valores_en_0.Value = model.no_mostrar_valores_en_0;
                model_detalle.usuario = SessionFixed.IdUsuario;
                model_detalle.empresa = SessionFixed.NomEmpresa;

                ViewBag.report = model_detalle;
            }
            else
            {
                INV_006_resumen_Rpt model_resumen = new INV_006_resumen_Rpt();
                model_resumen.p_IdEmpresa.Value = model.IdEmpresa;
                model_resumen.p_IdSucursal.Value = model.IdSucursal;
                model_resumen.p_IdBodega.Value = model.IdBodega;
                model_resumen.P_IdProductoPadre.Value = model.IdProductoPadre == null ? 0 : model.IdProductoPadre;
                model_resumen.p_IdProducto.Value = model.IdProducto ?? 0;
                model_resumen.p_IdUsuario.Value = SessionFixed.IdUsuario;
                model_resumen.p_fecha_ini.Value = model.fecha_ini;
                model_resumen.p_fecha_fin.Value = model.fecha_fin;
                model_resumen.p_mostrar_detallado.Value = model.mostrar_detallado;
                model_resumen.p_no_mostrar_valores_en_0.Value = model.no_mostrar_valores_en_0;
                
                model_resumen.usuario = SessionFixed.IdUsuario;
                model_resumen.empresa = SessionFixed.NomEmpresa;

                ViewBag.report = model_resumen;
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult INV_006(cl_filtros_inventario_Info model)
        {
            if (model.mostrar_detallado)
            {
                INV_006_detalle_Rpt report = new INV_006_detalle_Rpt();
                report.p_IdEmpresa.Value = model.IdEmpresa;
                report.p_IdSucursal.Value = model.IdSucursal;
                report.p_IdBodega.Value = model.IdBodega;
                report.P_IdProductoPadre.Value = model.IdProductoPadre == null ? 0 : model.IdProductoPadre;
                report.p_IdProducto.Value = model.IdProducto ?? 0;
                report.p_IdUsuario.Value = SessionFixed.IdUsuario;
                report.p_fecha_ini.Value = model.fecha_ini;
                report.p_fecha_fin.Value = model.fecha_fin;
                report.p_mostrar_detallado.Value = model.mostrar_detallado;
                report.p_no_mostrar_valores_en_0.Value = model.no_mostrar_valores_en_0;
                cargar_combos(model);

                report.usuario = SessionFixed.IdUsuario;
                report.empresa = SessionFixed.NomEmpresa;
                
                    report.RequestParameters = false;
                ViewBag.Report = report;
            }
            else
            {
                INV_006_resumen_Rpt report = new INV_006_resumen_Rpt();
                report.p_IdEmpresa.Value = model.IdEmpresa;
                report.p_IdSucursal.Value = model.IdSucursal;
                report.p_IdBodega.Value = model.IdBodega;
                report.P_IdProductoPadre.Value = model.IdProductoPadre == null ? 0 : model.IdProductoPadre;
                report.p_IdProducto.Value = model.IdProducto ?? 0;
                report.p_IdUsuario.Value = SessionFixed.IdUsuario;
                report.p_fecha_ini.Value = model.fecha_ini;
                report.p_fecha_fin.Value = model.fecha_fin;
                report.p_mostrar_detallado.Value = model.mostrar_detallado;
                report.p_no_mostrar_valores_en_0.Value = model.no_mostrar_valores_en_0;
                cargar_combos(model);

                report.usuario = SessionFixed.IdUsuario;
                report.empresa = SessionFixed.NomEmpresa;
                report.RequestParameters = false;
                ViewBag.Report = report;
            }
            return View(model);
        }

        public ActionResult INV_007(int IdSucursalOrigen = 0, int IdBodegaOrigen = 0, decimal IdTransferencia = 0)
        {
            INV_007_Rpt model = new INV_007_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_007");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                model.LoadLayout(RootReporte);
            }
            #endregion
            model.p_IdEmpresa.Value = Convert.ToInt32(Session["IdEmpresa"]);
            model.p_IdSucursalOrigen.Value = IdSucursalOrigen;
            model.p_IdBodegaOrigen.Value = IdBodegaOrigen;
            model.p_IdTransferencia.Value = IdTransferencia;
            model.usuario = Session["IdUsuario"].ToString();
            model.empresa = Session["nom_empresa"].ToString();
            if (IdTransferencia == 0)
                model.RequestParameters = false;
            return View(model);
        }


        public ActionResult INV_008()
        {

            cl_filtros_inventario_Info model = new cl_filtros_inventario_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal),
                fecha_ini = new DateTime(DateTime.Now.Year, 1, 1),
                fecha_fin = new DateTime(DateTime.Now.Year, 12, 31),
                tipo_movi= "",
                IdBodega = 0,
                IdProducto=0,
                IdCentroCosto=""
            };

            cargar_combos(model);
            INV_008_Rpt report = new INV_008_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_008");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_IdBodega.Value = model.IdBodega;
            report.p_IdProducto.Value = model.IdProducto;
            report.p_IdMovi_Inven_Tipo.Value = model.IdMovi_inven_tipo;
            report.p_IdCentroCosto.Value = model.IdCentroCosto;
            report.p_fecha_ini.Value = model.fecha_ini;
            report.p_fecha_fin.Value = model.fecha_fin;
            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();
            ViewBag.Report = report;
            return View(model);
        }

        [HttpPost]
        public ActionResult INV_008(cl_filtros_inventario_Info model)
        {
            cargar_combos(model);
            INV_008_Rpt report = new INV_008_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_008");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_IdBodega.Value = model.IdBodega;
            report.p_IdProducto.Value = model.IdProducto;
            report.p_IdMovi_Inven_Tipo.Value = model.IdMovi_inven_tipo;
            report.p_IdCentroCosto.Value = (model.IdCentroCosto==null) ? "" : model.IdCentroCosto;
            report.p_fecha_ini.Value = model.fecha_ini;
            report.p_fecha_fin.Value = model.fecha_fin;
            report.p_signo.Value = model.tipo_movi;
            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();
            ViewBag.Report = report;
            return View(model);
        }

        public ActionResult INV_009()
        {

            cl_filtros_inventario_Info model = new cl_filtros_inventario_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdProducto = 0,
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal),
                IdBodega = 0,
                IdCategoria = "",
                IdLinea = 0,
                IdGrupo = 0,
                IdSubGrupo = 0
            };

            cargar_combos(model);
            INV_009_Rpt report = new INV_009_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_009");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_IdUsuario.Value = model.IdUsuario;
            report.p_IdBodega.Value = model.IdBodega;
            report.p_IdProducto.Value = model.IdProducto;
            report.p_IdCategoria.Value = model.IdCategoria;
            report.p_IdLinea.Value = model.IdLinea;
            report.p_IdGrupo.Value = model.IdGrupo;
            report.p_IdSubgrupo.Value = model.IdSubGrupo;
            report.p_mostrarSinMovimiento.Value = model.mostrarSinMovimiento;
            report.p_considerarSinAprobar.Value = model.considerarSinAprobar;
            report.p_fecha_ini.Value = model.fecha_ini;
            report.p_fecha_fin.Value = model.fecha_fin;
            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();

            ViewBag.Report = report;
            return View(model);
        }
        [HttpPost]
        public ActionResult INV_009(cl_filtros_inventario_Info model)
        {
            INV_009_Rpt report = new INV_009_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_009");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_IdProducto.Value = model.IdProducto;
            report.p_IdUsuario.Value = model.IdUsuario;
            report.p_IdBodega.Value = model.IdBodega;
            report.p_IdCategoria.Value = model.IdCategoria;
            report.p_IdLinea.Value = model.IdLinea;
            report.p_IdGrupo.Value = model.IdGrupo;
            report.p_IdSubgrupo.Value = model.IdSubGrupo;
            report.p_mostrarSinMovimiento.Value = model.mostrarSinMovimiento;
            report.p_considerarSinAprobar.Value = model.considerarSinAprobar;
            report.p_fecha_ini.Value = model.fecha_ini;
            report.p_fecha_fin.Value = model.fecha_fin;
            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();
            cargar_combos(model);

            ViewBag.Report = report;
            return View(model);
        }
        public ActionResult INV_010()
        {

            cl_filtros_inventario_Info model = new cl_filtros_inventario_Info {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdCategoria = "",
                fecha_ini = new DateTime(DateTime.Now.Year,1,1),
                fecha_fin = new DateTime(DateTime.Now.Year,12,31)
            };

            cargar_combos(model);
            INV_010_Rpt report = new INV_010_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_010");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdMarca.Value = model.IdMarca;
            report.p_IdUsuario.Value = SessionFixed.IdUsuario;
            report.p_IdProducto.Value = model.IdProductoPadre;
            report.p_IdCategoria.Value = model.IdCategoria;
            report.p_IdLinea.Value = model.IdLinea;
            report.p_IdGrupo.Value = model.IdGrupo;
            report.p_IdSubGrupo.Value = model.IdSubGrupo;
            report.p_fechaIni.Value = model.fecha_ini;
            report.p_fechaFin.Value = model.fecha_fin;
            report.p_mostrarSinMovimiento.Value = model.mostrarSinMovimiento;
            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();
            ViewBag.Report = report;
            return View(model);
        }
        [HttpPost]
        public ActionResult INV_010(cl_filtros_inventario_Info model)
        {
            INV_010_Rpt report = new INV_010_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_010");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdMarca.Value = model.IdMarca;
            report.p_IdUsuario.Value = SessionFixed.IdUsuario;
            report.p_IdProducto.Value = model.IdProductoPadre;
            report.p_IdCategoria.Value = model.IdCategoria;
            report.p_IdLinea.Value = model.IdLinea;
            report.p_IdGrupo.Value = model.IdGrupo;
            report.p_IdSubGrupo.Value = model.IdSubGrupo;
            report.p_fechaIni.Value = model.fecha_ini;
            report.p_fechaFin.Value = model.fecha_fin;
            report.p_mostrarSinMovimiento.Value = model.mostrarSinMovimiento;
            cargar_combos(model);

            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();

            ViewBag.Report = report;
            return View(model);
        }


        public ActionResult INV_011(int IdSucursal = 0, int IdMovi_inven_tipo = 0, decimal IdNumMovi = 0)
        {
            INV_011_Rpt model = new INV_011_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_011");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                model.LoadLayout(RootReporte);
            }
            #endregion
            model.p_IdEmpresa.Value = Convert.ToInt32(Session["IdEmpresa"]);
            model.p_IdSucursal.Value = IdSucursal;
            model.p_IdMovi_inven_tipo.Value = IdMovi_inven_tipo;
            model.p_IdNumMovi.Value = IdNumMovi;
            model.usuario = SessionFixed.IdUsuario.ToString();
            model.empresa = SessionFixed.NomEmpresa.ToString();
            if (IdNumMovi == 0)
                model.RequestParameters = false;
            return View(model);
        }

        public ActionResult INV_012()
        {

            cl_filtros_inventario_Info model = new cl_filtros_inventario_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal),
                tipo_movi = "",
                IdMovi_inven_tipo = 0
                
            };

            cargar_combos(model);
            INV_012_Rpt report = new INV_012_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_012");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_IdBodega.Value = model.IdBodega;
            report.p_IdMovi_inven_tipo.Value = model.IdMovi_inven_tipo;
            report.p_IdNumMovi.Value = model.IdNumMovi;
            report.p_tipo_movi.Value = model.tipo_movi;
            report.p_fecha_ini.Value = model.fecha_ini;
            report.p_fecha_fin.Value = model.fecha_fin;
            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();
            ViewBag.Report = report;
            return View(model);
        }

        [HttpPost]
        public ActionResult INV_012(cl_filtros_inventario_Info model)
        {
            cargar_combos(model);
            INV_012_Rpt report = new INV_012_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_012");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_IdBodega.Value = model.IdBodega;
            report.p_IdMovi_inven_tipo.Value = model.IdMovi_inven_tipo;
            report.p_IdNumMovi.Value = model.IdNumMovi;
            report.p_tipo_movi.Value = model.tipo_movi;
            report.p_fecha_ini.Value = model.fecha_ini;
            report.p_fecha_fin.Value = model.fecha_fin;
            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();
            ViewBag.Report = report;
            return View(model);
        }
        public ActionResult INV_013()
        {
            cl_filtros_inventario_Info model = new cl_filtros_inventario_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdProducto = 0,
            };

            INV_013_Rpt report = new INV_013_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_013");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdProducto.Value = model.IdProductoPadre == null ? 0 : model.IdProductoPadre;

            ViewBag.Report = report;
            return View(model);
        }
        [HttpPost]
        public ActionResult INV_013(cl_filtros_inventario_Info model)
        {
            INV_013_Rpt report = new INV_013_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_013");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdProducto.Value = model.IdProductoPadre == null ? 0 : model.IdProductoPadre;

            ViewBag.Report = report;
            return View(model);
        }

        public ActionResult INV_014(int IdEmpresa = 0, decimal IdConsignacion = 0)
        {
            INV_014_Rpt model = new INV_014_Rpt();
            #region Cargo diseño desde base
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_014");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                model.LoadLayout(RootReporte);
            }
            #endregion
            model.p_IdEmpresa.Value = IdEmpresa;
            model.p_IdConsignacion.Value = IdConsignacion;

            model.usuario = SessionFixed.IdUsuario;
            model.empresa = SessionFixed.NomEmpresa;
            return View(model);
        }


        public ActionResult INV_015()
        {

            cl_filtros_inventario_Info model = new cl_filtros_inventario_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdProducto = 0,
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal),
                IdCategoria = "",
                IdLinea = 0,
                IdGrupo = 0,
                IdSubGrupo = 0
            };

            cargar_combos(model);
            INV_015_Rpt report = new INV_015_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_015");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_IdBodega.Value = model.IdBodega;
            report.p_IdProducto.Value = model.IdProductoPadre == null ? 0 : model.IdProductoPadre;
            report.p_IdCategoria.Value = model.IdCategoria == null ? "" : model.IdCategoria;
            report.p_IdLinea.Value = model.IdLinea;
            report.p_IdGrupo.Value = model.IdGrupo;
            report.p_IdSubgrupo.Value = model.IdSubGrupo;
            report.p_MostrarAgrupado.Value = model.mostrar_agrupado;
            report.p_fecha_ini.Value = model.fecha_ini;
            report.p_fecha_fin.Value = model.fecha_fin;
            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();

            ViewBag.Report = report;
            return View(model);
        }
        [HttpPost]
        public ActionResult INV_015(cl_filtros_inventario_Info model)
        {
            INV_015_Rpt report = new INV_015_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_015");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_IdBodega.Value = model.IdBodega;
            report.p_IdProducto.Value = model.IdProductoPadre == null ? 0 : model.IdProductoPadre;
            report.p_IdCategoria.Value = model.IdCategoria;
            report.p_IdLinea.Value = model.IdLinea;
            report.p_IdGrupo.Value = model.IdGrupo;
            report.p_IdSubgrupo.Value = model.IdSubGrupo;
            report.p_MostrarAgrupado.Value = model.mostrar_agrupado;
            report.p_fecha_ini.Value = model.fecha_ini;
            report.p_fecha_fin.Value = model.fecha_fin;
            cargar_combos(model);

            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();

            ViewBag.Report = report;
            return View(model);
        }


        public ActionResult INV_016()
        {

            cl_filtros_inventario_Info model = new cl_filtros_inventario_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal),
                IdCategoria = "",
                IdLinea = 0,
                IdGrupo = 0,
                IdSubGrupo = 0
            };

            cargar_combos(model);
            INV_016_Rpt report = new INV_016_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_016");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_IdCategoria.Value = model.IdCategoria == null ? "" : model.IdCategoria;
            report.p_IdLinea.Value = model.IdLinea;
            report.p_IdGrupo.Value = model.IdGrupo;
            report.p_IdSubGrupo.Value = model.IdSubGrupo;
            report.p_noMostrarSinVenta.Value = model.no_mostrar_valores_en_0;
            report.p_IdUsuario.Value = model.IdUsuario;
            report.p_fecha_ini.Value = model.fecha_ini;
            report.p_fecha_fin.Value = model.fecha_fin;
            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();

            ViewBag.Report = report;
            return View(model);
        }
        [HttpPost]
        public ActionResult INV_016(cl_filtros_inventario_Info model)
        {
            INV_016_Rpt report = new INV_016_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_016");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_IdCategoria.Value = model.IdCategoria;
            report.p_IdLinea.Value = model.IdLinea;
            report.p_IdGrupo.Value = model.IdGrupo;
            report.p_IdSubGrupo.Value = model.IdSubGrupo;
            report.p_noMostrarSinVenta.Value = model.no_mostrar_valores_en_0;
            report.p_IdUsuario.Value = model.IdUsuario;
            report.p_fecha_ini.Value = model.fecha_ini;
            report.p_fecha_fin.Value = model.fecha_fin;
            cargar_combos(model);

            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();

            ViewBag.Report = report;
            return View(model);
        }

        public ActionResult INV_017(int IdSucursal = 0, int IdMovi_inven_tipo = 0, decimal IdNumMovi = 0)
        {
            INV_017_Rpt model = new INV_017_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_001");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                model.LoadLayout(RootReporte);
            }
            #endregion
            model.p_IdEmpresa.Value = Convert.ToInt32(SessionFixed.IdEmpresa);
            model.p_IdSucursal.Value = IdSucursal;
            model.p_IdMovi_inven_tipo.Value = IdMovi_inven_tipo;
            model.p_IdNumMovi.Value = IdNumMovi;
            model.usuario = Session["IdUsuario"].ToString();
            model.empresa = Session["nom_empresa"].ToString();
            model.RequestParameters = false;
            return View(model);
        }


        public ActionResult INV_018(decimal IdAjuste = 0)
        {
            INV_018_Rpt model = new INV_018_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_018");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                model.LoadLayout(RootReporte);
            }
            #endregion
            model.p_IdEmpresa.Value = Convert.ToInt32(SessionFixed.IdEmpresa);
            model.p_IdAjuste.Value = IdAjuste;
            model.usuario = SessionFixed.IdUsuario;
            model.empresa = SessionFixed.NomEmpresa;
            model.RequestParameters = false;
            return View(model);
        }

        public ActionResult INV_019()
        {

            cl_filtros_inventario_Info model = new cl_filtros_inventario_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal),
                IdBodega = 0,
                IdProducto=0,
                IdEstadoAproba = ""
            };

            INV_019_Rpt report = new INV_019_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_019");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_IdBodega.Value = model.IdBodega;
            report.p_Tipo.Value = model.tipo_movi;
            report.p_fecha_ini.Value = model.fecha_ini;
            report.p_fecha_fin.Value = model.fecha_fin;
            report.p_IdProducto.Value = model.IdProducto;
            report.p_IdEstadoAproba.Value = model.IdEstadoAproba;
            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();
            cargar_combos(model);
            ViewBag.Report = report;
            return View(model);
        }

        [HttpPost]
        public ActionResult INV_019(cl_filtros_inventario_Info model)
        {            
            INV_019_Rpt report = new INV_019_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_019");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_IdBodega.Value = model.IdBodega;
            report.p_Tipo.Value = model.tipo_movi;
            report.p_fecha_ini.Value = model.fecha_ini;
            report.p_fecha_fin.Value = model.fecha_fin;
            report.p_IdProducto.Value = model.IdProducto;
            report.p_IdEstadoAproba.Value = model.IdEstadoAproba;
            report.usuario = SessionFixed.IdUsuario.ToString();
            report.empresa = SessionFixed.NomEmpresa.ToString();
            cargar_combos(model);
            ViewBag.Report = report;
            return View(model);
        }

        public ActionResult INV_020(int IdSucursal = 0, int IdMovi_inven_tipo = 0, decimal IdNumMovi = 0)
        {
            INV_020_Rpt model = new INV_020_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_020");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                model.LoadLayout(RootReporte);
            }
            #endregion
            
            model.p_IdEmpresa.Value = Convert.ToInt32(SessionFixed.IdEmpresa);
            model.p_IdSucursal.Value = IdSucursal;
            model.p_IdMovi_inven_tipo.Value = IdMovi_inven_tipo;
            model.p_IdNumMovi.Value = IdNumMovi;
            model.usuario = SessionFixed.IdUsuario;
            model.empresa = SessionFixed.NomEmpresa;
            if (IdNumMovi == 0)
                model.RequestParameters = false;
                
            return View(model);
        }

        public ActionResult INV_021()
        {

            cl_filtros_inventario_Info model = new cl_filtros_inventario_Info
            {
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal),
                IdBodega = 0
            };

            cargar_combos(model);
            INV_021_Rpt report = new INV_021_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_021");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_IdBodega.Value = model.IdBodega;
            report.p_fecha_corte.Value = model.fecha_fin;
            report.usuario = SessionFixed.IdUsuario;
            report.empresa = SessionFixed.NomEmpresa;

            ViewBag.Report = report;
            return View(model);
        }
        [HttpPost]
        public ActionResult INV_021(cl_filtros_inventario_Info model)
        {
            INV_021_Rpt report = new INV_021_Rpt();
            #region Cargo diseño desde base
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var reporte = bus_rep_x_emp.GetInfo(IdEmpresa, "INV_003");
            if (reporte != null)
            {
                System.IO.File.WriteAllBytes(RootReporte, reporte.ReporteDisenio);
                report.LoadLayout(RootReporte);
            }
            #endregion
            report.p_IdEmpresa.Value = model.IdEmpresa;
            report.p_IdSucursal.Value = model.IdSucursal;
            report.p_IdBodega.Value = model.IdBodega;
            report.p_fecha_corte.Value = model.fecha_fin;
            cargar_combos(model);

            report.usuario = SessionFixed.IdUsuario;
            report.empresa = SessionFixed.NomEmpresa;

            ViewBag.Report = report;
            return View(model);
        }
    }

}