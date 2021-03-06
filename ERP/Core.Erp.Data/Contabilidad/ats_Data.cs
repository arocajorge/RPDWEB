﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Info.Contabilidad.ATS;
using Core.Erp.Info.Contabilidad.ATS.ATS_Info;
using Core.Erp.Data.General;

namespace Core.Erp.Data.Contabilidad
{
   public class ats_Data
    {
        tb_sucursal_Data data_sucursal = new tb_sucursal_Data();
        tb_empresa_Data data_empresa = new tb_empresa_Data();
        ct_periodo_Data data_perido = new ct_periodo_Data();
        public ats_Info get_info(int IdEmpresa, int IdPeriodo, int IdSucursal, int[] IntArray)
        {
            try
            {
                var empresa_info = data_empresa.get_info(IdEmpresa);
                var perido_info = data_perido.get_info(IdEmpresa, IdPeriodo);
                string Establecimiento = "";
                if (IntArray != null)
                    foreach (var item in IntArray)
                    {
                        Establecimiento += item.ToString()+ ",";
                }

                int IdSucursalInicio = Convert.ToInt32(IdSucursal);
                int IdSucursalFin = Convert.ToInt32(IdSucursal) == 0 ? 9999 : Convert.ToInt32(IdSucursal);
                ats_Info info = new ats_Info();
                using (Entities_contabilidad Context = new Entities_contabilidad())
                {

                    Context.generarATS(IdEmpresa, IdPeriodo, IdSucursalInicio, IdSucursalFin);
                    
                    info.lst_compras = (from q in Context.ATS_compras
                                        where q.IdEmpresa==IdEmpresa
                                        && q.IdPeriodo==IdPeriodo
                                        && Establecimiento.Contains(q.IdSucursal.ToString())
                                       // && q.establecimiento.contr
                                       // && q.idProv== "0909594202001"
                                        select new compras_Info
                             {
                                 IdEmpresa = q.IdEmpresa,
                                 IdPeriodo = q.IdPeriodo,
                                 Secuencia = q.Secuencia,
                                 codSustento = q.codSustento,
                                 tpIdProv=q.tpIdProv,
                                 idProv=q.idProv,
                                 tipoComprobante=q.tipoComprobante,
                                 parteRel=q.parteRel,
                                 tipoProv=q.tipoProv,
                                 denopr=q.denopr,
                                 fechaRegistro=q.fechaRegistro,
                                 establecimiento=q.establecimiento,
                                 puntoEmision=q.puntoEmision,
                                 secuencial=q.secuencial,
                                 fechaEmision=q.fechaEmision,
                                 autorizacion=q.autorizacion,
                                 baseNoGraIva = q.baseNoGraIva,
                                 baseImponible = q.baseImponible,
                                 baseImpGrav=q.baseImpGrav,
                                 baseImpExe=q.baseImpExe,
                                 montoIce=q.montoIce,
                                 montoIva=q.montoIva,
                                 pagoLocExt=q.pagoLocExt,
                                 denopago=q.denopago,
                                 paisEfecPago=q.paisEfecPago,
                                 formaPago=q.formaPago,
                                 docModificado=q.docModificado,
                                 estabModificado=q.estabModificado,
                                 ptoEmiModificado=q.ptoEmiModificado,
                                 secModificado=q.secModificado,
                                 autModificado=q.autModificado
                             }).ToList();




                    info.lst_ventas = (from v in Context.ATS_ventas
                                        where v.IdEmpresa == IdEmpresa
                                        && v.IdPeriodo == IdPeriodo
                                         && Establecimiento.Contains(v.IdSucursal.ToString())
                                       //  && v.idCliente== "0190339092001"
                                       select new ventas_Info
                                        {
                                            IdEmpresa = v.IdEmpresa,
                                            IdPeriodo = v.IdPeriodo,
                                            Secuencia = v.Secuencia,
                                            tpIdCliente = v.tpIdCliente,
                                            tipoCliente=v.tipoCliente,
                                            idCliente = v.idCliente,
                                            parteRelVtas = v.parteRel,
                                            tipoComprobante = v.tipoComprobante,
                                            tipoEmision=v.tipoEm,
                                            numeroComprobantes = v.numeroComprobantes,
                                            baseNoGraIva = v.baseNoGraIva,
                                            baseImponible = v.baseImponible,
                                            baseImpGrav = v.baseImpGrav,
                                            montoIva = v.montoIva,
                                            montoIce=v.montoIce,
                                            valorRetIva=v.valorRetIva,
                                            valorRetRenta=v.valorRetRenta,
                                            formaPago=v.formaPago,
                                            codEstab=v.codEstab,
                                            ventasEstab=v.ventasEstab,
                                            ivaComp=v.ivaComp,
                                            DenoCli=v.DenoCli
                                        }).ToList();


                    info.lst_retenciones = (from r in Context.ATS_retenciones
                                       where r.IdEmpresa == IdEmpresa
                                       && r.IdPeriodo == IdPeriodo
                                        && Establecimiento.Contains(r.IdSucursal.ToString())
                                            // && r.Cedula_ruc== "0909594202001"
                                            select new retenciones_Info
                                       {
                                           IdEmpresa = r.IdEmpresa,
                                           IdPeriodo = r.IdPeriodo,
                                           Secuencia = r.Secuencia,
                                           co_serie=r.co_serie ,
                                           co_factura=r.co_factura,
                                           Cedula_ruc=r.Cedula_ruc,
                                           valRetBien10=r.valRetBien10,
                                           valRetServ20=r.valRetServ20,
                                           valorRetBienes=r.valorRetBienes,
                                           valRetServ50=r.valRetServ50,
                                           valorRetServicios=r.valorRetServicios,
                                           valRetServ100=r.valRetServ100,
                                           codRetAir=r.codRetAir,
                                           estabRetencion1=r.estabRetencion1,
                                           ptoEmiRetencion1=r.ptoEmiRetencion1,
                                           secRetencion1=r.secRetencion1,
                                           autRetencion1=r.autRetencion1,
                                          fechaEmiRet1=r.fechaEmiRet1,
                                          docModificado=r.docModificado,
                                          estabModificado=r.autModificado,
                                          ptoEmiModificado=r.ptoEmiModificado,
                                          secModificado=r.secModificado,
                                          autModificado=r.autModificado,
                                          baseImpAir=r.baseImpAir,
                                           porcentajeAir=r.porcentajeAir,
                                           valRetAir=r.valRetAir,
                                           re_tipo_Ret=r.re_tipo_Ret,
                                           denopr=r.denopr
                                            }).ToList();

                    info.lst_exportaciones = (from e in Context.ATS_exportaciones
                                              where e.IdEmpresa == IdEmpresa
                                              && e.IdPeriodo == IdPeriodo
                                              && e.IdPeriodo == IdPeriodo
                                              && Establecimiento.Contains(e.IdSucursal.ToString())
                                              select new exportaciones_Info
                                              {
                                                  IdEmpresa = e.IdEmpresa,
                                                  IdPeriodo = e.IdPeriodo,
                                                  Secuencia = e.Secuencia,
                                                  tpIdClienteEx = e.tpIdClienteEx,
                                                  idClienteEx = e.idClienteEx,
                                                  parteRel = e.parteRel,
                                                  tipoRegi = e.tipoRegi,
                                                  paisEfecPagoGen = e.paisEfecPagoGen,
                                                  paisEfecExp = e.paisEfecExp,
                                                  exportacionDe = e.exportacionDe,
                                                  tipoComprobante = e.tipoComprobante,
                                                  fechaEmbarque = e.fechaEmbarque,
                                                  valorFOB = e.valorFOB,
                                                  valorFOBComprobante = e.valorFOBComprobante,
                                                  establecimiento = e.establecimiento,
                                                  puntoEmision = e.puntoEmision,
                                                  secuencial = e.secuencial,
                                                  autorizacion = e.autorizacion,
                                                  fechaEmision = e.fechaEmision,
                                                  denoExpCli = e.denoExpCli
                                                

                                            }).ToList();

                    info.lst_anulados = (from a in Context.ATS_comprobantes_anulados
                                              where a.IdEmpresa == IdEmpresa
                                              && a.IdPeriodo == IdPeriodo
                                             
                                          && Establecimiento.Contains(a.IdSucursal.ToString())
                                         select new comprobantesAnulados_info
                                              {
                                                  IdEmpresa = a.IdEmpresa,
                                                  IdPeriodo = a.IdPeriodo,
                                                  Secuencia = a.Secuencia,
                                                  tipoComprobante=a.tipoComprobante,
                                                  Establecimiento=a.Establecimiento,
                                                  puntoEmision=a.puntoEmision,
                                                  secuencialInicio=a.secuencialInicio,
                                                  secuencialFin=a.secuencialFin,
                                                  Autorizacion=a.Autorización
                                                  
                                              }).ToList();

                }

                return info;
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        
    }
}
