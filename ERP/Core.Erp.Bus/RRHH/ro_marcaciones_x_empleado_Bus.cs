﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Info.RRHH;
using Core.Erp.Data.RRHH;
namespace Core.Erp.Bus.RRHH
{
   public class ro_marcaciones_x_empleado_Bus
    {
        ro_marcaciones_x_empleado_Data odata = new ro_marcaciones_x_empleado_Data();
        public List<ro_marcaciones_x_empleado_Info> get_list(int IdEmpresa)
        {
            try
            {
                return odata.get_list(IdEmpresa);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ro_marcaciones_x_empleado_Info get_info(int IdEmpresa, decimal IdEmpleado, decimal IdRegistro)
        {
            try
            {
                return odata.get_info(IdEmpresa,IdEmpleado, IdRegistro);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(ro_marcaciones_x_empleado_Info info)
        {
            try
            {
                info.IdCalendadrio = Convert.ToInt32(info.es_fechaRegistro.ToString("ddMMyyyy"));
                if(!odata.si_existe(info))
                return odata.guardarDB(info);
                else
                return odata.modificarDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool modificarDB(ro_marcaciones_x_empleado_Info info)
        {
            try
            {
                info.IdCalendadrio =Convert.ToInt32( info.es_fechaRegistro.ToString("ddMMyyyy"));
                return odata.modificarDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool anularDB(ro_marcaciones_x_empleado_Info info)
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
