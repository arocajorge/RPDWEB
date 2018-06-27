﻿using Core.Erp.Data.General;
using Core.Erp.Info.General;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Bus.General
{
    public class tb_persona_Bus
    {
        tb_persona_Data odata = new tb_persona_Data();

        public List<tb_persona_Info> get_list_bajo_demanda(ListEditItemsRequestedByFilterConditionEventArgs args)
        {
            try
            {
                return odata.get_list_bajo_demanda(args);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<tb_persona_Info> get_list(bool mostrar_anulados)
        {
            try
            {
                return odata.get_list(mostrar_anulados);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public List<tb_persona_Info> get_list(int IdEmpresa, string IdTipo_persona)
        {
            try
            {
                return odata.get_list(IdEmpresa, IdTipo_persona);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public decimal validar_existe_cedula(string pe_CedulaRuc)
        {
            try
            {
                return odata.validar_existe_cedula(pe_CedulaRuc);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public tb_persona_Info get_info(decimal IdPersona)
        {
            try
            {
                return odata.get_info(IdPersona);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool guardarDB(tb_persona_Info info)
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
        public bool modificarDB(tb_persona_Info info)
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
        public bool anularDB(tb_persona_Info info)
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
