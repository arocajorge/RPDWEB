//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Erp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_region
    {
        public tb_region()
        {
            this.tb_provincia = new HashSet<tb_provincia>();
        }
    
        public string Cod_Region { get; set; }
        public string Nom_region { get; set; }
        public string codigo { get; set; }
        public bool estado { get; set; }
        public string IdPais { get; set; }
    
        public virtual tb_pais tb_pais { get; set; }
        public virtual ICollection<tb_provincia> tb_provincia { get; set; }
    }
}
