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
    
    public partial class basvuru
    {
        public int basvuruid { get; set; }
        public string basvuruadisoyadi { get; set; }
        public string basvurutel { get; set; }
        public bool basvurukabul { get; set; }
        public Nullable<int> pid { get; set; }
        public string basipadres { get; set; }
        public string basvurutarih { get; set; }
    
        public virtual paket paket { get; set; }
    }
}
