﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Info.RRHH;
namespace Core.Erp.Data.RRHH
{
   public class ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Data
    {
        public List<ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info> get_list(int IdEmpresa)
        {
            try
            {
                int Secuencia = 1;
                List<ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info> Lista;

                using (Entities_rrhh Context = new Entities_rrhh())
                {
                    Lista = (from q in Context.ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar
                             where q.IdEmpresa == IdEmpresa
                             select new ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info
                             {
                                 IdEmpresa = q.IdEmpresa,
                                 IdNomina = q.IdNomina,
                                 IdNominaTipo = q.IdNominaTipo,
                                 IdTipoFlujo = q.IdTipoFlujo,
                                 Observacion = q.Observacion,
                                 IdCtaCble_sueldo = q.IdCtaCble
                             }).ToList();

                }
                Lista.ForEach(v=>v.Secuencia= Secuencia++);
                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info get_info(int IdEmpresa, int IdNomina, int IdNominaTipo)
        {
            try
            {
                ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info info = new ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info();

                using (Entities_rrhh Context = new Entities_rrhh())
                {
                    ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar Entity = Context.ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar.FirstOrDefault(q => q.IdEmpresa == IdEmpresa && q.IdNomina == IdNomina && q.IdNominaTipo == IdNominaTipo);
                    if (Entity == null) return null;

                    info = new ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info
                    {
                        IdEmpresa = Entity.IdEmpresa,
                        IdNomina = Entity.IdNomina,
                        IdNominaTipo = Entity.IdNominaTipo,
                        IdTipoFlujo = Entity.IdTipoFlujo,
                        Observacion = Entity.Observacion,
                        IdCtaCble = Entity.IdCtaCble
                    };
                }

                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool guardarDB(List<ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar_Info> info)
        {
            try
            {
                using (Entities_rrhh Context = new Entities_rrhh())
                {
                    foreach (var item in info)
                    {
                        ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar Entity = new ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar
                        {
                            IdEmpresa = item.IdEmpresa,
                            IdNomina = item.IdNomina,
                            IdNominaTipo = item.IdNominaTipo,
                            IdTipoFlujo = item.IdTipoFlujo,
                            Observacion = item.Observacion,
                            IdCtaCble = item.IdCtaCble_sueldo
                        };
                        Context.ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar.Add(Entity);
                    }
                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool eliminarDB(int IdEmpresa)
        {
            try
            {
                using (Entities_rrhh Context = new Entities_rrhh())
                {
                    string sql = "delete  ro_parametro_contable_x_Nomina_Tipoliqui_Sueldo_x_Pagar where IdEmpresa='" + IdEmpresa + "'";
                    Context.Database.ExecuteSqlCommand(sql);
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
