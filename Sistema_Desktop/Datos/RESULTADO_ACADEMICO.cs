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
    
    public partial class RESULTADO_ACADEMICO
    {
        public RESULTADO_ACADEMICO()
        {
            this.NOTA = new HashSet<NOTA>();
        }
    
        public decimal ID_RESULTADO { get; set; }
        public decimal PROMEDIO { get; set; }
        public string APROBADO { get; set; }
        public decimal ID_RAMO { get; set; }
        public decimal ID_ALUMNO { get; set; }
    
        public virtual ALUMNO ALUMNO { get; set; }
        public virtual ICollection<NOTA> NOTA { get; set; }
        public virtual RAMO RAMO { get; set; }
    }
}
