﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bil372_Odev1_Grup6.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UygulamaEntities : DbContext
    {
        public UygulamaEntities()
            : base("name=UygulamaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BRAND_ORGS> BRAND_ORGS { get; set; }
        public virtual DbSet<COUNTRY_CITY> COUNTRY_CITY { get; set; }
        public virtual DbSet<FEATURES> FEATURES { get; set; }
        public virtual DbSet<FLOW> FLOW { get; set; }
        public virtual DbSet<MANUFACTURERS> MANUFACTURERS { get; set; }
        public virtual DbSet<ORGANISATIONS> ORGANISATIONS { get; set; }
        public virtual DbSet<PRODUCT> PRODUCT { get; set; }
        public virtual DbSet<PRODUCT_BRANDS> PRODUCT_BRANDS { get; set; }
        public virtual DbSet<PRODUCT_FEATURES> PRODUCT_FEATURES { get; set; }
    }
}
