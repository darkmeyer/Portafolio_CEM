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
    
    public partial class PROGRAMA
    {
        public PROGRAMA()
        {
            this.PROGRAMA_ANTECEDENTE = new HashSet<PROGRAMA_ANTECEDENTE>();
            this.SOLICITUD = new HashSet<SOLICITUD>();
            this.RAMO = new HashSet<RAMO>();
        }
    
        public decimal ID_PROGRAMA { get; set; }
        public System.DateTime FECHA_INICIO { get; set; }
        public System.DateTime FECHA_TERMINO { get; set; }
        public decimal CUPOS { get; set; }
        public decimal CANT_ALUMNOS_MAX { get; set; }
        public decimal CANT_ALUMNOS_MIN { get; set; }
        public string ESTADO { get; set; }
    
        public virtual ICollection<PROGRAMA_ANTECEDENTE> PROGRAMA_ANTECEDENTE { get; set; }
        public virtual ICollection<SOLICITUD> SOLICITUD { get; set; }
        public virtual ICollection<RAMO> RAMO { get; set; }
    }
}