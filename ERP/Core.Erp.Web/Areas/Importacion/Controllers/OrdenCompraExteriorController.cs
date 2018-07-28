﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Erp.Info.Importacion;
using Core.Erp.Bus.Importacion;
using Core.Erp.Info.Helps;
using Core.Erp.Web.Helps;
using Core.Erp.Info.CuentasPorPagar;
using DevExpress.Web;
using Core.Erp.Bus.CuentasPorPagar;
using Core.Erp.Info.Contabilidad;
using Core.Erp.Bus.Contabilidad;
using Core.Erp.Bus.General;
using Core.Erp.Info.Inventario;
using Core.Erp.Bus.Inventario;
using DevExpress.Web.Mvc;

namespace Core.Erp.Web.Areas.Importacion.Controllers
{
    
    public class OrdenCompraExteriorController : Controller
    {
        #region variables
        imp_ordencompra_ext_Bus bus_orden = new imp_ordencompra_ext_Bus();
        cp_proveedor_Bus bus_proveedor = new cp_proveedor_Bus();
        ct_plancta_Bus bus_plancta = new ct_plancta_Bus();
        tb_pais_Bus bus_paises = new tb_pais_Bus();
        tb_ciudad_Bus bus_ciudad = new tb_ciudad_Bus();
        imp_ordencompra_ext_det_Info_lst detalle = new imp_ordencompra_ext_det_Info_lst();
        in_Producto_Bus bus_producto = new in_Producto_Bus();
        in_UnidadMedida_Bus bus_unidad_medida = new in_UnidadMedida_Bus();
        imp_ordencompra_ext_det_Bus bus_detalle = new imp_ordencompra_ext_det_Bus();
        imp_catalogo_Bus bus_catalogo = new imp_catalogo_Bus();
        tb_moneda_Bus bus_moneda = new tb_moneda_Bus();
        #endregion

