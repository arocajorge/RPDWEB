﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Data.RRHH;
using Core.Erp.Info.RRHH;
namespace Core.Erp.Bus.RRHH
{
   public class ro_rubros_calculados_Bus
    {
        ro_rubros_calculados_Data odata = new ro_rubros_calculados_Data();
        public List<ro_rubros_calculados_Info> get_list(int IdEmpresa, bool estado)
        {
            try
            {
                return odata.get_list(IdEmpresa, estado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ro_rubros_calculados_Info get_info(int IdEmpresa, int IdCargo)
        {
            try
            {
                return odata.get_info(IdEmpresa, IdCargo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(ro_rubros_calculados_Info info)
        {
            try
            {
                if (odata.si_existe(info.IdEmpresa))
                   return odata.modificarDB(info);else
                return odata.guardarDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool modificarDB(ro_rubros_calculados_Info info)
        {
            try
            {

                return odata.modificarDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
