﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Erp.Info.Facturacion
{
    public class fa_notaCreDeb_det_Info
    {
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public int IdBodega { get; set; }
        public decimal IdNota { get; set; }
        public int Secuencia { get; set; }
        [Required(ErrorMessage ="El campo producto es obligatorio")]
        [Range(1,int.MaxValue,ErrorMessage ="El campo producto es obligatorio")]
        public decimal IdProducto { get; set; }
        [Required(ErrorMessage = "El campo cantidad es obligatorio")]
        [Range(0.01, int.MaxValue, ErrorMessage = "El campo cantidad es obligatorio")]
        public double sc_cantidad { get; set; }
        [Required(ErrorMessage = "El campo precio es obligatorio")]
        [Range(0.01, int.MaxValue, ErrorMessage = "El campo precio es obligatorio")]
        public double sc_Precio { get; set; }
        public double sc_descUni { get; set; }
        [Required(ErrorMessage = "El campo % descuento es obligatorio")]
        public double sc_PordescUni { get; set; }
        public double sc_precioFinal { get; set; }
        public double sc_subtotal { get; set; }
        public double sc_iva { get; set; }
        public double sc_total { get; set; }
        public double sc_costo { get; set; }
        public string sc_observacion { get; set; }
        public double vt_por_iva { get; set; }
        public Nullable<int> IdPunto_Cargo { get; set; }
        public Nullable<int> IdPunto_cargo_grupo { get; set; }
        public string IdCod_Impuesto_Iva { get; set; }
        [Required(ErrorMessage = "El campo centro de costo es obligatorio")]
        public string IdCentroCosto { get; set; }
        #region Campos que no existen en la tabla
        public string pr_descripcion { get; set; }
        public string lote_num_lote { get; set; }
        public DateTime? lote_fecha_vcto { get; set; }
        public string nom_presentacion { get; set; }

        public Nullable<double> sc_cantidad_factura { get; set; }
        public string cc_Descripcion { get; set; }
        public double sc_subtotal_item { get; set; }
        public double sc_iva_item { get; set; }
        public double sc_total_item { get; set; }
        #endregion

    }
}
