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
    
    public partial class EMPLEADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLEADO()
        {
            this.RESERVA = new HashSet<RESERVA>();
            this.SUCURSAL1 = new HashSet<SUCURSAL>();
        }
    
        public string RUN_EMPLEADO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO_PATERNO { get; set; }
        public string APELLIDO_MATERNO { get; set; }
        public string TELEFONO { get; set; }
        public string EMAIL { get; set; }
        public string DIRECCION { get; set; }
        public Nullable<System.DateTime> FECHA_NACIMIENTO { get; set; }
        public string CARGO { get; set; }
        public string USUARIO { get; set; }
        public decimal NUMERO_SUCURSAL { get; set; }
        public decimal COMUNA_ID { get; set; }
        public decimal ESTADO_ID { get; set; }
    
        public virtual COMUNA COMUNA { get; set; }
        public virtual ESTADO ESTADO { get; set; }
        public virtual SUCURSAL SUCURSAL { get; set; }
        public virtual USUARIO USUARIO1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESERVA> RESERVA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUCURSAL> SUCURSAL1 { get; set; }
    }
}
