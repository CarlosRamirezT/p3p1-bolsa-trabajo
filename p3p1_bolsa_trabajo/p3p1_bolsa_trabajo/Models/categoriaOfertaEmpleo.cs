//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace p3p1_bolsa_trabajo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    public partial class categoriaOfertaEmpleo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public categoriaOfertaEmpleo()
        {
            this.Ofertas = new HashSet<Oferta>();
        }
    
        public int id_categoria_ofertas { get; set; }
        [DisplayName("Categoria")]
        public string titulo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Oferta> Ofertas { get; set; }
    }
}
