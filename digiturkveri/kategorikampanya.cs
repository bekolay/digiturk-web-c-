//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace digiturkveri
{
    using System;
    using System.Collections.Generic;
    
    public partial class kategorikampanya
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public kategorikampanya()
        {
            this.paketkampanyas = new HashSet<paketkampanya>();
        }
    
        public int kateid { get; set; }
        public string kateadi { get; set; }
        public System.DateTime katetarih { get; set; }
        public string kateurl { get; set; }
        public bool kateaktif { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<paketkampanya> paketkampanyas { get; set; }
    }
}
