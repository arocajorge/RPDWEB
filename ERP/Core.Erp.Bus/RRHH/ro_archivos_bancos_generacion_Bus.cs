﻿using Core.Erp.Data.RRHH;
using Core.Erp.Info.Helps;
using Core.Erp.Info.RRHH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Bus.RRHH
{
   public class ro_archivos_bancos_generacion_Bus
    {
        ro_archivos_bancos_generacion_Data odata = new ro_archivos_bancos_generacion_Data();
        public List<ro_archivos_bancos_generacion_Info> get_list(int IdEmpresa, DateTime Fechainicio, DateTime fechafin, bool estado)
        {
            try
            {
                return odata.get_list(IdEmpresa,Fechainicio, fechafin, estado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ro_archivos_bancos_generacion_Info get_info(int IdEmpresa, decimal IdArchivo)
        {
            try
            {
                return odata.get_info(IdEmpresa, IdArchivo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(ro_archivos_bancos_generacion_Info info)
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

        public bool modificarDB(ro_archivos_bancos_generacion_Info info)
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

        public bool anularDB(ro_archivos_bancos_generacion_Info info)
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

        public string GetArchivo(ro_archivos_bancos_generacion_Info info)
        {
            try
            {
                string Archivo = "";
                switch (info.TipoFile)
                {
                    case cl_enumeradores.eTipoProcesoBancario.NCR:
                        
                        break;
                  
                    case cl_enumeradores.eTipoProcesoBancario.ROL_ELECTRONICO:

                        break;
                    
                    default:
                        break;
                }

                return Archivo;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #region Archivos para el banco de guayaquil

        private string get_NCR(ro_archivos_bancos_generacion_Info info)
        {
            try
            {
                string File = "";
                foreach (var item in info.detalle)
                {

                }

                return File;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

    }
}
