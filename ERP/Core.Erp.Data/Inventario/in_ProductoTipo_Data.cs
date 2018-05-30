﻿using Core.Erp.Info.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.Inventario
{
    public class in_ProductoTipo_Data
    {
        public List<in_ProductoTipo_Info> get_list(int IdEmpresa, bool mostrar_anulados)
        {
            try
            {
                List<in_ProductoTipo_Info> Lista;

                using (Entities_inventario Context = new Entities_inventario())
                {
                    if (mostrar_anulados)
                        Lista = (from q in Context.in_ProductoTipo
                                 where q.IdEmpresa == IdEmpresa
                                 select new in_ProductoTipo_Info
                                 {
                                     IdEmpresa = q.IdEmpresa,
                                     IdProductoTipo = q.IdProductoTipo,
                                     tp_descripcion = q.tp_descripcion,
                                     Estado = q.Estado
                                 }).ToList();
                    else
                        Lista = (from q in Context.in_ProductoTipo
                                 where q.IdEmpresa == IdEmpresa
                                 && q.Estado == "A"
                                 select new in_ProductoTipo_Info
                                 {
                                     IdEmpresa = q.IdEmpresa,
                                     IdProductoTipo = q.IdProductoTipo,
                                     tp_descripcion = q.tp_descripcion,
                                     Estado = q.Estado
                                 }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public in_ProductoTipo_Info get_info(int IdEmpresa, int IdProductoTipo)
        {
            try
            {
                in_ProductoTipo_Info info = new in_ProductoTipo_Info();

                using (Entities_inventario Context = new Entities_inventario())
                {
                    in_ProductoTipo Entity = Context.in_ProductoTipo.FirstOrDefault(q => q.IdEmpresa == IdEmpresa && q.IdProductoTipo == IdProductoTipo);
                    if (Entity == null) return null;
                    info = new in_ProductoTipo_Info
                    {
                        IdEmpresa = Entity.IdEmpresa,
                        IdProductoTipo = Entity.IdProductoTipo,
                        tp_descripcion = Entity.tp_descripcion,
                        tp_EsCombo_bool = Entity.tp_EsCombo == "S" ? true : false,
                        tp_ManejaInven_bool = Entity.tp_ManejaInven == "S" ? true : false,
                        tp_ManejaLote = Entity.tp_ManejaLote == null ? false : Convert.ToBoolean(Entity.tp_ManejaLote),
                        tp_EsCombo = Entity.tp_EsCombo,
                        tp_ManejaInven = Entity.tp_ManejaInven,
                        tp_es_lote = Entity.tp_es_lote == null ? false : Convert.ToBoolean(Entity.tp_es_lote),
                        Estado = Entity.Estado,
                    };
                }

                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private int get_id(int IdEmpresa)
        {
            try
            {
                int ID = 1;

                using (Entities_inventario Context = new Entities_inventario())
                {
                    var lst = from q in Context.in_ProductoTipo
                              where q.IdEmpresa == IdEmpresa
                              select q;

                    if (lst.Count() > 0)
                        ID = lst.Max(q => q.IdProductoTipo) + 1;
                }

                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(in_ProductoTipo_Info info)
        {
            try
            {
                using (Entities_inventario Context = new Entities_inventario())
                {
                    in_ProductoTipo Entity = new in_ProductoTipo
                    {
                        IdEmpresa = info.IdEmpresa,
                        IdProductoTipo = info.IdProductoTipo = get_id(info.IdEmpresa),
                        tp_descripcion = info.tp_descripcion,
                        tp_ManejaInven = info.tp_ManejaInven_bool == true ? "S" : "N",
                        tp_EsCombo = info.tp_EsCombo_bool == true ? "S" : "N",
                        tp_ManejaLote = info.tp_ManejaLote,
                        tp_es_lote = info.tp_es_lote,
                        Estado = "A",
                        IdUsuario = info.IdUsuario,
                        Fecha_Transac = DateTime.Now
                    };
                    Context.in_ProductoTipo.Add(Entity);
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool modificarDB(in_ProductoTipo_Info info)
        {
            try
            {
                using (Entities_inventario Context = new Entities_inventario())
                {
                    in_ProductoTipo Entity = Context.in_ProductoTipo.FirstOrDefault(q => q.IdEmpresa == info.IdEmpresa && q.IdProductoTipo == info.IdProductoTipo);
                    if (Entity == null) return false;
                    Entity.tp_descripcion = info.tp_descripcion;
                    Entity.tp_ManejaInven = info.tp_ManejaInven_bool == true ? "S" : "N";
                    Entity.tp_EsCombo = info.tp_EsCombo_bool == true ? "S" : "N";
                    Entity.tp_ManejaLote = info.tp_ManejaLote;
                    Entity.tp_es_lote = info.tp_es_lote;

                    Entity.IdUsuarioUltMod = info.IdUsuarioUltMod;
                    Entity.Fecha_UltMod = DateTime.Now;
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool anularDB(in_ProductoTipo_Info info)
        {
            try
            {
                using (Entities_inventario Context = new Entities_inventario())
                {
                    in_ProductoTipo Entity = Context.in_ProductoTipo.FirstOrDefault(q => q.IdEmpresa == info.IdEmpresa && q.IdProductoTipo == info.IdProductoTipo);
                    if (Entity == null) return false;
                    Entity.Estado = "I";

                    Entity.IdUsuarioUltAnu = info.IdUsuarioUltAnu;
                    Entity.Fecha_UltAnu = DateTime.Now;
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
