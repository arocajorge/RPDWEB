﻿using Core.Erp.Data.Contabilidad;
using Core.Erp.Info.Contabilidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Bus.Contabilidad
{
    public class ct_anio_fiscal_Bus
    {
        ct_anio_fiscal_Data odata = new ct_anio_fiscal_Data();
        public List<ct_anio_fiscal_Info> get_list(bool mostrar_anulados)
        {
            try
            {
                return odata.get_list(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ct_anio_fiscal_Info get_info(int IdanioFiscal)
        {
            try
            {
                return odata.get_info(IdanioFiscal);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool guardarDB(ct_anio_fiscal_Info info)
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
        public bool modificarDB(ct_anio_fiscal_Info info)
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
        public bool anularDB(ct_anio_fiscal_Info info)
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
        public bool validar_existe_Idanio(int IdanioFiscal = 0)
        {
            try
            {
                return odata.validar_existe_Idanio(IdanioFiscal);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
