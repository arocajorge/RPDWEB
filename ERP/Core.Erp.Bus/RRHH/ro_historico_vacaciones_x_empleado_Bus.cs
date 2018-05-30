﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Erp.Info.RRHH;
using Core.Erp.Data.RRHH;
namespace Core.Erp.Bus.RRHH
{
   public class ro_historico_vacaciones_x_empleado_Bus
    {
        ro_empleado_Bus bus_empleado = new ro_empleado_Bus();
        ro_empleado_Info info_empleado = new ro_empleado_Info();
        ro_historico_vacaciones_x_empleado_Data odata = new ro_historico_vacaciones_x_empleado_Data();
        public Boolean GrabarBD(ro_historico_vacaciones_x_empleado_Info info)
        {
            try
            {
                return odata.GrabarBD(info);
            }
            catch (Exception )
            {
                throw;
            }
        }
        public Boolean ModificarBD(ro_historico_vacaciones_x_empleado_Info info)
        {
            try
            {
                return odata.ModificarBD(info);
            }
            catch (Exception )
            {
                throw;
            }
        }
        public List<ro_historico_vacaciones_x_empleado_Info> get_list(int IdEmpresa,decimal IdEmpleado)
        {
            try
            {
                return odata.get_list(IdEmpresa, IdEmpleado);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<ro_historico_vacaciones_x_empleado_Info> get_lst_vaciones_x_empleado(int IdEmpresa, decimal IdEmpleado)
        {
            try
            {
                info_empleado = bus_empleado.get_info(IdEmpresa, IdEmpleado);
                List<ro_historico_vacaciones_x_empleado_Info> lst_vacaciones = new List<ro_historico_vacaciones_x_empleado_Info>();
                List<ro_historico_vacaciones_x_empleado_Info> listadoTmp = new List<ro_historico_vacaciones_x_empleado_Info>();
                DateTime fechaActual =DateTime.Now;
                DateTime fechaIngreso = Convert.ToDateTime(info_empleado.em_fechaIngaRol);
                DateTime fechaNueva = new DateTime();
                double dias = 0;
                int meses = 0;
                int anio = 0;
                if (info_empleado.em_status == "EST_PLQ")
                {
                    dias = CalcularDiasDeDiferencia(fechaIngreso, Convert.ToDateTime(info_empleado.em_fechaSalida));
                    meses = CalcularMesesDeDiferencia(fechaIngreso, Convert.ToDateTime(info_empleado.em_fechaSalida));
                    anio = CalcularAniosDeDiferencia(fechaIngreso, Convert.ToDateTime(info_empleado.em_fechaSalida));
                }
                else
                {
                    dias = CalcularDiasDeDiferencia(fechaIngreso, fechaActual);
                    meses = CalcularMesesDeDiferencia(fechaIngreso, fechaActual);
                    anio = CalcularAniosDeDiferencia(fechaIngreso, fechaActual);
                }
                int minAnio = 5;
                int maxDiasGanados = 15;
                int minDiasGanados = 15;
                int diasGanados = 0;
                int contDiasGanados = 0;
                    //VALIDA SI TIENE MAS DE 1 AÑO
                    if (dias > 360)
                    {
                        fechaNueva = fechaIngreso;
                        //RECORRE LA CANTIDAD DE AÑOS QUE TIENE DE SERVICIO
                        for (int i = 0; i < anio; i++)
                        {
                            if (i < minAnio)//VALIDA LOS 5 AÑOS BASE
                            {
                                diasGanados = minDiasGanados;
                                contDiasGanados = 0;
                            }
                            else
                            {
                                if (i >= minAnio && contDiasGanados < maxDiasGanados)//VALIDA QUE SOLO ACUMULE 30 DIAS DE VACACIONES A PARTIR DEL 5 AÑO
                                {
                                    contDiasGanados++;
                                    diasGanados = minDiasGanados + contDiasGanados;
                                }
                                else
                                {
                                    diasGanados = 30;//DE AQUI EN ADELANTE TENDREA SOLO 30 DIAS 
                                }
                            }
                            ro_historico_vacaciones_x_empleado_Info info = new ro_historico_vacaciones_x_empleado_Info();
                            info.IdEmpresa = info_empleado.IdEmpresa;
                            info.IdEmpleado = info_empleado.IdEmpleado;
                            info.FechaIni = fechaNueva.AddYears(i);
                            info.FechaFin = info.FechaIni.AddYears(1).AddDays(-1);
                            info.DiasGanado = diasGanados;
                            info.DiasPendientes = diasGanados;
                            info.DiasTomados = 0;
                        lst_vacaciones.Add(info);
                        }
                    }
                    else
                    {
                        ro_historico_vacaciones_x_empleado_Info info = new ro_historico_vacaciones_x_empleado_Info();
                        info.IdEmpresa = info_empleado.IdEmpresa;
                        info.IdEmpleado = info_empleado.IdEmpleado;
                        info.FechaIni = Convert.ToDateTime(info_empleado.em_fecha_ingreso);
                        info.FechaFin = Convert.ToDateTime(info_empleado.em_fechaSalida);
                        info.DiasGanado = Convert.ToInt32(dias);
                        info.DiasPendientes = Convert.ToInt32(dias);
                        lst_vacaciones.Add(info);

                }
                return lst_vacaciones;
            }
            catch (Exception )
            {
                throw;
            }

        }
        public int CalcularMesesDeDiferencia(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                return Math.Abs((fechaDesde.Month - fechaHasta.Month) + 12 * (fechaDesde.Year - fechaHasta.Year));
            }
            catch (Exception )
            {
                throw;
            }

        }
        public double CalcularDiasDeDiferencia(DateTime primerFecha, DateTime segundaFecha)
        {
            try
            {
                TimeSpan diferencia;
                diferencia = primerFecha - segundaFecha;

                return Math.Abs(diferencia.Days);
            }
            catch (Exception )
            {
                throw;
            }

        }
        public int CalcularAniosDeDiferencia(DateTime primerFecha, DateTime segundaFecha)
        {
            try
            {
                return Math.Abs(primerFecha.Year - segundaFecha.Year);
            }
            catch (Exception )
            {
                throw;
            }

        }

    }
}
