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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class digiturkEntities : DbContext
    {
        public digiturkEntities()
            : base("name=digiturkEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<basvuru> basvurus { get; set; }
        public virtual DbSet<kategori> kategoris { get; set; }
        public virtual DbSet<kategoriler> kategorilers { get; set; }
        public virtual DbSet<kullanici> kullanicis { get; set; }
        public virtual DbSet<paket> pakets { get; set; }
        public virtual DbSet<paketResim> paketResims { get; set; }
        public virtual DbSet<Site_Ayar> Site_Ayars { get; set; }
        public virtual DbSet<webpages_Membership> webpages_Membership { get; set; }
        public virtual DbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public virtual DbSet<webpages_Roles> webpages_Roles { get; set; }
    }
}
