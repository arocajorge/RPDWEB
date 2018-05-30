﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Data.RRHH;
using Core.Erp.Info.RRHH;
namespace Core.Erp.Bus.RRHH
{
   public class ro_division_Bus
    {
        ro_division_Data odata = new ro_division_Data();
        public List<ro_division_Info> get_list(int IdEmpresa, bool estado)
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

        public ro_division_Info get_info(int IdEmpresa, int IdDivision)
        {
            try
            {
                return odata.get_info(IdEmpresa, IdDivision);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(ro_division_Info info)
        {
            try
            {
                return odata.guardarDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool modificarDB(ro_division_Info info)
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

        public bool anularDB(ro_division_Info info)
        {
            try
            {
                return odata.anularDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
