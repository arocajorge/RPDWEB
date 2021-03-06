﻿using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Erp.Info.CuentasPorPagar;
using Core.Erp.Bus.CuentasPorPagar;
using Core.Erp.Bus.General;
using Core.Erp.Info.Contabilidad;
using Core.Erp.Bus.Contabilidad;
using Core.Erp.Info.Helps;
using Core.Erp.Web.Helps;
using DevExpress.Web;
using Core.Erp.Info.General;
using Core.Erp.Bus.Inventario;
using Core.Erp.Info.Inventario;
using Core.Erp.Info.Banco;
using Core.Erp.Bus.Banco;
using Core.Erp.Bus.Presupuesto;
using Core.Erp.Bus.Facturacion;
using Core.Erp.Bus.Compras;
using Core.Erp.Info.Compras;
using Core.Erp.Web.Areas.Contabilidad.Controllers;
using Core.Erp.Info.Facturacion;
using Core.Erp.Info.SeguridadAcceso;
using Core.Erp.Bus.SeguridadAcceso;

namespace Core.Erp.Web.Areas.CuentasPorPagar.Controllers
{
    [SessionTimeout]
    public class DeudasController : Controller
    {
        #region variables
        cp_orden_giro_Bus bus_orden_giro = new cp_orden_giro_Bus();
        cp_proveedor_Bus bus_proveedor = new cp_proveedor_Bus();
        cp_codigo_SRI_x_CtaCble_Bus bus_codigo_sri = new cp_codigo_SRI_x_CtaCble_Bus();
        cp_pagos_sri_Bus bus_forma_paogo = new cp_pagos_sri_Bus();
        cp_pais_sri_Bus bus_pais = new cp_pais_sri_Bus();
        tb_sucursal_Bus bus_sucursal = new tb_sucursal_Bus();
        cp_TipoDocumento_Bus bus_tipo_documento = new cp_TipoDocumento_Bus();
        cp_proveedor_Info info_proveedor = new cp_proveedor_Info();
        cp_proveedor_Bus bus_prov = new cp_proveedor_Bus();
        cp_parametros_Info info_parametro = new cp_parametros_Info();
        cp_parametros_Bus bus_param = new cp_parametros_Bus();
        cp_orden_giro_det_Info_List List_det = new cp_orden_giro_det_Info_List();
        in_Producto_Bus bus_producto = new in_Producto_Bus();
        tb_bodega_Bus bus_bodega = new tb_bodega_Bus();
        cp_orden_giro_det_Bus bus_det = new cp_orden_giro_det_Bus();
        ct_periodo_Bus bus_periodo = new ct_periodo_Bus();
        tb_sis_Documento_Tipo_Talonario_Bus bus_documento = new tb_sis_Documento_Tipo_Talonario_Bus();
        cp_orden_giro_det_ing_x_oc_Bus bus_orden_giro_det_ing_x_oc = new cp_orden_giro_det_ing_x_oc_Bus();
        cp_orden_giro_det_ing_x_os_Bus bus_orden_giro_det_ing_x_os = new cp_orden_giro_det_ing_x_os_Bus();
        cp_orden_giro_det_ing_x_oc_List ListaPorIngresar = new cp_orden_giro_det_ing_x_oc_List();
        cp_orden_giro_det_ing_x_oc_ListaDetalle ListaDetalleOC = new cp_orden_giro_det_ing_x_oc_ListaDetalle();
        cp_orden_giro_det_ing_x_os_List ListaOSPorIngresar = new cp_orden_giro_det_ing_x_os_List();
        cp_orden_giro_det_ing_x_os_ListaDetalle ListaDetalleOS = new cp_orden_giro_det_ing_x_os_ListaDetalle();
        com_ordencompra_local_Bus bus_ordencompra = new com_ordencompra_local_Bus();
        ct_cbtecble_det_List list_ct_cbtecble_det = new ct_cbtecble_det_List();

        ct_cbtecble_det_List_re List_ct_cbtecble_det_List_retencion = new ct_cbtecble_det_List_re();
        cp_retencion_det_lst List_cp_retencion_det = new cp_retencion_det_lst();
        cp_retencion_Bus bus_retencion = new cp_retencion_Bus();
        cp_orden_giro_det_PorIngresar_List List_det_PorIngresar = new cp_orden_giro_det_PorIngresar_List();
        cp_orden_giro_det_PorIngresar_Seleccionadas_List List_det_PorIngresar_Seleccionadas = new cp_orden_giro_det_PorIngresar_Seleccionadas_List();
        cp_codigo_SRI_Bus bus_sri = new cp_codigo_SRI_Bus();
        ct_plancta_Bus bus_plancta = new ct_plancta_Bus();
        fa_PuntoVta_Bus bus_punto_venta = new fa_PuntoVta_Bus();
        cp_ConciliacionAnticipo_Bus bus_conciliacion_anticipo = new cp_ConciliacionAnticipo_Bus();
        cp_conciliacionAnticipo_List Lista_ConciliacionAnticipo = new cp_conciliacionAnticipo_List();
        string MensajeSuccess = "La transacción se ha realizado con éxito";
        string mensaje = string.Empty;
        tb_sis_Documento_Tipo_Talonario_Bus bus_talonario = new tb_sis_Documento_Tipo_Talonario_Bus();
        cp_orden_giro_List Lista_Deuda = new cp_orden_giro_List();
        seg_Menu_x_Empresa_x_Usuario_Bus bus_permisos = new seg_Menu_x_Empresa_x_Usuario_Bus();
        #endregion

