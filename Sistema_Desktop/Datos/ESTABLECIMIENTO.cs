//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class ESTABLECIMIENTO
    {
        public ESTABLECIMIENTO()
        {
            this.SOLICITUD = new HashSet<SOLICITUD>();
            this.PROGRAMA = new HashSet<PROGRAMA>();
        }
    
        public decimal ID_ESTABLECIMIENTO { get; set; }
        public string ID_TRIBUTARIO { get; set; }
        public string NOMBRE_ESTABLECIMIENTO { get; set; }
        public string TELEFONO { get; set; }
        public string EMAIL { get; set; }
        public string DIRECCION { get; set; }
        public decimal ID_CIUDAD { get; set; }
    
        public virtual CIUDAD CIUDAD { get; set; }
        public virtual ICollection<SOLICITUD> SOLICITUD { get; set; }
        public virtual ICollection<PROGRAMA> PROGRAMA { get; set; }
    }
}
