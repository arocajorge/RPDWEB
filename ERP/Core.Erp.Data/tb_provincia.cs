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
    
    public partial class tb_provincia
    {
        public tb_provincia()
        {
            this.tb_ciudad = new HashSet<tb_ciudad>();
        }
    
        public string IdProvincia { get; set; }
        public string Cod_Provincia { get; set; }
        public string Descripcion_Prov { get; set; }
        public string Estado { get; set; }
        public string IdPais { get; set; }
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> Fecha_Transac { get; set; }
        public string IdUsuarioUltMod { get; set; }
        public Nullable<System.DateTime> Fecha_UltMod { get; set; }
        public string IdUsuarioUltAnu { get; set; }
        public Nullable<System.DateTime> Fecha_UltAnu { get; set; }
        public string MotivoAnula { get; set; }
        public string nom_pc { get; set; }
        public string ip { get; set; }
        public string Cod_Region { get; set; }
    
        public virtual ICollection<tb_ciudad> tb_ciudad { get; set; }
        public virtual tb_pais tb_pais { get; set; }
        public virtual tb_region tb_region { get; set; }
    }
}
