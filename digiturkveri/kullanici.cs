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
    
    public partial class kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public kullanici()
        {
            this.kategoris = new HashSet<kategori>();
            this.kategorilers = new HashSet<kategoriler>();
            this.pakets = new HashSet<paket>();
            this.paketResims = new HashSet<paketResim>();
            this.Site_Ayar = new HashSet<Site_Ayar>();
            this.webpages_Roles = new HashSet<webpages_Roles>();
        }
    
        public int kid { get; set; }
        public string kadi { get; set; }
        public string ksifre { get; set; }
        public string ksifretekrar { get; set; }
        public bool kaktifmi { get; set; }
        public System.DateTime kolusturmatarih { get; set; }
        public string kemail { get; set; }
        public string kurl { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kategori> kategoris { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kategoriler> kategorilers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<paket> pakets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<paketResim> paketResims { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Site_Ayar> Site_Ayar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<webpages_Roles> webpages_Roles { get; set; }
    }
}