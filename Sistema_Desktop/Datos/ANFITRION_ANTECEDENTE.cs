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
    
    public partial class ANFITRION_ANTECEDENTE
    {
        public byte[] ARCHIVO { get; set; }
        public System.DateTime FECHA_SUBIDA_ARCHIVO { get; set; }
        public string ESTATUS { get; set; }
        public decimal ID_ANTECEDENTE { get; set; }
        public decimal ID_ANFITRION { get; set; }
    
        public virtual ANFITRION ANFITRION { get; set; }
        public virtual ANTECEDENTE ANTECEDENTE { get; set; }
    }
}
