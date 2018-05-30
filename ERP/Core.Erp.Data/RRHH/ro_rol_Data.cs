﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Info.RRHH;
namespace Core.Erp.Data.RRHH
{
   public class ro_rol_Data
    {
        public List< ro_rol_Info> get_list(int IdEmpresa)
        {
            try
            {
                List<ro_rol_Info> Lista = new List<ro_rol_Info>();

                using (Entities_rrhh Context = new Entities_rrhh())
                {
                        Lista = (from q in Context. ro_rol
                                 where q.IdEmpresa == IdEmpresa
                                 select new  ro_rol_Info
                                 {
                                     IdEmpresa = q.IdEmpresa,
                                     IdNomina_Tipo = q.IdNominaTipo,
                                     IdNomina_TipoLiqui = q.IdNominaTipoLiqui,
                                     IdPeriodo = q.IdPeriodo,
                                     Observacion=q.Observacion,
                                      Descripcion=q.Descripcion,
                                      Cerrado=q.Cerrado
                                       
                                 }).ToList();
                   
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public  ro_rol_Info get_info(int IdEmpresa, int IdNominaTipo, int IdNominaTipoLiqui, int IdPeriodo)
        {
            try
            {
                 ro_rol_Info info = new  ro_rol_Info();

                using (Entities_rrhh Context = new Entities_rrhh())
                {
                     ro_rol Entity = Context. ro_rol.FirstOrDefault(q => q.IdEmpresa == IdEmpresa && q.IdNominaTipo == IdNominaTipo && q.IdNominaTipoLiqui==IdNominaTipoLiqui && q.IdPeriodo==IdPeriodo);
                    if (Entity == null) return null;

                    info = new  ro_rol_Info
                    {
                        IdEmpresa = Entity.IdEmpresa,
                        IdNomina_Tipo = Entity.IdNominaTipo,
                        IdNomina_TipoLiqui = Entity.IdNominaTipoLiqui,
                        IdPeriodo = Entity.IdPeriodo,
                        Observacion = Entity.Observacion,
                        Descripcion = Entity.Descripcion,
                        Cerrado = Entity.Cerrado
                    };
                }

                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool procesar( ro_rol_Info info)
        {
            try
            {
                using (Entities_rrhh Context = new Entities_rrhh())
                {
                    Context.spRo_procesa_Rol(info.IdEmpresa, info.IdNomina_Tipo, info.IdNomina_TipoLiqui, info.IdPeriodo, info.UsuarioIngresa, info.Observacion);
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
