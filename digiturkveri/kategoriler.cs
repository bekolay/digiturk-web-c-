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
    
    public partial class kategoriler
    {
        public int kategorid { get; set; }
        public string kategoriadi { get; set; }
        public string kategoriurl { get; set; }
        public System.DateTime kategoritarih { get; set; }
        public bool kategoriaktif { get; set; }
        public int kid { get; set; }
    
        public virtual kullanici kullanici { get; set; }
    }
}