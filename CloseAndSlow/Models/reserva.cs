//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CloseAndSlow.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class reserva
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public reserva()
        {
            this.servicios = new HashSet<servicios>();
        }
    
        public int id_reserva { get; set; }
        public System.DateTime fecha_reserva { get; set; }
        public System.DateTime fecha_entrada { get; set; }
        public System.DateTime fecha_salida { get; set; }
        public bool anulada { get; set; }
        public System.DateTime fecha_anulacion { get; set; }
        public decimal precio_total { get; set; }
        public int id_cliente { get; set; }
        public int id_hotel { get; set; }
        public int id_habitacion { get; set; }
    
        public virtual cliente cliente { get; set; }
        public virtual hotel hotel { get; set; }
        public virtual hotel hotel1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<servicios> servicios { get; set; }
    }
}
