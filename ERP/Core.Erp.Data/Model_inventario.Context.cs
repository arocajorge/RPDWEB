﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;

    public partial class Entities_inventario : DbContext
    {
        public Entities_inventario()
            : base("name=Entities_inventario")
        {
        }
        public void SetCommandTimeOut(int TimeOut)
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = TimeOut;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<in_CatalogoTipo> in_CatalogoTipo { get; set; }
        public DbSet<in_categorias> in_categorias { get; set; }
        public DbSet<in_devolucion_inven> in_devolucion_inven { get; set; }
        public DbSet<in_devolucion_inven_det> in_devolucion_inven_det { get; set; }
        public DbSet<in_grupo> in_grupo { get; set; }
        public DbSet<in_linea> in_linea { get; set; }
        public DbSet<in_Marca> in_Marca { get; set; }
        public DbSet<in_movi_inven_tipo_x_tb_bodega> in_movi_inven_tipo_x_tb_bodega { get; set; }
        public DbSet<in_presentacion> in_presentacion { get; set; }
        public DbSet<in_Producto_Composicion> in_Producto_Composicion { get; set; }
        public DbSet<in_producto_x_tb_bodega_Costo_Historico> in_producto_x_tb_bodega_Costo_Historico { get; set; }
        public DbSet<in_subgrupo> in_subgrupo { get; set; }
        public DbSet<in_UnidadMedida> in_UnidadMedida { get; set; }
        public DbSet<in_UnidadMedida_Equiv_conversion> in_UnidadMedida_Equiv_conversion { get; set; }
        public DbSet<vwin_devolucion_inven_det> vwin_devolucion_inven_det { get; set; }
        public DbSet<vwin_Ing_Egr_Inven_det_x_devolver> vwin_Ing_Egr_Inven_det_x_devolver { get; set; }
        public DbSet<vwin_Ing_Egr_Inven_por_devolver> vwin_Ing_Egr_Inven_por_devolver { get; set; }
        public DbSet<vwin_producto_hijo_combo> vwin_producto_hijo_combo { get; set; }
        public DbSet<vwin_producto_padre_combo> vwin_producto_padre_combo { get; set; }
        public DbSet<vwin_producto_x_tb_bodega_stock_x_lote> vwin_producto_x_tb_bodega_stock_x_lote { get; set; }
        public DbSet<in_producto_x_tb_bodega> in_producto_x_tb_bodega { get; set; }
        public DbSet<in_Consignacion> in_Consignacion { get; set; }
        public DbSet<in_ConsignacionDet> in_ConsignacionDet { get; set; }
        public DbSet<vwin_Consignacion> vwin_Consignacion { get; set; }
        public DbSet<vwin_ConsignacionDet> vwin_ConsignacionDet { get; set; }
        public DbSet<in_ProductoTipo> in_ProductoTipo { get; set; }
        public DbSet<vwin_Producto_para_composicion> vwin_Producto_para_composicion { get; set; }
        public DbSet<in_Producto_x_fa_NivelDescuento> in_Producto_x_fa_NivelDescuento { get; set; }
        public DbSet<in_Producto> in_Producto { get; set; }
        public DbSet<in_transferencia> in_transferencia { get; set; }
        public DbSet<in_movi_inve_x_ct_cbteCble> in_movi_inve_x_ct_cbteCble { get; set; }
        public DbSet<in_movi_inve_detalle_x_ct_cbtecble_det> in_movi_inve_detalle_x_ct_cbtecble_det { get; set; }
        public DbSet<vwin_transferencia_x_in_movi_inve_agrupada_para_recosteo> vwin_transferencia_x_in_movi_inve_agrupada_para_recosteo { get; set; }
        public DbSet<vwin_producto_x_tb_bodega_Costo_Historico> vwin_producto_x_tb_bodega_Costo_Historico { get; set; }
        public DbSet<vwin_UnidadMedida_Equiv_conversion> vwin_UnidadMedida_Equiv_conversion { get; set; }
        public DbSet<vwin_Ing_Egr_Inven_det_conversion> vwin_Ing_Egr_Inven_det_conversion { get; set; }
        public DbSet<vwin_Producto_Composicion> vwin_Producto_Composicion { get; set; }
        public DbSet<in_Catalogo> in_Catalogo { get; set; }
        public DbSet<in_Ajuste> in_Ajuste { get; set; }
        public DbSet<in_AjusteDet> in_AjusteDet { get; set; }
        public DbSet<vwin_Ajuste> vwin_Ajuste { get; set; }
        public DbSet<in_transferencia_det> in_transferencia_det { get; set; }
        public DbSet<vwin_movi_inve_x_estado_contabilizacion> vwin_movi_inve_x_estado_contabilizacion { get; set; }
        public DbSet<vwin_Transferencias> vwin_Transferencias { get; set; }
        public DbSet<vwin_Ing_Egr_Inven_PorAprobar> vwin_Ing_Egr_Inven_PorAprobar { get; set; }
        public DbSet<vwin_Ing_Egr_Inven_PorDespachar> vwin_Ing_Egr_Inven_PorDespachar { get; set; }
        public DbSet<vwin_Ing_Egr_Inven_PorReversar> vwin_Ing_Egr_Inven_PorReversar { get; set; }
        public DbSet<vwin_Ing_Egr_Inven> vwin_Ing_Egr_Inven { get; set; }
        public DbSet<in_Motivo_Inven> in_Motivo_Inven { get; set; }
        public DbSet<in_movi_inve_detalle> in_movi_inve_detalle { get; set; }
        public DbSet<in_movi_inven_tipo> in_movi_inven_tipo { get; set; }
        public DbSet<in_Ing_Egr_Inven_det> in_Ing_Egr_Inven_det { get; set; }
        public DbSet<vwin_Ing_Egr_Inven_det> vwin_Ing_Egr_Inven_det { get; set; }
        public DbSet<in_Ing_Egr_Inven> in_Ing_Egr_Inven { get; set; }
        public DbSet<in_movi_inve> in_movi_inve { get; set; }
        public DbSet<vwin_Ing_Egr_Inven_PorContabilizar> vwin_Ing_Egr_Inven_PorContabilizar { get; set; }
        public DbSet<vwin_Producto_PorBodega> vwin_Producto_PorBodega { get; set; }
        public DbSet<vwin_Producto_Stock> vwin_Producto_Stock { get; set; }
        public DbSet<vwin_Producto_PorSucursal> vwin_Producto_PorSucursal { get; set; }
        public DbSet<in_parametro> in_parametro { get; set; }
        public DbSet<vwin_producto_x_tb_bodega> vwin_producto_x_tb_bodega { get; set; }
        public DbSet<vwin_Ing_Egr_InvenPorOrdenCompra> vwin_Ing_Egr_InvenPorOrdenCompra { get; set; }
    
        public virtual ObjectResult<string> spin_Producto_validar_anulacion(Nullable<int> idEmpresa, Nullable<decimal> idProducto)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("spin_Producto_validar_anulacion", idEmpresaParameter, idProductoParameter);
        }
    
        public virtual int spSys_Inv_Recosteo_Inventario_x_rango_fechas(Nullable<int> idEmpresa, Nullable<int> idSucursal, Nullable<int> idBodega, Nullable<System.DateTime> fecha_ini, Nullable<System.DateTime> fecha_fin, Nullable<int> cant_Decimales)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            var idBodegaParameter = idBodega.HasValue ?
                new ObjectParameter("IdBodega", idBodega) :
                new ObjectParameter("IdBodega", typeof(int));
    
            var fecha_iniParameter = fecha_ini.HasValue ?
                new ObjectParameter("Fecha_ini", fecha_ini) :
                new ObjectParameter("Fecha_ini", typeof(System.DateTime));
    
            var fecha_finParameter = fecha_fin.HasValue ?
                new ObjectParameter("Fecha_fin", fecha_fin) :
                new ObjectParameter("Fecha_fin", typeof(System.DateTime));
    
            var cant_DecimalesParameter = cant_Decimales.HasValue ?
                new ObjectParameter("cant_Decimales", cant_Decimales) :
                new ObjectParameter("cant_Decimales", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spSys_Inv_Recosteo_Inventario_x_rango_fechas", idEmpresaParameter, idSucursalParameter, idBodegaParameter, fecha_iniParameter, fecha_finParameter, cant_DecimalesParameter);
        }
    
        public virtual int spSys_Inv_Recosteo_Inventario(Nullable<int> idEmpresa, Nullable<int> idSucursal, Nullable<int> idBodega, Nullable<System.DateTime> fecha_ini, Nullable<int> cant_Decimales)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            var idBodegaParameter = idBodega.HasValue ?
                new ObjectParameter("IdBodega", idBodega) :
                new ObjectParameter("IdBodega", typeof(int));
    
            var fecha_iniParameter = fecha_ini.HasValue ?
                new ObjectParameter("Fecha_ini", fecha_ini) :
                new ObjectParameter("Fecha_ini", typeof(System.DateTime));
    
            var cant_DecimalesParameter = cant_Decimales.HasValue ?
                new ObjectParameter("cant_Decimales", cant_Decimales) :
                new ObjectParameter("cant_Decimales", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spSys_Inv_Recosteo_Inventario", idEmpresaParameter, idSucursalParameter, idBodegaParameter, fecha_iniParameter, cant_DecimalesParameter);
        }
    
        public virtual ObjectResult<SPINV_GetStock_Result> SPINV_GetStock(Nullable<int> idEmpresa, Nullable<int> idSucursal, Nullable<int> idBodega, Nullable<System.DateTime> fechaCorte)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            var idBodegaParameter = idBodega.HasValue ?
                new ObjectParameter("IdBodega", idBodega) :
                new ObjectParameter("IdBodega", typeof(int));
    
            var fechaCorteParameter = fechaCorte.HasValue ?
                new ObjectParameter("FechaCorte", fechaCorte) :
                new ObjectParameter("FechaCorte", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SPINV_GetStock_Result>("SPINV_GetStock", idEmpresaParameter, idSucursalParameter, idBodegaParameter, fechaCorteParameter);
        }
    
        public virtual int spINV_aprobacion_ing_egr(Nullable<int> idEmpresa, Nullable<int> idSucursal, Nullable<int> idBodega, Nullable<int> idMovi_inven_tipo, Nullable<decimal> idNumMovi)
        {
            var idEmpresaParameter = idEmpresa.HasValue ?
                new ObjectParameter("IdEmpresa", idEmpresa) :
                new ObjectParameter("IdEmpresa", typeof(int));
    
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            var idBodegaParameter = idBodega.HasValue ?
                new ObjectParameter("IdBodega", idBodega) :
                new ObjectParameter("IdBodega", typeof(int));
    
            var idMovi_inven_tipoParameter = idMovi_inven_tipo.HasValue ?
                new ObjectParameter("IdMovi_inven_tipo", idMovi_inven_tipo) :
                new ObjectParameter("IdMovi_inven_tipo", typeof(int));
    
            var idNumMoviParameter = idNumMovi.HasValue ?
                new ObjectParameter("IdNumMovi", idNumMovi) :
                new ObjectParameter("IdNumMovi", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spINV_aprobacion_ing_egr", idEmpresaParameter, idSucursalParameter, idBodegaParameter, idMovi_inven_tipoParameter, idNumMoviParameter);
        }
    }
}
