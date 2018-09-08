﻿using Core.Erp.Info.Reportes.Facturacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Erp.Data.Reportes.Facturacion
{
    public class FAC_010_Data
    {public List<FAC_010_Info> get_list(int IdEmpresa, decimal IdProducto, string IdCategoria, int IdLinea, int IdGrupo, int IdSubGrupo, int IdMarca)
        {
            try
            {
                decimal IdProducto_ini = IdProducto;
                decimal IdPrducto_fin = IdProducto == 0 ? 9999 : IdProducto;
                

                int IdMarca_ini = IdMarca;
                int IdMarca_fin = IdMarca == 0 ? 9999 : IdMarca;
                List<FAC_010_Info> Lista;
                using (Entities_reportes Context = new Entities_reportes())
                {
                    Lista = (from q in Context.SPFAC_010(IdEmpresa, IdProducto_ini, IdPrducto_fin, IdCategoria, IdLinea, IdGrupo, IdSubGrupo, IdMarca_ini, IdMarca_fin)
                             select new FAC_010_Info
                             {
                                 IdEmpresa = q.IdEmpresa,
                                 IdProducto = q.IdProducto, 
                                 IdCategoria = q.IdCategoria,
                                 IdLinea = q.IdLinea, 
                                 IdGrupo = q.IdGrupo,
                                 IdSubGrupo = q.IdSubGrupo,

                             }).ToList();
                }
                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