        #region Metodos ComboBox bajo demanda
        tb_persona_Bus bus_persona = new tb_persona_Bus();
        public ActionResult CmbProveedor_CXP()
        {
            cp_orden_giro_Info model = new cp_orden_giro_Info();
            return PartialView("_CmbProveedor_CXP", model);
        }
        public List<tb_persona_Info> get_list_bajo_demanda(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            return bus_persona.get_list_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa), cl_enumeradores.eTipoPersona.PROVEE.ToString());
        }
        public tb_persona_Info get_info_bajo_demanda(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_persona.get_info_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa), cl_enumeradores.eTipoPersona.PROVEE.ToString());
        }

        public ActionResult CmbCuenta_Deuda()
        {
            ct_cbtecble_det_Info model = new ct_cbtecble_det_Info();
            return PartialView("_CmbCuenta_Deuda", model);
        }
        public List<ct_plancta_Info> get_list_bajo_demandaPlancta(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            return bus_plancta.get_list_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa), false);
        }
        public ct_plancta_Info get_info_bajo_demandaPlancta(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_plancta.get_info_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa));
        }
        #endregion

        #region Metodos ComboBox bajo demanda flujo
        ba_TipoFlujo_Bus bus_tipo = new ba_TipoFlujo_Bus();
        public ActionResult CmbFlujo_Deudas()
        {
            decimal model = new decimal();
            return PartialView("_CmbFlujo_Deudas", model);
        }
        public List<ba_TipoFlujo_Info> get_list_bajo_demandaFlujo(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            return bus_tipo.get_list_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa), cl_enumeradores.eTipoIngEgr.EGR.ToString());
        }
        public ba_TipoFlujo_Info get_info_bajo_demandaFlujo(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_tipo.get_info_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa));
        }
        #endregion

        #region Metodos ComboBox bajo demanda de producto
        public ActionResult CmbProducto_deudas()
        {
            decimal model = new decimal();
            return PartialView("_CmbProducto_deudas", model);
        }
        public List<in_Producto_Info> get_list_bajo_demanda_producto(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            return bus_producto.get_list_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa), cl_enumeradores.eTipoBusquedaProducto.PORSUCURSAL, cl_enumeradores.eModulo.FAC, Convert.ToInt32(SessionFixed.IdSucursal));
        }
        public in_Producto_Info get_info_bajo_demanda_producto(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_producto.get_info_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa));
        }
        #endregion

        #region MyRegion
        public ActionResult CmbCuenta_OC()
        {
            cp_orden_giro_det_ing_x_oc_Info model = new cp_orden_giro_det_ing_x_oc_Info();
            return PartialView("_CmbCuenta_OC_det", model);
        }
        public List<ct_plancta_Info> get_list_bajo_demanda_cmbCuenta_OC_det(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            return bus_plancta.get_list_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa), false);
        }
        public ct_plancta_Info get_info_bajo_demanda_cmbCuenta_OC_det(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_plancta.get_info_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa));
        }
        #endregion

        #region Facturas por proveedor
        public ActionResult Index()
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion
            #region Permisos
            seg_Menu_x_Empresa_x_Usuario_Info info = bus_permisos.get_list_menu_accion(Convert.ToInt32(SessionFixed.IdEmpresa), SessionFixed.IdUsuario, "CuentasPorPagar", "Deudas", "Index");
            ViewBag.Nuevo = info.Nuevo;
            #endregion

            cl_filtros_Info model = new cl_filtros_Info
            {
                IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSession),
                IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa),
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal),
                fecha_ini = DateTime.Now.Date.AddMonths(-1),
                fecha_fin = DateTime.Now.Date,
                mostrarAnulados=false,
                mostrar_observacion_completa =false
            };
            cargar_combos_consulta();
            var lst = bus_orden_giro.get_lst(model.IdEmpresa, model.IdSucursal, model.fecha_ini, model.fecha_fin, model.mostrarAnulados, model.mostrar_observacion_completa);
            Lista_Deuda.set_list(lst, model.IdTransaccionSession);

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(cl_filtros_Info model)
        {
            #region Permisos
            seg_Menu_x_Empresa_x_Usuario_Info info = bus_permisos.get_list_menu_accion(Convert.ToInt32(SessionFixed.IdEmpresa), SessionFixed.IdUsuario, "CuentasPorPagar", "Deudas", "Index");
            ViewBag.Nuevo = info.Nuevo;
            #endregion
            SessionFixed.IdTransaccionSessionActual = model.IdTransaccionSession.ToString();
            cargar_combos_consulta();
            var lst = bus_orden_giro.get_lst(model.IdEmpresa, model.IdSucursal, model.fecha_ini, model.fecha_fin, model.mostrarAnulados, model.mostrar_observacion_completa);
            Lista_Deuda.set_list(lst, model.IdTransaccionSession);

            return View(model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_deudas(bool Nuevo=false)
        {
            ViewBag.Nuevo = Nuevo;
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            var model = Lista_Deuda.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));

            return PartialView("_GridViewPartial_deudas", model);
        }

        #endregion

        #region Aprobacion de facturas por proveedor
        public ActionResult Index3()
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion

            cp_orden_giro_Info model = new cp_orden_giro_Info
            {
                IdEmpresa = string.IsNullOrEmpty(SessionFixed.IdEmpresa) ? 0 : Convert.ToInt32(SessionFixed.IdEmpresa),
                IdSucursal = string.IsNullOrEmpty(SessionFixed.IdSucursal) ? 0 : Convert.ToInt32(SessionFixed.IdSucursal),
                IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSession)
            };
            model.Agrupar = 0;
            Session["list_facturas_seleccionadas"] = null;
            cargar_combos_consulta_fact_con_saldo();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index3(cl_filtros_Info model)
        {
            cargar_combos_consulta_fact_con_saldo();
            return View(model);
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial_aprobacion_facturas()
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            List<cp_orden_giro_aprobacion_Info> model = new List<cp_orden_giro_aprobacion_Info>();
            model = Session["list_facturas_seleccionadas"] as List<cp_orden_giro_aprobacion_Info>;
            return PartialView("_GridViewPartial_aprobacion_facturas", model);
        }
        public ActionResult GridViewPartial_facturas_con_saldos(string value)
        {
            ViewBag.Agrupar = value;
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            List<cp_orden_giro_Info> model = (List<cp_orden_giro_Info>)Session["list_ordenes_giro"];
            List<cp_orden_giro_Info> lst_ordenada = new List<cp_orden_giro_Info>();

            if (model != null)
            {
                if (value == "1")
                {
                    lst_ordenada = model.OrderBy(q => q.info_proveedor.info_persona.pe_nombreCompleto).ThenBy(q => q.co_fechaOg).ToList();
                }
                else
                {
                    lst_ordenada = model.OrderByDescending(q => q.co_fechaOg).ToList();
                }
            }
            else
            {
                lst_ordenada = new List<cp_orden_giro_Info>();
            }
              
                 
            return PartialView("_GridViewPartial_facturas_con_saldos", lst_ordenada);
        }
        #endregion

        #region AnticipoConciliacion
        public ActionResult GridViewPartial_ConciliacionAnticipo()
        {
            List<cp_conciliacionAnticipo_Info> model = new List<cp_conciliacionAnticipo_Info>();
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            model = Lista_ConciliacionAnticipo.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));

            return PartialView("_GridViewPartial_ConciliacionAnticipo", model);
        }
        #endregion

        #region Funciones cargar combos
        private void cargar_combos(cp_orden_giro_Info model)
        {
            var lst_codigos_sri = bus_codigo_sri.get_list(model.IdEmpresa);
            ViewBag.lst_codigos_sri = lst_codigos_sri;

            var lst_forma_pago = bus_forma_paogo.get_list();
            ViewBag.lst_forma_pago = lst_forma_pago;

            var lst_paises = bus_pais.get_list();
            ViewBag.lst_paises = lst_paises;

            var lst_doc_tipo = bus_tipo_documento.get_list(false);
            ViewBag.lst_doc_tipo = lst_doc_tipo;

            var lst_sucursales = bus_sucursal.GetList(model.IdEmpresa, Convert.ToString(SessionFixed.IdUsuario), false);
            ViewBag.lst_sucursales = lst_sucursales;

            var lst_sucursales_cxp = bus_sucursal.get_list(model.IdEmpresa, false);
            ViewBag.lst_sucursales_cxp = lst_sucursales_cxp;

            var lst_bodega = bus_bodega.get_list(model.IdEmpresa, model.IdSucursal, false);
            ViewBag.lst_bodega = lst_bodega;

            if (model.IdProveedor != 0)
            {
                var list_tipo_doc = bus_tipo_documento.get_list(model.IdEmpresa, model.IdProveedor, model.IdIden_credito.ToString());
                ViewBag.lst_tipo_doc = list_tipo_doc;
            }
            else
            {
                ViewBag.lst_tipo_doc = new List<cp_TipoDocumento_Info>();

            }

            ViewBag.lst_puntoVtaLiq = new List<fa_PuntoVta_Info>();
            var documento = lst_doc_tipo.Where(q => q.CodTipoDocumento == model.IdOrden_giro_Tipo).FirstOrDefault();
            if (documento != null)
            {
                var lst_puntoVtaLiq = bus_punto_venta.get_list_x_tipo_doc(model.IdEmpresa, model.IdSucursal, documento.Codigo);
                ViewBag.lst_puntoVtaLiq = lst_puntoVtaLiq;
            }


            Dictionary<string, string> lst_pagos = new Dictionary<string, string>();
            lst_pagos.Add("LOC", "LOCAL");
            lst_pagos.Add("EXT", "EXTERIOR");
            ViewBag.lst_pagos = lst_pagos;

            var lst_punto_venta = bus_punto_venta.get_list_x_tipo_doc(model.IdEmpresa, model.IdSucursal, "RETEN");
            ViewBag.lst_punto_venta = lst_punto_venta;

        }

        private void cargar_combos_consulta()
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var lst_sucursal = bus_sucursal.GetList(IdEmpresa, Convert.ToString(SessionFixed.IdUsuario), false);
            lst_sucursal.Add(new tb_sucursal_Info
            {
                IdEmpresa = IdEmpresa,
                IdSucursal = 0,
                Su_Descripcion = "TODAS"
            });
            ViewBag.lst_sucursal = lst_sucursal;
        }

        private void cargar_combos_consulta_fact_con_saldo()
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            var lst_sucursal = bus_sucursal.GetList(IdEmpresa, Convert.ToString(SessionFixed.IdUsuario), false);
            ViewBag.lst_sucursal = lst_sucursal;
        }

        private bool validar(cp_orden_giro_Info i_validar, ref string msg)
        {
            if (!bus_periodo.ValidarFechaTransaccion(i_validar.IdEmpresa, i_validar.co_FechaContabilizacion ?? DateTime.Now.Date, cl_enumeradores.eModulo.CXP, i_validar.IdSucursal, ref msg))
            {
                return false;
            }
            if (!bus_periodo.ValidarFechaTransaccion(i_validar.IdEmpresa, i_validar.co_FechaContabilizacion ?? DateTime.Now.Date, cl_enumeradores.eModulo.CONTA, i_validar.IdSucursal, ref msg))
            {
                return false;
            }
            return true;
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
            #region Permisos
            seg_Menu_x_Empresa_x_Usuario_Info info = bus_permisos.get_list_menu_accion(Convert.ToInt32(SessionFixed.IdEmpresa), SessionFixed.IdUsuario, "CuentasPorPagar", "Deudas", "Index");
            if (!info.Nuevo)
                return RedirectToAction("Index");
            #endregion

            tb_sis_Documento_Tipo_Talonario_Info info_documento = new tb_sis_Documento_Tipo_Talonario_Info();
            var sucursal = bus_sucursal.get_info(IdEmpresa, Convert.ToInt32(SessionFixed.IdSucursal));

            cp_orden_giro_Info model = new cp_orden_giro_Info
            {
                IdEmpresa = IdEmpresa,
                IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSession),
                co_FechaFactura = DateTime.Now.Date,
                co_FechaContabilizacion = DateTime.Now.Date,
                co_FechaFactura_vct = DateTime.Now.Date,
                FechaRetencion = DateTime.Now.Date,
                PaisPago = "593",
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal),
                IdTipoServicio = cl_enumeradores.eTipoServicioCXP.SERVI.ToString(),
                info_retencion = new cp_retencion_Info()
            };

            model.info_retencion = new cp_retencion_Info();
            if (model.info_retencion.IdRetencion == 0)
            {
                model.TieneRetencion = 0;
            }
            else
            {
                model.TieneRetencion = 1;
            }

            List_cp_retencion_det.set_list(new List<cp_retencion_det_Info>(), model.IdTransaccionSession);
            List_ct_cbtecble_det_List_retencion.set_list(new List<ct_cbtecble_det_Info>(), model.IdTransaccionSession);

            list_ct_cbtecble_det.set_list(new List<ct_cbtecble_det_Info>(), model.IdTransaccionSession);
            List_det.set_list(new List<cp_orden_giro_det_Info>(), model.IdTransaccionSession);

            ListaDetalleOC.set_list(new List<cp_orden_giro_det_ing_x_oc_Info>(), model.IdTransaccionSession);
            ListaDetalleOS.set_list(new List<cp_orden_giro_det_ing_x_os_Info>(), model.IdTransaccionSession);

            cargar_combos(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Nuevo(cp_orden_giro_Info model)
        {
            info_proveedor = bus_prov.get_info(model.IdEmpresa, model.IdProveedor);
            info_parametro = bus_param.get_info(model.IdEmpresa);

            if (bus_orden_giro.si_existe(model))
            {
                ViewBag.mensaje = "El documento " + model.co_serie + " " + model.co_factura + ", ya se encuentra registrado";
                cargar_combos(model);

                return View(model);
            }

            if (info_parametro == null)
            {
                ViewBag.mensaje = "Falta parametrizar el módulo de cuentas por pagar";
                cargar_combos(model);

                return View(model);
            }
            model.info_comrobante = new ct_cbtecble_Info();
            model.info_comrobante.IdTipoCbte = (int)info_parametro.pa_TipoCbte_OG;

            var ct_ret = List_ct_cbtecble_det_List_retencion.get_list(model.IdTransaccionSession);
            var ct_factura = list_ct_cbtecble_det.get_list(model.IdTransaccionSession);

            model.info_retencion.detalle = List_cp_retencion_det.get_list(model.IdTransaccionSession);
            model.info_retencion.info_comprobante.lst_ct_cbtecble_det = List_ct_cbtecble_det_List_retencion.get_list(model.IdTransaccionSession);
            model.info_comrobante.lst_ct_cbtecble_det = list_ct_cbtecble_det.get_list(model.IdTransaccionSession);

            if (model.info_retencion.detalle.Count() > 0)
            {
                model.info_retencion.detalle.ForEach(item =>
                {
                    cp_codigo_SRI_Info info_ = bus_sri.get_info(model.IdEmpresa, item.IdCodigo_SRI);
                    item.re_Codigo_impuesto = info_.codigoSRI;
                    if (info_.IdTipoSRI == "COD_RET_IVA")
                    {
                        item.re_tipoRet = "IVA";
                    }
                    if (info_.IdTipoSRI == "COD_RET_FUE")
                    {
                        item.re_tipoRet = "RTF";
                    }
                });
            }

            if (list_ct_cbtecble_det.get_list(model.IdTransaccionSession).Count() == 0)
            {
                ViewBag.mensaje = "Falta diario contable";
                cargar_combos(model);

                return View(model);

            }
            model.lst_det = List_det.get_list(model.IdTransaccionSession);
            model.lst_det_oc = ListaDetalleOC.get_list(model.IdTransaccionSession);
            model.lst_det_os = ListaDetalleOS.get_list(model.IdTransaccionSession);
            if (info_proveedor.info_persona.pe_cedulaRuc != SessionFixed.Ruc)
                model.IdSucursal_cxp = null;
            string mensaje = bus_orden_giro.validar(model);
            if (mensaje != "")
            {
                cargar_combos(model);
                ViewBag.mensaje = mensaje;
                ViewBag.MostrarBoton = true;
                return View(model);
            }

            model.IdUsuario = SessionFixed.IdUsuario;
            if (!validar(model, ref mensaje))
            {
                SessionFixed.IdTransaccionSessionActual = model.IdTransaccionSession.ToString();
                ViewBag.MostrarBoton = true;
                cargar_combos(model);
                ViewBag.mensaje = mensaje;
                return View(model);
            }

            if (!bus_orden_giro.guardarDB(model))
            {
                SessionFixed.IdTransaccionSessionActual = model.IdTransaccionSession.ToString();
                ViewBag.MostrarBoton = true;
                cargar_combos(model);
                return View(model);
            }

            return RedirectToAction("Consultar", new { IdEmpresa = model.IdEmpresa, IdTipoCbte_Ogiro = model.IdTipoCbte_Ogiro, IdCbteCble_Ogiro = model.IdCbteCble_Ogiro, Exito = true });

        }

        public ActionResult Consultar(int IdEmpresa = 0, int IdTipoCbte_Ogiro = 0, decimal IdCbteCble_Ogiro = 0, bool Exito = false)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion

            cp_orden_giro_Info model = bus_orden_giro.get_info(IdEmpresa, IdTipoCbte_Ogiro, IdCbteCble_Ogiro);
            model.IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSession);
            if (model == null)
                return RedirectToAction("Index");

            #region Permisos
            seg_Menu_x_Empresa_x_Usuario_Info info = bus_permisos.get_list_menu_accion(Convert.ToInt32(SessionFixed.IdEmpresa), SessionFixed.IdUsuario, "CuentasPorPagar", "Deudas", "Index");
            if (model.Estado == "I")
            {
                info.Modificar = false;
                info.Anular = false;
            }
            model.Nuevo = (info.Nuevo == true ? 1 : 0);
            model.Modificar = (info.Modificar == true ? 1 : 0);
            model.Anular = (info.Anular == true ? 1 : 0);
            #endregion

            if (model.info_comrobante.lst_ct_cbtecble_det == null)
                model.info_comrobante.lst_ct_cbtecble_det = new List<ct_cbtecble_det_Info>();

            list_ct_cbtecble_det.set_list(model.info_comrobante.lst_ct_cbtecble_det, model.IdTransaccionSession);
            List_cp_retencion_det.set_list(model.info_retencion.detalle, model.IdTransaccionSession);
            List_det.set_list(bus_det.get_list(model.IdEmpresa, model.IdTipoCbte_Ogiro, model.IdCbteCble_Ogiro), model.IdTransaccionSession);

            model.info_retencion = bus_retencion.get_info(model.IdEmpresa, model.IdCbteCble_Ogiro, model.IdTipoCbte_Ogiro);
            model.info_retencion = bus_retencion.get_info(model.info_retencion.IdEmpresa, model.info_retencion.IdRetencion);

            model.lst_det_oc = bus_orden_giro_det_ing_x_oc.get_list(model.IdEmpresa, model.IdCbteCble_Ogiro, model.IdTipoCbte_Ogiro);
            model.lst_det_os = bus_orden_giro_det_ing_x_os.get_list(model.IdEmpresa, model.IdCbteCble_Ogiro, model.IdTipoCbte_Ogiro);

            if (model.info_retencion.IdRetencion == 0)
            {
                model.TieneRetencion = 0;
                model.FechaRetencion = Convert.ToDateTime(model.co_FechaContabilizacion);
            }
            else
            {
                model.TieneRetencion = 1;
                model.FechaRetencion = model.info_retencion.fecha;
            }

            if (model.IdPuntoVta != null)
            {
                model.EsDocumentoElectronico = 1;
            }
            else
                model.EsDocumentoElectronico = 0;

            List_ct_cbtecble_det_List_retencion.set_list(model.info_retencion.info_comprobante.lst_ct_cbtecble_det, model.IdTransaccionSession);
            List_cp_retencion_det.set_list(model.info_retencion.detalle, model.IdTransaccionSession);

            ListaDetalleOC.set_list(model.lst_det_oc, model.IdTransaccionSession);
            ListaDetalleOS.set_list(model.lst_det_os, model.IdTransaccionSession);

            cargar_combos(model);

            if (Exito)
                ViewBag.MensajeSuccess = MensajeSuccess;

            #region Validacion Periodo
            ViewBag.MostrarBoton = true;
            if (!bus_periodo.ValidarFechaTransaccion(IdEmpresa, model.co_FechaFactura, cl_enumeradores.eModulo.CXP, model.IdSucursal, ref mensaje))
            {
                ViewBag.mensaje = mensaje;
                ViewBag.MostrarBoton = false;
            }
            #endregion

            #region ValidacionMicroEmpresa
            var prov = bus_proveedor.get_info(model.IdEmpresa, model.IdProveedor);
            if (prov != null)
            {
                model.EsMicroEmpresa = prov.EsMicroEmpresa;
            }
            #endregion

            return View(model);
        }

        public ActionResult Modificar(int IdEmpresa = 0, int IdTipoCbte_Ogiro = 0, decimal IdCbteCble_Ogiro = 0)
        {
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            #endregion
            #region Permisos
            seg_Menu_x_Empresa_x_Usuario_Info info = bus_permisos.get_list_menu_accion(Convert.ToInt32(SessionFixed.IdEmpresa), SessionFixed.IdUsuario, "CuentasPorPagar", "Deudas", "Index");
            if (!info.Modificar)
                return RedirectToAction("Index");
            #endregion

            cp_orden_giro_Info model = bus_orden_giro.get_info(IdEmpresa, IdTipoCbte_Ogiro, IdCbteCble_Ogiro);
            model.IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSession);
            if (model == null)
                return RedirectToAction("Index");

            if (model.info_comrobante.lst_ct_cbtecble_det == null)
                model.info_comrobante.lst_ct_cbtecble_det = new List<ct_cbtecble_det_Info>();

            list_ct_cbtecble_det.set_list(model.info_comrobante.lst_ct_cbtecble_det, model.IdTransaccionSession);
            List_cp_retencion_det.set_list(model.info_retencion.detalle, model.IdTransaccionSession);
            List_det.set_list(bus_det.get_list(model.IdEmpresa, model.IdTipoCbte_Ogiro, model.IdCbteCble_Ogiro), model.IdTransaccionSession);

            model.info_retencion = bus_retencion.get_info(model.IdEmpresa, model.IdCbteCble_Ogiro, model.IdTipoCbte_Ogiro);
            model.info_retencion = bus_retencion.get_info(model.info_retencion.IdEmpresa, model.info_retencion.IdRetencion);

            model.lst_det_oc = bus_orden_giro_det_ing_x_oc.get_list(model.IdEmpresa, model.IdCbteCble_Ogiro, model.IdTipoCbte_Ogiro);
            model.lst_det_os = bus_orden_giro_det_ing_x_os.get_list(model.IdEmpresa, model.IdCbteCble_Ogiro, model.IdTipoCbte_Ogiro);

            if (model.info_retencion.IdRetencion == 0)
            {
                model.TieneRetencion = 0;
                model.FechaRetencion = Convert.ToDateTime(model.co_FechaContabilizacion);
            }
            else
            {
                model.TieneRetencion = 1;
                model.FechaRetencion = model.info_retencion.fecha;
            }

            if (model.IdPuntoVta != null)
            {
                model.EsDocumentoElectronico = 1;
            }else
                model.EsDocumentoElectronico = 0;

            List_ct_cbtecble_det_List_retencion.set_list(model.info_retencion.info_comprobante.lst_ct_cbtecble_det, model.IdTransaccionSession);
            List_cp_retencion_det.set_list(model.info_retencion.detalle, model.IdTransaccionSession);

            ListaDetalleOC.set_list(model.lst_det_oc, model.IdTransaccionSession);
            ListaDetalleOS.set_list(model.lst_det_os, model.IdTransaccionSession);

            cargar_combos(model);

            #region Validacion Periodo
            ViewBag.MostrarBoton = true;
            if (!bus_periodo.ValidarFechaTransaccion(IdEmpresa, model.co_FechaFactura, cl_enumeradores.eModulo.CXP, model.IdSucursal, ref mensaje))
            {
                ViewBag.mensaje = mensaje;
                ViewBag.MostrarBoton = false;
            }
            #endregion
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Modificar(cp_orden_giro_Info model)
        {
            info_proveedor = bus_prov.get_info(model.IdEmpresa, model.IdProveedor);
            info_parametro = bus_param.get_info(model.IdEmpresa);

            if (info_parametro == null)
            {
                ViewBag.mensaje = "Falta parametros del modulo cuenta por pagar";
                cargar_combos(model);
                ViewBag.MostrarBoton = true;
                return View(model);
            }

            model.info_comrobante.IdTipoCbte = (int)info_parametro.pa_TipoCbte_OG;
            model.info_retencion.detalle = List_cp_retencion_det.get_list(model.IdTransaccionSession);
            model.info_retencion.info_comprobante.lst_ct_cbtecble_det = List_ct_cbtecble_det_List_retencion.get_list(model.IdTransaccionSession);
            model.info_comrobante.lst_ct_cbtecble_det = list_ct_cbtecble_det.get_list(model.IdTransaccionSession);

            if (model.info_retencion.detalle.Count() > 0)
            {
                model.info_retencion.detalle.ForEach(item =>
                {
                    cp_codigo_SRI_Info info_ = bus_sri.get_info(model.IdEmpresa, item.IdCodigo_SRI);
                    item.re_Codigo_impuesto = info_.codigoSRI;
                    if (info_.IdTipoSRI == "COD_RET_IVA")
                    {
                        item.re_tipoRet = "IVA";
                    }
                    if (info_.IdTipoSRI == "COD_RET_FUE")
                    {
                        item.re_tipoRet = "RTF";
                    }
                });

            }

            if (model.info_comrobante.lst_ct_cbtecble_det.Count() == 0)
            {
                ViewBag.mensaje = "Falta diario contable";
                cargar_combos(model);
                ViewBag.MostrarBoton = true;

                return View(model);

            }
            if (info_proveedor.info_persona.pe_cedulaRuc != SessionFixed.Ruc)
                model.IdSucursal_cxp = null;

            model.lst_det = List_det.get_list(model.IdTransaccionSession);
            model.lst_det_oc = ListaDetalleOC.get_list(model.IdTransaccionSession);
            model.lst_det_os = ListaDetalleOS.get_list(model.IdTransaccionSession);
            string mensaje = bus_orden_giro.validar(model);
            if (mensaje != "")
            {
                cargar_combos(model);
                ViewBag.mensaje = mensaje;
                ViewBag.MostrarBoton = true;
                
                return View(model);
            }

            model.IdUsuarioUltMod = SessionFixed.IdUsuario;
            model.IdUsuario = SessionFixed.IdUsuario;

            if (!validar(model, ref mensaje))
            {
                SessionFixed.IdTransaccionSessionActual = model.IdTransaccionSession.ToString();
                cargar_combos(model);
                ViewBag.mensaje = mensaje;
                ViewBag.MostrarBoton = true;
                return View(model);
            }
            
            if (bus_orden_giro.ValidarExisteOrdenPAgo(model.IdEmpresa, model.IdTipoCbte_Ogiro, model.IdCbteCble_Ogiro) == true)
            {
               if(!bus_orden_giro.ModificarDBCabecera(model))
                {
                    SessionFixed.IdTransaccionSessionActual = model.IdTransaccionSession.ToString();
                    cargar_combos(model);
                    ViewBag.MostrarBoton = true;
                    return View(model);
                }               
            }
            else
            if (!bus_orden_giro.modificarDB(model))
            {
                SessionFixed.IdTransaccionSessionActual = model.IdTransaccionSession.ToString();
                ViewBag.MostrarBoton = true;
                cargar_combos(model);
                return View(model);
            }

            return RedirectToAction("Consultar", new { IdEmpresa = model.IdEmpresa, IdTipoCbte_Ogiro = model.IdTipoCbte_Ogiro, IdCbteCble_Ogiro = model.IdCbteCble_Ogiro, Exito = true });

        }
        public ActionResult Anular(int IdEmpresa = 0, int IdTipoCbte_Ogiro = 0, decimal IdCbteCble_Ogiro = 0)
        {
            cp_orden_giro_Info model = bus_orden_giro.get_info(IdEmpresa, IdTipoCbte_Ogiro, IdCbteCble_Ogiro);
            #region Validar Session
            if (string.IsNullOrEmpty(SessionFixed.IdTransaccionSession))
                return RedirectToAction("Login", new { Area = "", Controller = "Account" });
            SessionFixed.IdTransaccionSession = (Convert.ToDecimal(SessionFixed.IdTransaccionSession) + 1).ToString();
            SessionFixed.IdTransaccionSessionActual = SessionFixed.IdTransaccionSession;
            model.IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual);
            #endregion
            #region Permisos
            seg_Menu_x_Empresa_x_Usuario_Info info = bus_permisos.get_list_menu_accion(Convert.ToInt32(SessionFixed.IdEmpresa), SessionFixed.IdUsuario, "CuentasPorPagar", "Deudas", "Index");
            if (!info.Anular)
                return RedirectToAction("Index");
            #endregion

            if (model == null)
                return RedirectToAction("Index");
            if (model.info_comrobante.lst_ct_cbtecble_det == null)
                model.info_comrobante.lst_ct_cbtecble_det = new List<ct_cbtecble_det_Info>();

            list_ct_cbtecble_det.set_list(model.info_comrobante.lst_ct_cbtecble_det, model.IdTransaccionSession);
            model.IdTransaccionSession = Convert.ToDecimal(SessionFixed.IdTransaccionSession);
            List_det.set_list(bus_det.get_list(model.IdEmpresa, model.IdTipoCbte_Ogiro, model.IdCbteCble_Ogiro), model.IdTransaccionSession);
            model.info_retencion = bus_retencion.get_info(model.IdEmpresa, model.IdCbteCble_Ogiro, model.IdTipoCbte_Ogiro);
            model.info_retencion = bus_retencion.get_info(model.info_retencion.IdEmpresa, model.info_retencion.IdRetencion);

            if (model.info_retencion.IdRetencion == 0)
            {
                model.TieneRetencion = 0;
                model.FechaRetencion = Convert.ToDateTime(model.co_FechaContabilizacion);
            }
            else
            {
                model.TieneRetencion = 1;
                model.FechaRetencion = model.info_retencion.fecha;
            }

            model.lst_det_oc = bus_orden_giro_det_ing_x_oc.get_list(model.IdEmpresa, model.IdCbteCble_Ogiro, model.IdTipoCbte_Ogiro);
            ListaDetalleOC.set_list(model.lst_det_oc, model.IdTransaccionSession);

            model.lst_det_os = bus_orden_giro_det_ing_x_os.get_list(model.IdEmpresa, model.IdCbteCble_Ogiro, model.IdTipoCbte_Ogiro);
            ListaDetalleOS.set_list(model.lst_det_os, model.IdTransaccionSession);

            List_ct_cbtecble_det_List_retencion.set_list(model.info_retencion.info_comprobante.lst_ct_cbtecble_det, model.IdTransaccionSession);
            List_cp_retencion_det.set_list(model.info_retencion.detalle, model.IdTransaccionSession);

            #region Validacion Periodo
            ViewBag.MostrarBoton = true;
            if (!bus_periodo.ValidarFechaTransaccion(IdEmpresa, model.co_FechaFactura, cl_enumeradores.eModulo.CXP, model.IdSucursal, ref mensaje))
            {
                ViewBag.mensaje = mensaje;
                ViewBag.MostrarBoton = false;
            }
            #endregion

            cargar_combos(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(cp_orden_giro_Info model)
        {
            info_proveedor = bus_prov.get_info(model.IdEmpresa, model.IdProveedor);
            info_parametro = bus_param.get_info(model.IdEmpresa);

            if (info_parametro == null)
            {
                ViewBag.mensaje = "Falta parametros del modulo cuenta por pagar";
                ViewBag.MostrarBoton = true;
                cargar_combos(model);
                return View(model);
            }

            model.info_comrobante = new ct_cbtecble_Info();

            model.info_comrobante.lst_ct_cbtecble_det = list_ct_cbtecble_det.get_list(model.IdTransaccionSession);
            model.info_retencion.detalle = List_cp_retencion_det.get_list(model.IdTransaccionSession);

            string mensaje = bus_orden_giro.validar(model);
            if (mensaje != "")
            {
                cargar_combos(model);
                ViewBag.mensaje = mensaje;
                ViewBag.MostrarBoton = true;
                return View(model);
            }
            if (!validar(model, ref mensaje))
            {
                SessionFixed.IdTransaccionSessionActual = model.IdTransaccionSession.ToString();
                cargar_combos(model);
                ViewBag.mensaje = mensaje;
                ViewBag.MostrarBoton = true;
                return View(model);
            }
            model.IdUsuarioUltAnu = SessionFixed.IdUsuario;
            model.lst_det = List_det.get_list(model.IdTransaccionSession);
            model.lst_det_oc = ListaDetalleOC.get_list(model.IdTransaccionSession);
            model.lst_det_os = ListaDetalleOS.get_list(model.IdTransaccionSession);

            if (!bus_orden_giro.anularDB(model))
            {
                SessionFixed.IdTransaccionSessionActual = model.IdTransaccionSession.ToString();
                ViewBag.MostrarBoton = true;
                cargar_combos(model);
                return View(model);
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region json
        public JsonResult AutorizarSRI(int IdEmpresa, int IdTipoCbte_Ogiro, decimal IdCbteCble_Ogiro)
        {
            string retorno = string.Empty;

            bus_orden_giro.ModificarEstadoAutorizacion(IdEmpresa, IdTipoCbte_Ogiro, IdCbteCble_Ogiro);

            if (bus_retencion.ModificarEstadoAutorizacion(IdEmpresa, IdTipoCbte_Ogiro, IdCbteCble_Ogiro))
                retorno = "Autorización exitosa";
            
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidarCompraSucursales(int IdEmpresa = 0, decimal IdProveedor = 0)
        {
            string retorno = string.Empty;

            if (IdProveedor != 0)
            {
                var prov = bus_proveedor.get_info(IdEmpresa, IdProveedor);
                if (prov != null && prov.info_persona.pe_cedulaRuc == SessionFixed.Ruc)
                    retorno = "S";
            }
            
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetListOrdenesPorPagar(int IdEmpresa = 0, int IdSucursal=0, int Agrupar=0, decimal IdTransaccionSession=0)
        {
            string retorno = string.Empty;
            var lst = new List<cp_orden_giro_Info>();
            var nueva_lista = new List<cp_orden_giro_Info>();
            ViewBag.Agrupar = Agrupar;

            lst = bus_orden_giro.get_lst_orden_giro_x_pagar(IdEmpresa, IdSucursal);
            var lista_seleccionada = List_det_PorIngresar_Seleccionadas.get_list(IdTransaccionSession);
            //            Session["list_ordenes_giro"] = lst;

            var count = 0;
            foreach (var item1 in lst)
            {
                if (lista_seleccionada.Count()>0)
                {
                    count = 0;
                    foreach (var item2 in lista_seleccionada)
                    {
                        if (item1.SecuencialID == item2.SecuencialID)
                        {
                            count++;                            
                        }
                    }

                    if (count==0)
                    {
                        nueva_lista.Add(item1);
                    }
                }
                else
                {
                    nueva_lista = lst;
                }
                
            }

            Session["list_ordenes_giro"] = nueva_lista;
            retorno = "S";

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        public JsonResult get_list_tipo_doc(int IdEmpresa = 0, decimal IdProveedor = 0, string codigoSRI = "")
        {
            var list_tipo_doc = bus_tipo_documento.get_list(IdEmpresa, IdProveedor, codigoSRI);
            if (list_tipo_doc == null)
                list_tipo_doc = new List<cp_TipoDocumento_Info>();
            return Json(list_tipo_doc, JsonRequestBehavior.AllowGet);
        }

        public JsonResult armar_diario(decimal IdProveedor = 0, double co_subtotal_iva = 0, double co_subtotal_siniva = 0, double co_valoriva = 0, double co_total = 0, string observacion = "", decimal IdTransaccionSession = 0, int IdSucursal_cxp = 0)
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            info_proveedor = bus_prov.get_info(IdEmpresa, IdProveedor);
            if (info_proveedor.info_persona.pe_cedulaRuc == SessionFixed.Ruc)
            {
                var sucursal = bus_sucursal.get_info(IdEmpresa, IdSucursal_cxp);
                info_proveedor.IdCtaCble_CXP = sucursal.IdCtaCble_cxp;
            }
            info_parametro = bus_param.get_info(IdEmpresa);

            double Subtotal0 = 0;
            double SubtotalIVA = 0;
            double IVA = 0;
            double Total = 0;
            double Diferencia = 0;

            list_ct_cbtecble_det.set_list(new List<ct_cbtecble_det_Info>(), IdTransaccionSession);
            var lst_det = List_det.get_list(IdTransaccionSession);
            var lst_det_oc = ListaDetalleOC.get_list(IdTransaccionSession);
            string TipoDiario = lst_det_oc.Count > 0 ? "OC" : (lst_det.Count> 0 ? "INV" : "NA");

            if (TipoDiario == "NA")
            {
                Subtotal0 = Math.Round(co_subtotal_siniva, 2, MidpointRounding.AwayFromZero);
                SubtotalIVA = Math.Round(co_subtotal_iva, 2, MidpointRounding.AwayFromZero);
                IVA = Math.Round(co_valoriva, 2, MidpointRounding.AwayFromZero);
                Total = Math.Round(co_total, 2, MidpointRounding.AwayFromZero);
            }
            else if (TipoDiario == "OC")
            {
                Subtotal0 = Math.Round((lst_det_oc.Where(q => q.Por_Iva == 0).ToList().Sum(q => q.do_subtotal)), 2, MidpointRounding.AwayFromZero);
                SubtotalIVA = Math.Round((lst_det_oc.Where(q => q.Por_Iva > 0).ToList().Sum(q => q.do_subtotal)), 2, MidpointRounding.AwayFromZero);
                IVA = Math.Round(lst_det_oc.Sum(q => q.do_iva), 2, MidpointRounding.AwayFromZero);
                Total = Math.Round(lst_det_oc.Sum(q => q.do_total), 2, MidpointRounding.AwayFromZero);                
            }
            else
            {
                Subtotal0 = Math.Round(lst_det.Where(q=>q.PorIva == 0).Sum(q=>q.Subtotal), 2, MidpointRounding.AwayFromZero);
                SubtotalIVA = Math.Round(lst_det.Where(q => q.PorIva > 0).Sum(q => q.Subtotal), 2, MidpointRounding.AwayFromZero);
                IVA = Math.Round(lst_det.Sum(q => q.ValorIva), 2, MidpointRounding.AwayFromZero);
                Total = Math.Round(lst_det.Sum(q => q.Total), 2, MidpointRounding.AwayFromZero);
            }
            Diferencia = Math.Round(Subtotal0 + SubtotalIVA + IVA - Total, 2);
            if (Math.Round(Diferencia, 2) != 0)
                Total += Diferencia;
            Total = Math.Round(Total, 2, MidpointRounding.AwayFromZero);
            #region Armar diario sin inventario

            

            #region Subtotal
            if (TipoDiario == "NA")
            {
                list_ct_cbtecble_det.AddRow(new ct_cbtecble_det_Info
                {
                    IdCtaCble = info_proveedor.IdCtaCble_Gasto,
                    dc_Valor_debe = Math.Round(Subtotal0 + SubtotalIVA, 2),
                    dc_Valor = Math.Round(Subtotal0 + SubtotalIVA, 2),
                    dc_Observacion = observacion
                }, IdTransaccionSession);
            }
            else if(TipoDiario =="OC")
            {
                var lst_g = (from q in lst_det_oc
                             group q by new { q.IdCtaCble } into g
                             select new
                             {
                                 IdCtaCble = g.Key.IdCtaCble,
                                 Valor = g.Sum(q => q.do_subtotal)
                             }).ToList();

                int cont = 1;
                foreach (var item in lst_g)
                {
                    ct_cbtecble_det_Info det = new ct_cbtecble_det_Info
                    {
                        IdCtaCble = item.IdCtaCble,
                        dc_Valor_debe = Math.Round(item.Valor, 2, MidpointRounding.AwayFromZero),
                        dc_Valor = Math.Round(item.Valor, 2, MidpointRounding.AwayFromZero),
                        dc_Observacion = observacion
                    };
                    list_ct_cbtecble_det.AddRow(det, IdTransaccionSession);
                    cont++;
                }
            }
            else
            {
                var lst_g = (from q in lst_det
                             group q by new { q.IdCtaCbleInv } into g
                             select new
                             {
                                 IdCtaCble = g.Key.IdCtaCbleInv,
                                 Valor = g.Sum(q => q.Subtotal)
                             }).ToList();

                int cont = 1;
                foreach (var item in lst_g)
                {
                    ct_cbtecble_det_Info det = new ct_cbtecble_det_Info
                    {
                        IdCtaCble = item.IdCtaCble,
                        dc_Valor_debe = Math.Round(item.Valor, 2,MidpointRounding.AwayFromZero),
                        dc_Valor = Math.Round(item.Valor, 2,MidpointRounding.AwayFromZero),
                        dc_Observacion = observacion
                    };
                    list_ct_cbtecble_det.AddRow(det, IdTransaccionSession);
                    cont++;
                }
            }
            #endregion

            #region I.V.A.
            if (IVA > 0)
            {
                list_ct_cbtecble_det.AddRow(new ct_cbtecble_det_Info
                {
                    IdCtaCble = info_parametro.pa_ctacble_iva,
                    dc_Valor_debe = Math.Round(IVA, 2),
                    dc_Valor = Math.Round(IVA, 2),
                    dc_Observacion = observacion,
                }, IdTransaccionSession);
            }
            #endregion

            #region Proveedor
            list_ct_cbtecble_det.AddRow(new ct_cbtecble_det_Info
            {
                IdCtaCble = info_proveedor.IdCtaCble_CXP,
                dc_Valor_haber = Math.Round(Total, 2, MidpointRounding.AwayFromZero),
                dc_Valor = Math.Round(Total * -1, 2, MidpointRounding.AwayFromZero),
                dc_Observacion = observacion,
            }, IdTransaccionSession);
            #endregion

            #endregion

            return Json(new { Subtotal0 = Subtotal0, SubtotalIVA = SubtotalIVA, IVA = IVA, Total = Total}, JsonRequestBehavior.AllowGet);
        }
        public JsonResult guardar_aprobacion(string Ids)
        {
           
            List<cp_orden_giro_aprobacion_Info> model = new List<cp_orden_giro_aprobacion_Info>();
            model = Session["list_facturas_seleccionadas"] as List<cp_orden_giro_aprobacion_Info>;
            foreach (var item in model)
            {
                bus_orden_giro.Generar_OP_x_orden_giro(new cp_orden_giro_Info
                {
                    IdEmpresa = item.IdEmpresa,
                    IdTipoCbte_Ogiro = item.IdTipoCbte_Ogiro,
                    IdCbteCble_Ogiro = item.IdCbteCble_Ogiro,
                    IdProveedor = item.IdProveedor,
                    co_factura = item.co_factura,
                    co_valorpagar = item.co_valorpagar,
                    nom_tipo_Documento = item.nom_tipo_Documento,
                    IdSucursal = (int)item.IdSucursal,
                    IdUsuario = SessionFixed.IdUsuario,
                    co_observacion = item.co_observacion,
                    
                });
            }
            Session["list_facturas_seleccionadas"] = null;
            return Json("", JsonRequestBehavior.AllowGet);
        }
        public JsonResult seleccionar_aprobacion(string Ids, decimal IdTransaccionSession)
        {
            if (Ids != null)
            {
                string[] array = Ids.Split(',');
                var output = array.GroupBy(q => q).ToList();
                List<cp_orden_giro_Info> model = new List<cp_orden_giro_Info>();
                List<cp_orden_giro_aprobacion_Info> list_facturas_seleccionadas = new List<cp_orden_giro_aprobacion_Info>();
                model = Session["list_ordenes_giro"] as List<cp_orden_giro_Info>;
                list_facturas_seleccionadas = Session["list_facturas_seleccionadas"] as List<cp_orden_giro_aprobacion_Info>;
                if (list_facturas_seleccionadas == null)
                    list_facturas_seleccionadas = new List<cp_orden_giro_aprobacion_Info>();
                foreach (var item in output)
                {
                    if (item.Key != "")
                    {
                        var lista_tmp = model.Where(v => v.SecuencialID == item.Key);
                        if (lista_tmp.Count() == 1 & list_facturas_seleccionadas.Where(v => v.SecuencialID == item.Key).Count() == 0)// agrego si existe y no esta repetida
                        {
                            var info_add = lista_tmp.FirstOrDefault();
                            info_add.co_valorpagar = (double)info_add.Saldo_OG;

                            list_facturas_seleccionadas.Add(new cp_orden_giro_aprobacion_Info{
                                IdEmpresa = info_add.IdEmpresa,
                                IdTipoCbte_Ogiro = info_add.IdTipoCbte_Ogiro,
                                IdCbteCble_Ogiro = info_add.IdCbteCble_Ogiro,
                                co_factura = info_add.co_factura,
                                co_fechaOg = info_add.co_fechaOg,
                                co_FechaFactura_vct = info_add.co_FechaFactura_vct,
                                Tipo_Vcto = info_add.Tipo_Vcto,
                                Saldo_OG = info_add.Saldo_OG,
                                co_valorpagar = info_add.co_valorpagar,
                                IdProveedor = info_add.IdProveedor,
                                SecuencialID = info_add.SecuencialID,
                                nom_tipo_Documento = info_add.nom_tipo_Documento,
                                co_observacion = info_add.co_observacion,
                                info_proveedor = new cp_proveedor_Info{
                                    info_persona = new tb_persona_Info{
                                        pe_nombreCompleto = info_add.info_proveedor.info_persona.pe_nombreCompleto
                                    }
                                },
                                IdSucursal = info_add.IdSucursal
                                ,IdUsuario = SessionFixed.IdUsuario
                            });
                        }
                    }
                }
                Session["list_facturas_seleccionadas"] = list_facturas_seleccionadas;
                List_det_PorIngresar_Seleccionadas.set_list(list_facturas_seleccionadas, IdTransaccionSession);
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetInfo_Producto(int IdEmpresa = 0, decimal IdProducto = 0)
        {
            in_Producto_Bus bus_producto = new in_Producto_Bus();
            var resultado = bus_producto.get_info(IdEmpresa, IdProducto);

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetListIng_Inv_OC_PorIngresar(decimal IdTransaccionSession = 0, int IdEmpresa = 0, int IdSucursal = 0, decimal IdProveedor= 0)
        {
            var lst = bus_orden_giro_det_ing_x_oc.get_list_x_ingresar(IdEmpresa, IdSucursal, IdProveedor);
            ListaPorIngresar.set_list(lst, IdTransaccionSession);

            return Json("", JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetList_OrderServicio_PorIngresar(decimal IdTransaccionSession = 0, int IdEmpresa = 0, int IdSucursal = 0, decimal IdProveedor = 0)
        {
            var lst = bus_orden_giro_det_ing_x_os.get_list_x_ingresar(IdEmpresa, IdSucursal, IdProveedor);
            ListaOSPorIngresar.set_list(lst, IdTransaccionSession);

            return Json("", JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListPuntoVenta(int IdEmpresa = 0, string CodDocumentoTipo = "", int IdSucursal = 0)
        {
            List<fa_PuntoVta_Info> Lista = new List<fa_PuntoVta_Info>();
            var documento = bus_tipo_documento.GetInfo(CodDocumentoTipo);
            if (documento != null)
            {
                Lista = bus_punto_venta.get_list_x_tipo_doc(IdEmpresa, IdSucursal, documento.Codigo);
            }

            return Json(new { Mostrar = Lista.Count > 0 ? 1 : 0, Lista = Lista }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetUltimoDocumento(int IdEmpresa=0, int IdSucursal = 0, int IdPuntoVta = 0, int TieneRetencion= 0)
        {
            tb_sis_Documento_Tipo_Talonario_Info resultado = new tb_sis_Documento_Tipo_Talonario_Info();
            //cp_retencion_Info info_retencion = new cp_retencion_Info();

            var punto_venta = bus_punto_venta.get_info(IdEmpresa, IdSucursal, IdPuntoVta);
            //info_retencion = bus_retencion.get_info(IdEmpresa, IdCbteCble_Ogiro, IdTipoCbte_Ogiro);

            if (punto_venta != null)
            {
                var sucursal = bus_sucursal.get_info(IdEmpresa, IdSucursal);
                if(TieneRetencion == 0)
                {
                    resultado = bus_talonario.GetUltimoNoUsado(IdEmpresa, cl_enumeradores.eTipoDocumento.RETEN.ToString(), sucursal.Su_CodigoEstablecimiento, punto_venta.cod_PuntoVta, punto_venta.EsElectronico, false);
                }                
                //if (info_retencion.IdRetencion == 0)
                //{
                //    resultado = bus_talonario.GetUltimoNoUsado(IdEmpresa, cl_enumeradores.eTipoDocumento.RETEN.ToString(), sucursal.Su_CodigoEstablecimiento, punto_venta.cod_PuntoVta, punto_venta.EsElectronico, false);
                //}                
            }

            if (resultado == null)
                resultado = new tb_sis_Documento_Tipo_Talonario_Info();

            return Json(new { data_puntovta = punto_venta, data_talonario = resultado }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult limpiar_grids(decimal IdTransaccionSession = 0)
        {
            ListaDetalleOC.set_list(new List<cp_orden_giro_det_ing_x_oc_Info>(), IdTransaccionSession);
            ListaDetalleOS.set_list(new List<cp_orden_giro_det_ing_x_os_Info>(), IdTransaccionSession);

            return Json("", JsonRequestBehavior.AllowGet);
        }

        public JsonResult SumarValorItems(string TotalRows)
        {
            double Total = 0;
            if (TotalRows != null && TotalRows!="")
            {
                string[] array = TotalRows.Split(',');
                foreach (var item in array)
                {
                    Total = Math.Round( (Total + Convert.ToDouble(item)) , 2);
                }
            }
            return Json(Total.ToString("n2"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult get_list_ConciliacionAnticipo(int IdEmpresa = 0, int IdSucursal=0, decimal IdProveedor = 0, decimal IdTransaccionSession=0)
        {
            var lst_ConciliacionAnticipo = bus_conciliacion_anticipo.getlist_ConciliacionAnticipo(IdEmpresa, IdSucursal, IdProveedor);
            if (lst_ConciliacionAnticipo == null)
                lst_ConciliacionAnticipo = new List<cp_conciliacionAnticipo_Info>();

            Lista_ConciliacionAnticipo.set_list(lst_ConciliacionAnticipo, IdTransaccionSession);
            return Json(lst_ConciliacionAnticipo, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CargarPuntosDeVenta(int IdSucursal = 0)
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            var resultado = bus_punto_venta.get_list_x_tipo_doc(IdEmpresa, IdSucursal, cl_enumeradores.eTipoDocumento.RETEN.ToString());
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Detalle de inventario
        public ActionResult GridViewPartial_deudas_det()
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            cp_orden_giro_Info model = new cp_orden_giro_Info();
            model.lst_det = List_det.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));         
            return PartialView("_GridViewPartial_deudas_det", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingAddNewDetalle([ModelBinder(typeof(DevExpressEditorsBinder))] cp_orden_giro_det_Info info_det)
        {
            var producto = bus_producto.get_info(Convert.ToInt32(SessionFixed.IdEmpresa), info_det.IdProducto);
            if (producto != null)
            {
                info_det.pr_descripcion = producto.pr_descripcion_combo;
                info_det.IdCtaCbleInv = producto.IdCtaCtble_Inve;
            }

            if (ModelState.IsValid)
                List_det.AddRow(info_det, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            cp_orden_giro_Info model = new cp_orden_giro_Info();
            model.lst_det = List_det.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_deudas_det", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdateDetalle([ModelBinder(typeof(DevExpressEditorsBinder))] cp_orden_giro_det_Info info_det)
        {
            in_producto_x_tb_bodega_Bus bus_prod_x_bodega = new in_producto_x_tb_bodega_Bus();
            var producto = bus_producto.get_info(Convert.ToInt32(SessionFixed.IdEmpresa), info_det.IdProducto);
            if (producto != null)
            {
                info_det.pr_descripcion = producto.pr_descripcion_combo;
                info_det.IdCtaCbleInv = producto.IdCtaCtble_Inve;
            }

            if (ModelState.IsValid)
            {
                List_det.UpdateRow(info_det, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
                in_producto_x_tb_bodega_Info info_prod_x_bodega = new in_producto_x_tb_bodega_Info();
                //info_prod_x_bodega = bus_prod_x_bodega.get_list();
            }
                
            cp_orden_giro_Info model = new cp_orden_giro_Info();
            model.lst_det = List_det.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_deudas_det", model);
        }

        public ActionResult EditingDeleteDetalle(int secuencia)
        {
            List_det.DeleteRow(secuencia, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            cp_orden_giro_Info model = new cp_orden_giro_Info();
            model.lst_det = List_det.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_deudas_det", model);
        }
        #endregion

        #region editar y eliminar detalle lista de aprobacion
        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate_og([ModelBinder(typeof(DevExpressEditorsBinder))] cp_orden_giro_aprobacion_Info info_det)
        {
            List<cp_orden_giro_aprobacion_Info> model = new List<cp_orden_giro_aprobacion_Info>();
            model = Session["list_facturas_seleccionadas"] as List<cp_orden_giro_aprobacion_Info>;
            if (model.Count() > 0)
            {
                cp_orden_giro_aprobacion_Info edited_info = model.Where(m => m.SecuencialID == info_det.SecuencialID).FirstOrDefault();
                info_det.co_serie = "0";
                info_det.IdProveedor = 1;
                edited_info.co_valorpagar = info_det.co_valorpagar;
            }
            
            return PartialView("_GridViewPartial_aprobacion_facturas", model);
        }
        public ActionResult EditingDelete_og(string SecuencialID)
        {
            List<cp_orden_giro_aprobacion_Info> model = new List<cp_orden_giro_aprobacion_Info>();
            model = Session["list_facturas_seleccionadas"] as List<cp_orden_giro_aprobacion_Info>;
            if (model.Count() > 0)
            {
                cp_orden_giro_aprobacion_Info edited_info = model.Where(m => m.SecuencialID == SecuencialID).FirstOrDefault();
                model.Remove(edited_info);
                Session["list_facturas_seleccionadas"] = model;
            }
            return PartialView("_GridViewPartial_aprobacion_facturas", model);
        }

        #endregion

        #region Funciones del detalle IOC
        [ValidateInput(false)]
        public ActionResult GridViewPartial_ing_inv_oc_det()
        {
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            var model = ListaDetalleOC.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            cargar_combos_detalle_oc();
            return PartialView("_GridViewPartial_ing_inv_oc_det", model);
        }
        private void cargar_combos_detalle_oc()
        {
            in_UnidadMedida_Bus bus_unidad = new in_UnidadMedida_Bus();
            var lst_unidad = bus_unidad.get_list(false);
            ViewBag.lst_unidad = lst_unidad;

            tb_sis_Impuesto_Bus bus_impuesto = new tb_sis_Impuesto_Bus();
            var lst_impuestos = bus_impuesto.get_list("IVA", false);
            ViewBag.lst_impuestos = lst_impuestos;
        }

        [HttpPost, ValidateInput(false)]
        public JsonResult EditingAddNew_IOC(string IDs = "", decimal IdTransaccionSession = 0)
        {
            if (IDs != "")
            {
                int IdEmpresaSesion = Convert.ToInt32(SessionFixed.IdEmpresa);
                var lst_x_ingresar = ListaPorIngresar.get_list(IdTransaccionSession);
                string[] array = IDs.Split(',');
                foreach (var item in array)
                {
                    var info_det = lst_x_ingresar.Where(q => q.IdGenerado == item).FirstOrDefault();

                    cp_orden_giro_det_ing_x_oc_Info info_det_inv = new cp_orden_giro_det_ing_x_oc_Info();
                    
                    if (info_det != null)
                    {
                        info_det_inv.IdEmpresa = info_det.IdEmpresa;
                        info_det_inv.inv_IdSucursal = info_det.inv_IdSucursal;
                        info_det_inv.inv_IdMovi_inven_tipo = info_det.inv_IdMovi_inven_tipo;
                        info_det_inv.inv_Secuencia = info_det.inv_Secuencia;
                        info_det_inv.inv_IdNumMovi = info_det.inv_IdNumMovi;
                        info_det_inv.oc_IdSucursal = info_det.oc_IdSucursal;
                        info_det_inv.oc_IdOrdenCompra = info_det.oc_IdOrdenCompra;
                        info_det_inv.oc_Secuencia = info_det.oc_Secuencia;
                        info_det_inv.pr_descripcion = info_det.pr_descripcion;
                        info_det_inv.IdCtaCble_oc = info_det.IdCtaCble_oc;
                        info_det_inv.dm_cantidad = info_det.dm_cantidad;
                        info_det_inv.do_precioCompra = info_det.do_precioCompra;
                        info_det_inv.do_precioFinal = info_det.do_precioFinal;
                        info_det_inv.IdUnidadMedida = info_det.IdUnidadMedida;
                        info_det_inv.IdCod_Impuesto = info_det.IdCod_Impuesto;
                        info_det_inv.NomUnidadMedida = info_det.NomUnidadMedida;
                        info_det_inv.IdProveedor = info_det.IdProveedor;
                        info_det_inv.IdProducto = info_det.IdProducto;
                        info_det_inv.pc_Cuenta = info_det.pc_Cuenta;
                        info_det_inv.do_precioCompra = info_det.do_precioCompra;
                        info_det_inv.IdCtaCble = info_det.IdCtaCble;

                        ListaDetalleOC.AddRow(info_det_inv, IdTransaccionSession);
                    }
                }
            }
            List<cp_orden_giro_det_ing_x_oc_Info> lista = ListaDetalleOC.get_list(IdTransaccionSession);
            var info = lista.FirstOrDefault();
            var info_oc = bus_ordencompra.get_info(info.IdEmpresa, Convert.ToInt32(info.oc_IdSucursal), Convert.ToDecimal(info.oc_IdOrdenCompra));
            if (info_oc == null)
            {
                info_oc = new com_ordencompra_local_Info();
            }
            
            var model = ListaDetalleOC.get_list(IdTransaccionSession);
            return Json(new { model= model, info_oc = info_oc }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate_IOC([ModelBinder(typeof(DevExpressEditorsBinder))] cp_orden_giro_det_ing_x_oc_Info info_det)
        {
            in_producto_x_tb_bodega_Bus bus_prod_x_bodega = new in_producto_x_tb_bodega_Bus();
            in_producto_x_tb_bodega_Info info_prod_x_bodega = new in_producto_x_tb_bodega_Info();
            in_Ing_Egr_Inven_Bus bus_mov_inv = new in_Ing_Egr_Inven_Bus();
            in_Ing_Egr_Inven_Info info_mov_inv = new in_Ing_Egr_Inven_Info();

            if (ModelState.IsValid)
            {
                ListaDetalleOC.UpdateRow(info_det, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));

                cp_orden_giro_det_ing_x_oc_Info edited_info = ListaDetalleOC.get_list( Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual)).Where(m => m.Secuencia == info_det.Secuencia).First();
                info_mov_inv = bus_mov_inv.get_info(edited_info.IdEmpresa, edited_info.inv_IdSucursal, edited_info.inv_IdMovi_inven_tipo, edited_info.inv_IdNumMovi);
                info_prod_x_bodega.IdEmpresa = edited_info.IdEmpresa;
                info_prod_x_bodega.IdSucursal = edited_info.inv_IdSucursal;
                info_prod_x_bodega.IdBodega = Convert.ToInt32(info_mov_inv.IdBodega);
                info_prod_x_bodega.IdProducto = edited_info.IdProducto;
                info_prod_x_bodega.IdCtaCble_Inven = info_det.IdCtaCble;
                bus_prod_x_bodega.modificar_Cta_Inven(info_prod_x_bodega);
            }  
            
            var model = ListaDetalleOC.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));

            return PartialView("_GridViewPartial_ing_inv_oc_det", model);
        }

        public ActionResult EditingDelete_IOC(int Secuencia)
        {
            ListaDetalleOC.DeleteRow(Secuencia, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            List<cp_orden_giro_det_ing_x_oc_Info> model = new List<cp_orden_giro_det_ing_x_oc_Info>();
            model = ListaDetalleOC.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
           
            return PartialView("_GridViewPartial_ing_inv_oc_det", model);
        }
        #endregion

        #region Funciones del detalle IOS
        [ValidateInput(false)]
        public ActionResult GridViewPartial_ing_inv_os_det()
        {
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            var model = ListaDetalleOS.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            cargar_combos_detalle_os();
            return PartialView("_GridViewPartial_ing_inv_os_det", model);
        }
        private void cargar_combos_detalle_os()
        {
            in_UnidadMedida_Bus bus_unidad = new in_UnidadMedida_Bus();
            var lst_unidad = bus_unidad.get_list(false);
            ViewBag.lst_unidad = lst_unidad;

            tb_sis_Impuesto_Bus bus_impuesto = new tb_sis_Impuesto_Bus();
            var lst_impuestos = bus_impuesto.get_list("IVA", false);
            ViewBag.lst_impuestos = lst_impuestos;
        }

        [HttpPost, ValidateInput(false)]
        public JsonResult EditingAddNew_IOS(string IDs = "", decimal IdTransaccionSession = 0)
        {
            if (IDs != "")
            {
                int IdEmpresaSesion = Convert.ToInt32(SessionFixed.IdEmpresa);
                var lst_x_ingresar = ListaOSPorIngresar.get_list(IdTransaccionSession);
                string[] array = IDs.Split(',');
                foreach (var item in array)
                {
                    var info_det = lst_x_ingresar.Where(q => q.IdGeneradoOS == item).FirstOrDefault();

                    cp_orden_giro_det_ing_x_os_Info info_det_inv = new cp_orden_giro_det_ing_x_os_Info();

                    if (info_det != null)
                    {
                        info_det_inv.IdEmpresa = info_det.IdEmpresa;
                        info_det_inv.oc_IdSucursal = info_det.oc_IdSucursal;
                        info_det_inv.oc_IdOrdenCompra = info_det.oc_IdOrdenCompra;
                        info_det_inv.oc_Secuencia = info_det.oc_Secuencia;
                        info_det_inv.pr_descripcion = info_det.pr_descripcion;
                        info_det_inv.dm_cantidad = info_det.dm_cantidad;
                        info_det_inv.do_precioCompra = info_det.do_precioCompra;
                        info_det_inv.do_precioFinal = info_det.do_precioFinal;
                        info_det_inv.IdUnidadMedida = info_det.IdUnidadMedida;
                        info_det_inv.IdCod_Impuesto = info_det.IdCod_Impuesto;
                        info_det_inv.NomUnidadMedida = info_det.NomUnidadMedida;
                        info_det_inv.IdProveedor = info_det.IdProveedor;
                        info_det_inv.IdProducto = info_det.IdProducto;
                        info_det_inv.do_precioCompra = info_det.do_precioCompra;

                        ListaDetalleOS.AddRow(info_det_inv, IdTransaccionSession);
                    }
                }
            }
            List<cp_orden_giro_det_ing_x_os_Info> lista = ListaDetalleOS.get_list(IdTransaccionSession);
            var info = lista.FirstOrDefault();
            var info_os = bus_ordencompra.get_info(info.IdEmpresa, Convert.ToInt32(info.oc_IdSucursal), Convert.ToDecimal(info.oc_IdOrdenCompra));
            if (info_os == null)
            {
                info_os = new com_ordencompra_local_Info();
            }

            var model = ListaDetalleOS.get_list(IdTransaccionSession);
            return Json(new { model = model, info_os = info_os }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate_IOS([ModelBinder(typeof(DevExpressEditorsBinder))] cp_orden_giro_det_ing_x_os_Info info_det)
        {
            ListaDetalleOS.UpdateRow(info_det, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            var model = ListaDetalleOS.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));

            return PartialView("_GridViewPartial_ing_inv_os_det", model);
        }

        public ActionResult EditingDelete_IOS(int Secuencia)
        {
            ListaDetalleOS.DeleteRow(Secuencia, Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            List<cp_orden_giro_det_ing_x_os_Info> model = new List<cp_orden_giro_det_ing_x_os_Info>();
            model = ListaDetalleOS.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));

            return PartialView("_GridViewPartial_ing_inv_os_det", model);
        }
        #endregion

        #region OC por ingresar
        public ActionResult GridViewPartial_ing_inv_oc_x_ingresar()
        {
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            var model = ListaPorIngresar.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_ing_inv_oc_x_ingresar", model);
        }
        #endregion

        #region OS por ingresar
        public ActionResult GridViewPartial_ing_inv_os_x_ingresar()
        {
            SessionFixed.IdTransaccionSessionActual = Request.Params["TransaccionFixed"] != null ? Request.Params["TransaccionFixed"].ToString() : SessionFixed.IdTransaccionSessionActual;
            var model = ListaOSPorIngresar.get_list(Convert.ToDecimal(SessionFixed.IdTransaccionSessionActual));
            return PartialView("_GridViewPartial_ing_inv_os_x_ingresar", model);
        }
        #endregion
    }

    public class cp_orden_giro_det_PorIngresar_List
    {
        string Variable = "cp_orden_giro_det_PorIngresar";
        public List<cp_orden_giro_det_Info> get_list(decimal IdTransaccionSession)
        {
            if (HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] == null)
            {
                List<cp_orden_giro_det_Info> list = new List<cp_orden_giro_det_Info>();

                HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<cp_orden_giro_det_Info>)HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()];
        }

        public void set_list(List<cp_orden_giro_det_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
        }
    }

    public class cp_orden_giro_det_PorIngresar_Seleccionadas_List
    {
        string Variable = "cp_orden_giro_det_PorIngresar_Seleccionadas";
        public List<cp_orden_giro_aprobacion_Info> get_list(decimal IdTransaccionSession)
        {
            if (HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] == null)
            {
                List<cp_orden_giro_aprobacion_Info> list = new List<cp_orden_giro_aprobacion_Info>();

                HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<cp_orden_giro_aprobacion_Info>)HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()];
        }

        public void set_list(List<cp_orden_giro_aprobacion_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
        }
    }

    public class cp_orden_giro_det_Info_List
    {
        in_categorias_Bus bus_categoria = new in_categorias_Bus();
        tb_sis_Impuesto_Bus bus_impuesto = new tb_sis_Impuesto_Bus();
        string Variable = "cp_orden_giro_det_Info";
        public List<cp_orden_giro_det_Info> get_list(decimal IdTransaccionSession)
        {
            if (HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] == null)
            {
                List<cp_orden_giro_det_Info> list = new List<cp_orden_giro_det_Info>();

                HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<cp_orden_giro_det_Info>)HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()];
        }

        public void set_list(List<cp_orden_giro_det_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
        }

        public void AddRow(cp_orden_giro_det_Info info_det, decimal IdTransaccionSession)
        {
            List<cp_orden_giro_det_Info> list = get_list(IdTransaccionSession);
            info_det.Secuencia = list.Count == 0 ? 1 : (list.Max(q => q.Secuencia) + 1);
            info_det.DescuentoUni = info_det.CostoUni * (info_det.PorDescuento / 100);
            info_det.CostoUniFinal = info_det.CostoUni - info_det.DescuentoUni;
            info_det.Subtotal = info_det.Cantidad * info_det.CostoUniFinal;
            var impuesto = bus_impuesto.get_info(info_det.IdCod_Impuesto_Iva);
            if (impuesto != null)
                info_det.PorIva = impuesto.porcentaje;                
            else
                info_det.PorIva = 0;
            info_det.ValorIva = info_det.Subtotal * (info_det.PorIva / 100);
            info_det.Total = info_det.Subtotal + info_det.ValorIva;
            
            list.Add(info_det);
        }

        public void UpdateRow(cp_orden_giro_det_Info info_det, decimal IdTransaccionSession)
        {
            cp_orden_giro_det_Info edited_info = get_list(IdTransaccionSession).Where(m => m.Secuencia == info_det.Secuencia).First();

            edited_info.IdProducto = info_det.IdProducto;
            edited_info.pr_descripcion = info_det.pr_descripcion;
            edited_info.Cantidad = info_det.Cantidad;
            edited_info.CostoUni = info_det.CostoUni;
            edited_info.PorDescuento = info_det.PorDescuento;
            edited_info.IdCod_Impuesto_Iva = info_det.IdCod_Impuesto_Iva;
            edited_info.pr_descripcion = info_det.pr_descripcion;
            edited_info.DescuentoUni = info_det.CostoUni * (info_det.PorDescuento / 100);
            edited_info.CostoUniFinal = info_det.CostoUni - edited_info.DescuentoUni;
            edited_info.Subtotal = info_det.Cantidad * edited_info.CostoUniFinal;
            var impuesto = bus_impuesto.get_info(edited_info.IdCod_Impuesto_Iva);
            if (impuesto != null)
                edited_info.PorIva = impuesto.porcentaje;
            else
                edited_info.PorIva = 0;
            edited_info.ValorIva = edited_info.Subtotal * (edited_info.PorIva / 100);
            edited_info.Total = edited_info.Subtotal + edited_info.ValorIva;
            edited_info.IdCtaCbleInv = info_det.IdCtaCbleInv;
        }

        public void DeleteRow(int secuencia, decimal IdTransaccionSession)
        {
            List<cp_orden_giro_det_Info> list = get_list(IdTransaccionSession);
            list.Remove(list.Where(m => m.Secuencia == secuencia).FirstOrDefault());
        }
    }

    public class cp_orden_giro_det_ing_x_oc_ListaDetalle
    {
        string Variable = "cp_orden_giro_det_ing_x_oc_Info";
        tb_sis_Impuesto_Bus bus_impuesto = new tb_sis_Impuesto_Bus();

        public List<cp_orden_giro_det_ing_x_oc_Info> get_list(decimal IdTransaccionSession)
        {

            if (HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] == null)
            {
                List<cp_orden_giro_det_ing_x_oc_Info> list = new List<cp_orden_giro_det_ing_x_oc_Info>();

                HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<cp_orden_giro_det_ing_x_oc_Info>)HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()];
        }

        public void set_list(List<cp_orden_giro_det_ing_x_oc_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
        }

        public void AddRow(cp_orden_giro_det_ing_x_oc_Info info_det_inv, decimal IdTransaccionSession)
        {
            List<cp_orden_giro_det_ing_x_oc_Info> list = get_list(IdTransaccionSession);

            tb_sis_Impuesto_Info info_impuesto = bus_impuesto.get_info(info_det_inv.IdCod_Impuesto);
           
            info_det_inv.Por_Iva = info_impuesto.porcentaje;        
            info_det_inv.Secuencia = list.Count == 0 ? 1 : list.Max(q => q.Secuencia) + 1;
            info_det_inv.do_descuento = info_det_inv.do_precioCompra * (info_det_inv.do_porc_des/ 100);
            info_det_inv.do_precioFinal = info_det_inv.do_precioCompra - info_det_inv.do_descuento;
            info_det_inv.do_subtotal = info_det_inv.dm_cantidad * info_det_inv.do_precioFinal;
            info_det_inv.do_iva = info_det_inv.do_subtotal * (info_det_inv.Por_Iva/100);
            info_det_inv.do_total = info_det_inv.do_subtotal + info_det_inv.do_iva;

            list.Add(info_det_inv);
        }

        public void UpdateRow(cp_orden_giro_det_ing_x_oc_Info info_det, decimal IdTransaccionSession)
        {
            tb_sis_Impuesto_Info info_impuesto = bus_impuesto.get_info(info_det.IdCod_Impuesto);
            cp_orden_giro_det_ing_x_oc_Info edited_info = get_list(IdTransaccionSession).Where(m => m.Secuencia == info_det.Secuencia).First();
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);

            edited_info.IdCtaCble = info_det.IdCtaCble;

            edited_info.dm_cantidad = info_det.dm_cantidad;
            edited_info.do_porc_des = info_det.do_porc_des;
            edited_info.IdCod_Impuesto = info_det.IdCod_Impuesto;

            edited_info.Por_Iva = info_impuesto.porcentaje;
            edited_info.do_descuento = edited_info.do_precioCompra * (edited_info.do_porc_des / 100);
            edited_info.do_precioFinal = edited_info.do_precioCompra - edited_info.do_descuento;
            edited_info.do_subtotal = edited_info.dm_cantidad * edited_info.do_precioFinal;
            edited_info.do_iva = edited_info.do_subtotal * (edited_info.Por_Iva / 100);
            edited_info.do_total = edited_info.do_subtotal + edited_info.do_iva;

        }

        public void DeleteRow(int Secuencia, decimal IdTransaccionSession)
        {
            List<cp_orden_giro_det_ing_x_oc_Info> list = get_list(IdTransaccionSession);
            list.Remove(list.Where(m => m.Secuencia == Secuencia).FirstOrDefault());
        }
    }

    public class cp_orden_giro_det_ing_x_oc_List
    {
        string Variable = "cp_orden_giro_det_ing_x_oc_x_cruzar_Info";
        public List<cp_orden_giro_det_ing_x_oc_Info> get_list(decimal IdTransaccionSession)
        {

            if (HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] == null)
            {
                List<cp_orden_giro_det_ing_x_oc_Info> list = new List<cp_orden_giro_det_ing_x_oc_Info>();

                HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<cp_orden_giro_det_ing_x_oc_Info>)HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()];
        }

        public void set_list(List<cp_orden_giro_det_ing_x_oc_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
        }
    }

    public class cp_orden_giro_det_ing_x_os_ListaDetalle
    {
        string Variable = "cp_orden_giro_det_ing_x_os_Info";
        tb_sis_Impuesto_Bus bus_impuesto = new tb_sis_Impuesto_Bus();

        public List<cp_orden_giro_det_ing_x_os_Info> get_list(decimal IdTransaccionSession)
        {

            if (HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] == null)
            {
                List<cp_orden_giro_det_ing_x_os_Info> list = new List<cp_orden_giro_det_ing_x_os_Info>();

                HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<cp_orden_giro_det_ing_x_os_Info>)HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()];
        }

        public void set_list(List<cp_orden_giro_det_ing_x_os_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
        }

        public void AddRow(cp_orden_giro_det_ing_x_os_Info info_det_inv, decimal IdTransaccionSession)
        {
            List<cp_orden_giro_det_ing_x_os_Info> list = get_list(IdTransaccionSession);

            tb_sis_Impuesto_Info info_impuesto = bus_impuesto.get_info(info_det_inv.IdCod_Impuesto);

            info_det_inv.Por_Iva = info_impuesto.porcentaje;
            info_det_inv.Secuencia = list.Count == 0 ? 1 : list.Max(q => q.Secuencia) + 1;
            info_det_inv.do_descuento = info_det_inv.do_precioCompra * (info_det_inv.do_porc_des / 100);
            info_det_inv.do_precioFinal = info_det_inv.do_precioCompra - info_det_inv.do_descuento;
            info_det_inv.do_subtotal = info_det_inv.dm_cantidad * info_det_inv.do_precioFinal;
            info_det_inv.do_iva = info_det_inv.do_subtotal * (info_det_inv.Por_Iva / 100);
            info_det_inv.do_total = info_det_inv.do_subtotal + info_det_inv.do_iva;

            list.Add(info_det_inv);
        }

        public void UpdateRow(cp_orden_giro_det_ing_x_os_Info info_det, decimal IdTransaccionSession)
        {
            tb_sis_Impuesto_Info info_impuesto = bus_impuesto.get_info(info_det.IdCod_Impuesto);
            cp_orden_giro_det_ing_x_os_Info edited_info = get_list(IdTransaccionSession).Where(m => m.Secuencia == info_det.Secuencia).First();
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);

            edited_info.dm_cantidad = info_det.dm_cantidad;
            edited_info.do_porc_des = info_det.do_porc_des;
            edited_info.IdCod_Impuesto = info_det.IdCod_Impuesto;

            edited_info.Por_Iva = info_impuesto.porcentaje;
            edited_info.do_descuento = edited_info.do_precioCompra * (edited_info.do_porc_des / 100);
            edited_info.do_precioFinal = edited_info.do_precioCompra - edited_info.do_descuento;
            edited_info.do_subtotal = edited_info.dm_cantidad * edited_info.do_precioFinal;
            edited_info.do_iva = edited_info.do_subtotal * (edited_info.Por_Iva / 100);
            edited_info.do_total = edited_info.do_subtotal + edited_info.do_iva;

        }

        public void DeleteRow(int Secuencia, decimal IdTransaccionSession)
        {
            List<cp_orden_giro_det_ing_x_os_Info> list = get_list(IdTransaccionSession);
            list.Remove(list.Where(m => m.Secuencia == Secuencia).FirstOrDefault());
        }
    }

    public class cp_orden_giro_det_ing_x_os_List
    {
        string Variable = "cp_orden_giro_det_ing_x_os_x_cruzar_Info";
        public List<cp_orden_giro_det_ing_x_os_Info> get_list(decimal IdTransaccionSession)
        {

            if (HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] == null)
            {
                List<cp_orden_giro_det_ing_x_os_Info> list = new List<cp_orden_giro_det_ing_x_os_Info>();

                HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<cp_orden_giro_det_ing_x_os_Info>)HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()];
        }

        public void set_list(List<cp_orden_giro_det_ing_x_os_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
        }
    }

    public class cp_orden_giro_List
    {
        string Variable = "cp_orden_giro_Info";
        public List<cp_orden_giro_Info> get_list(decimal IdTransaccionSession)
        {

            if (HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] == null)
            {
                List<cp_orden_giro_Info> list = new List<cp_orden_giro_Info>();

                HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
            }
            return (List<cp_orden_giro_Info>)HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()];
        }

        public void set_list(List<cp_orden_giro_Info> list, decimal IdTransaccionSession)
        {
            HttpContext.Current.Session[Variable + IdTransaccionSession.ToString()] = list;
        }
    }
}