        #region Metodos ComboBox bajo demanda
        public ActionResult CmbProveedor_exterior()
        {
            cp_proveedor_Info model = new cp_proveedor_Info();
            return PartialView("_CmbProveedor_exterior", model);
        }
        public List<cp_proveedor_Info> get_list_bajo_demanda(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            return bus_proveedor.get_list_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa));
        }
        public cp_proveedor_Info get_info_bajo_demanda(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_proveedor.get_info_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa));
        }


        public ActionResult CmbCuenta_cta_contable()
        {
            imp_ordencompra_ext_Info model = new imp_ordencompra_ext_Info();
           
            return PartialView("_CmbCuenta_contable", model);
        }
        public List<ct_plancta_Info> get_list_bajo_demanda_cta(ListEditItemsRequestedByFilterConditionEventArgs args)
       {
            return bus_plancta.get_list_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa), false);
        }
        public ct_plancta_Info get_info_bajo_demanda_cta(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_plancta.get_info_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa));
        }


        public ActionResult CmbProducto_importacion()
        {
            imp_ordencompra_ext_Info model = new imp_ordencompra_ext_Info();
            return PartialView("_CmbProducto_importacion", model);
        }
        public List<in_Producto_Info> get_list_bajo_demanda_productos(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            return bus_producto.get_list_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa), cl_enumeradores.eTipoBusquedaProducto.PORMODULO, cl_enumeradores.eModulo.INV, 0);
        }
        public in_Producto_Info get_info_bajo_demanda_productos(ListEditItemRequestedByValueEventArgs args)
        {
            return bus_producto.get_info_bajo_demanda(args, Convert.ToInt32(SessionFixed.IdEmpresa));
        }
        #endregion

        #region vistas

        public ActionResult Index()
        {
            cl_filtros_Info model = new cl_filtros_Info();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(cl_filtros_Info model)
        {
            return View(model);
        }

       
        public ActionResult GridViewPartial_orden_compra_ext(DateTime? Fecha_ini, DateTime? Fecha_fin, int IdSucursal = 0)
        {
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            ViewBag.Fecha_ini = Fecha_ini == null ? DateTime.Now.Date.AddMonths(-1) : Convert.ToDateTime(Fecha_ini);
            ViewBag.Fecha_fin = Fecha_fin == null ? DateTime.Now.Date : Convert.ToDateTime(Fecha_fin);
            if (IdSucursal == 0)
                IdSucursal = Convert.ToInt32(SessionFixed.IdSucursal);
            ViewBag.IdSucursal = IdSucursal;

            List<imp_ordencompra_ext_Info> model = new List<imp_ordencompra_ext_Info>();
            model = bus_orden.get_list(IdEmpresa, ViewBag.Fecha_ini, ViewBag.Fecha_fin);
            return PartialView("_GridViewPartial_orden_compra_ext", model);
        }
        public ActionResult GridViewPartial_orden_compra_ext_det()
        {
            List<imp_ordencompra_ext_det_Info> model = new List<imp_ordencompra_ext_det_Info>();
            model = Session["imp_ordencompra_ext_det_Info"] as List<imp_ordencompra_ext_det_Info>;
            if (model == null)
                model = new List<imp_ordencompra_ext_det_Info>();
            cargar_combos_detalle();
            return PartialView("_GridViewPartial_orden_compra_ext_det", model);
        }
        
        public ActionResult GridViewPartial_orden_compra_con_saldo()
        {
            List<imp_ordencompra_ext_Info> model = new List<imp_ordencompra_ext_Info>();
            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            model = bus_orden.get_list(IdEmpresa);
            return PartialView("_GridViewPartial_orden_compra_con_saldo", model);
        }

        
         public ActionResult OrdencompraConsaldos()
        {
            cl_filtros_Info model = new cl_filtros_Info();
            return View(model);
        }

        #endregion

        #region acciones
        public ActionResult Nuevo()
        {
           
            imp_ordencompra_ext_Info model = new imp_ordencompra_ext_Info
            {
                fecha_creacion = DateTime.Now,
                oe_fecha = DateTime.Now,
                oe_fecha_llegada = DateTime.Now,
                oe_fecha_embarque = DateTime.Now,
                oe_fecha_desaduanizacion = DateTime.Now,
                IdPais_origen="1",
                IdCiudad_destino="09",
                IdCatalogo_forma_pago=1
                

            };
            cargar_combos_detalle();
            cargar_combos();
            return View(model);
        }
        [HttpPost]
        public ActionResult Nuevo(imp_ordencompra_ext_Info model)
        {
            model.lst_detalle = Session["imp_ordencompra_ext_det_Info"] as List<imp_ordencompra_ext_det_Info>;
            model.IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            string mensaje = bus_orden.validar(model);
            if(mensaje!="")
            {
                cargar_combos();
                ViewBag.mensaje = mensaje;
                return View(model);
            }
            if (!bus_orden.guardarDB(model))
            {
                cargar_combos();
                return View(model);
            }
            Session["imp_ordencompra_ext_det_Info"] = null;
            return RedirectToAction("Index");
        }
        public ActionResult Modificar(decimal IdOrdenCompra_ext)
        {

            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            imp_ordencompra_ext_Info model = bus_orden.get_info(IdEmpresa, IdOrdenCompra_ext);
            var lst_detalle = bus_detalle.get_list(IdEmpresa, IdOrdenCompra_ext);
            Session["imp_ordencompra_ext_det_Info"] = lst_detalle;
            if (model == null)
                return RedirectToAction("Index");
            cargar_combos();
            cargar_combos_detalle();
            return View(model);
        }
        [HttpPost]
        public ActionResult Modificar(imp_ordencompra_ext_Info model)
        {
            model.lst_detalle= Session["imp_ordencompra_ext_det_Info"] as List<imp_ordencompra_ext_det_Info>;
            string mensaje = bus_orden.validar(model);
            if (mensaje != "")
            {
                cargar_combos();
                ViewBag.mensaje = mensaje;
                return View(model);
            }
            if (!bus_orden.modificarDB(model))
            {
                cargar_combos();
                return View(model);
            }
            Session["imp_ordencompra_ext_det_Info"] = null;
            return RedirectToAction("Index");
        }
        public ActionResult Anular(decimal IdOrdenCompra_ext)
        {

            int IdEmpresa = Convert.ToInt32(SessionFixed.IdEmpresa);
            imp_ordencompra_ext_Info model = bus_orden.get_info(IdEmpresa, IdOrdenCompra_ext);
           var lst_detalle = bus_detalle.get_list(IdEmpresa, IdOrdenCompra_ext);
            Session["imp_ordencompra_ext_det_Info"] = lst_detalle;
            if (model == null)
                return RedirectToAction("Index");
            cargar_combos();
            return View(model);
        }

        [HttpPost]
        public ActionResult Anular(imp_ordencompra_ext_Info model)
        {
            if (!bus_orden.anularDB(model))
            {
                cargar_combos();
                return View(model);
            }
            Session["imp_ordencompra_ext_det_Info"] = null;
            return RedirectToAction("Index");
        }
        #endregion

        private void cargar_combos()
        {
            var lst_paises = bus_paises.get_list(false);
            ViewBag.lst_paises = lst_paises;

            var lst_ciudades = bus_ciudad.get_list("09", false);
            ViewBag.lst_ciudades = lst_ciudades;

            var lst_forma_pago = bus_catalogo.get_list(2);
            ViewBag.lst_forma_pago = lst_forma_pago;

            var lst_catalogos = bus_catalogo.get_list(1);
            ViewBag.lst_catalogos = lst_catalogos;

            var lst_monedas = bus_moneda.get_list();
            ViewBag.lst_monedas = lst_monedas;

        }
        private void cargar_combos_detalle()
        {
            var lst_undades = bus_unidad_medida.get_list(false);
            ViewBag.lst_undades = lst_undades;
        }
        #region funciones del detalle
        [HttpPost, ValidateInput(false)]
        public ActionResult EditingAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] imp_ordencompra_ext_det_Info info_det)
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            if (info_det != null)
                if (info_det.IdProducto != 0)
                {
                    in_Producto_Info info_producto = bus_producto.get_info(IdEmpresa, info_det.IdProducto);
                    if (info_producto != null)
                    {
                        info_det.pr_descripcion = info_producto.pr_descripcion;
                        info_det.IdUnidadMedida = info_producto.IdUnidadMedida;
                        info_det.od_total_fob = info_det.od_cantidad * info_det.od_costo;
                        detalle.AddRow(info_det);

                    }
                }

            var model = detalle.get_list();
            cargar_combos_detalle();
            return PartialView("_GridViewPartial_orden_compra_ext_det", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditingUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] imp_ordencompra_ext_det_Info info_det)
        {
            int IdEmpresa = Convert.ToInt32(Session["IdEmpresa"]);
            if (info_det != null)
                if (info_det.IdProducto != 0)
                {
                    in_Producto_Info info_producto = bus_producto.get_info(IdEmpresa, info_det.IdProducto);
                    if (info_producto != null)
                    {
                        info_det.pr_descripcion = info_producto.pr_descripcion;
                        info_det.IdUnidadMedida = info_producto.IdUnidadMedida;
                        info_det.od_total_fob = info_det.od_cantidad * info_det.od_costo;

                    }
                }

            detalle.UpdateRow(info_det);
            var model = detalle.get_list();
            cargar_combos_detalle();
            return PartialView("_GridViewPartial_orden_compra_ext_det", model);
        }

        public ActionResult EditingDelete(int Secuencia)
        {
            detalle.DeleteRow(Secuencia);
            var model = detalle.get_list();
            cargar_combos_detalle();
            return PartialView("_GridViewPartial_orden_compra_ext_det", model);
        }
        #endregion
    }


    public class imp_ordencompra_ext_det_Info_lst
    {
        public List<imp_ordencompra_ext_det_Info> get_list()
        {
            if (HttpContext.Current.Session["imp_ordencompra_ext_det_Info"] == null)
            {
                List<imp_ordencompra_ext_det_Info> list = new List<imp_ordencompra_ext_det_Info>();

                HttpContext.Current.Session["imp_ordencompra_ext_det_Info"] = list;
            }
            return (List<imp_ordencompra_ext_det_Info>)HttpContext.Current.Session["imp_ordencompra_ext_det_Info"];
        }

        public void set_list(List<imp_ordencompra_ext_det_Info> list)
        {
            HttpContext.Current.Session["imp_ordencompra_ext_det_Info"] = list;
        }

        public void AddRow(imp_ordencompra_ext_det_Info info_det)
        {
            List<imp_ordencompra_ext_det_Info> list = get_list();
            info_det.Secuencia = list.Count == 0 ? 1 : list.Max(q => q.Secuencia) + 1;
            info_det.IdProducto = info_det.IdProducto;
            info_det.IdUnidadMedida = info_det.IdUnidadMedida;
            info_det.od_costo = info_det.od_costo;
            info_det.od_cantidad = info_det.od_cantidad;

            list.Add(info_det);
        }

        public void UpdateRow(imp_ordencompra_ext_det_Info info_det)
        {
            imp_ordencompra_ext_det_Info edited_info = get_list().Where(m => m.Secuencia == info_det.Secuencia).First();
            edited_info.IdProducto = info_det.IdProducto;
            edited_info.IdUnidadMedida = info_det.IdUnidadMedida;
            edited_info.od_costo = info_det.od_costo;
            edited_info.od_cantidad = info_det.od_cantidad;

        }

        public void DeleteRow(int Secuencia)
        {
            List<imp_ordencompra_ext_det_Info> list = get_list();
            list.Remove(list.Where(m => m.Secuencia == Secuencia).First());
        }
    }
}