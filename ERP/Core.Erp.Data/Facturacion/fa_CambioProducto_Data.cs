﻿using Core.Erp.Info.Facturacion;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Erp.Data.Facturacion
{
    public class fa_CambioProducto_Data
    {
        public List<fa_CambioProducto_Info> GetList(int IdEmpresa, int IdSucursal, DateTime FechaIni, DateTime FechaFin)
        {
            try
            {
                FechaIni = FechaIni.Date;
                FechaFin = FechaFin.Date;
                int IdSucursalIni = IdSucursal;
                int IdSucursalFin = IdSucursal == 0 ? 99999 : IdSucursal;
                List<fa_CambioProducto_Info> Lista;

                using (Entities_facturacion db = new Entities_facturacion())
                {
                    Lista = db.vwfa_CambioProducto.Where(q => q.IdEmpresa == IdEmpresa
                    && IdSucursalIni <= q.IdSucursal
                    && q.IdSucursal <= IdSucursalFin
                    && FechaIni <= q.Fecha && q.Fecha <= FechaFin).Select(q => new fa_CambioProducto_Info
                    {
                        IdEmpresa = q.IdEmpresa,
                        IdSucursal = q.IdSucursal,
                        IdBodega = q.IdBodega,
                        IdCambio = q.IdCambio,
                        Fecha = q.Fecha,
                        Observacion = q.Observacion,
                        Estado = q.Estado,
                        IdMovi_inven_tipo = q.IdMovi_inven_tipo,
                        IdNumMovi = q.IdNumMovi,

                        bo_Descripcion = q.bo_Descripcion,
                        Su_Descripcion = q.Su_Descripcion,
                    }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal GetId(int IdEmpresa, int IdSucursal, int IdBodega)
        {
            try
            {
                decimal ID = 1;

                using (Entities_facturacion db = new Entities_facturacion())
                {
                    var lst = db.fa_CambioProducto.Where(q => q.IdEmpresa == IdEmpresa && q.IdSucursal == IdSucursal && q.IdBodega == IdBodega).ToList();
                    if (lst.Count > 0)
                        ID = lst.Max(q => q.IdCambio) + 1;
                }

                return ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool GuardarDB(fa_CambioProducto_Info info)
        {
            try
            {
                using (Entities_facturacion db = new Entities_facturacion())
                {
                    db.fa_CambioProducto.Add(new fa_CambioProducto
                    {
                        IdEmpresa = info.IdEmpresa,
                        IdSucursal = info.IdSucursal,
                        IdBodega = info.IdBodega,
                        IdCambio = info.IdCambio = GetId(info.IdEmpresa, info.IdSucursal, info.IdBodega),
                        Fecha = info.Fecha.Date,
                        Observacion = info.Observacion,
                        Estado = true,

                        IdUsuario = info.IdUsuario,
                        FechaTransac = DateTime.Now
                    });
                    int secuencia = 1;
                    foreach (var item in info.LstDet)
                    {
                        db.fa_CambioProductoDet.Add(new fa_CambioProductoDet
                        {
                            IdEmpresa = info.IdEmpresa,                            
                            IdSucursal = info.IdSucursal,
                            IdBodega = info.IdBodega,
                            IdCambio = info.IdCambio,
                            Secuencia = secuencia++,

                            IdCbteVta = item.IdCbteVta,
                            SecuenciaFact = item.SecuenciaFact,
                            IdProductoFact = item.IdProductoFact,
                            IdProductoCambio = item.IdProductoCambio,
                            CantidadCambio = item.CantidadCambio,
                            CantidadFact = item.CantidadFact                            
                        });
                    }

                    db.SaveChanges();


                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ModificarDB(fa_CambioProducto_Info info)
        {
            try
            {
                using (Entities_facturacion db = new Entities_facturacion())
                {
                    var Entity = db.fa_CambioProducto.Where(q => q.IdEmpresa == info.IdEmpresa && q.IdSucursal == info.IdSucursal && q.IdBodega == info.IdBodega && q.IdCambio == info.IdCambio).FirstOrDefault();
                    if (Entity == null) return false;
                    Entity.Fecha = info.Fecha;
                    Entity.Observacion = info.Observacion;

                    Entity.IdUsuarioUltMod = info.IdUsuario;
                    Entity.FechaUltMod = DateTime.Now;

                    var lst = db.fa_CambioProductoDet.Where(q => q.IdEmpresa == info.IdEmpresa && q.IdSucursal == info.IdSucursal && q.IdBodega == info.IdBodega && q.IdCambio == info.IdCambio).ToList();
                    db.fa_CambioProductoDet.RemoveRange(lst);
                    int secuencia = 1;
                    foreach (var item in info.LstDet)
                    {
                        db.fa_CambioProductoDet.Add(new fa_CambioProductoDet
                        {
                            IdEmpresa = info.IdEmpresa,
                            IdSucursal = info.IdSucursal,
                            IdBodega = info.IdBodega,
                            IdCambio = info.IdCambio,
                            Secuencia = secuencia++,

                            IdCbteVta = item.IdCbteVta,
                            SecuenciaFact = item.SecuenciaFact,
                            IdProductoFact = item.IdProductoFact,
                            IdProductoCambio = item.IdProductoCambio,
                            CantidadCambio = item.CantidadCambio,
                            CantidadFact = item.CantidadFact
                        });
                    }

                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AnularDB(fa_CambioProducto_Info info)
        {
            try
            {
                using (Entities_facturacion db = new Entities_facturacion())
                {
                    var Entity = db.fa_CambioProducto.Where(q => q.IdEmpresa == info.IdEmpresa && q.IdSucursal == info.IdSucursal && q.IdBodega == info.IdBodega && q.IdCambio == info.IdCambio).FirstOrDefault();
                    if (Entity == null) return false;
                    Entity.Estado = false;

                    Entity.IdUsuarioUltAnu = info.IdUsuario;
                    Entity.FechaUltAnu = DateTime.Now;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public fa_CambioProducto_Info GetInfo(int IdEmpresa, int IdSucursal, int IdBodega, decimal IdCambio)
        {
            try
            {
                fa_CambioProducto_Info info;
                using (Entities_facturacion db = new Entities_facturacion())
                {
                    var Entity = db.fa_CambioProducto.Where(q => q.IdEmpresa == IdEmpresa && q.IdSucursal == IdSucursal && q.IdBodega == IdBodega && q.IdCambio == IdCambio).FirstOrDefault();
                    if (Entity == null) return null;
                    info = new fa_CambioProducto_Info
                    {
                        IdEmpresa = Entity.IdEmpresa,
                        IdSucursal = Entity.IdSucursal,
                        IdBodega = Entity.IdBodega,
                        IdCambio = Entity.IdCambio,
                        Fecha = Entity.Fecha,
                        Observacion = Entity.Observacion,
                        Estado = Entity.Estado,
                        IdMovi_inven_tipo = Entity.IdMovi_inven_tipo,
                        IdNumMovi = Entity.IdNumMovi,
                    };
                }
                return info;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
