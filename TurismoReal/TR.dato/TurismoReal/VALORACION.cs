//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TR.dato.TurismoReal
{
    using System;
    using System.Collections.Generic;
    
    public partial class VALORACION
    {
        public decimal VALORACION_ID { get; set; }
        public Nullable<decimal> RANKING { get; set; }
        public decimal DEPARTAMENTO_ID { get; set; }
        public string RUN_CLIENTE { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        public virtual DEPARTAMENTO DEPARTAMENTO { get; set; }
    }
}
