//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class in_Producto_x_fa_NivelDescuento
    {
        public int IdEmpresa { get; set; }
        public decimal IdProducto { get; set; }
        public int IdNivel { get; set; }
        public int Secuencia { get; set; }
        public double Porcentaje { get; set; }
    
        public virtual in_Producto in_Producto { get; set; }
    }
}