﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication7.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ZCharge_PlanEntities : DbContext
    {
        public ZCharge_PlanEntities()
            : base("name=ZCharge_PlanEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<CarBrand> CarBrand { get; set; }
        public virtual DbSet<CarDisplay> CarDisplay { get; set; }
        public virtual DbSet<ChargeStation> ChargeStation { get; set; }
        public virtual DbSet<Charging_Gun> Charging_Gun { get; set; }
        public virtual DbSet<ChargingPile> ChargingPile { get; set; }
        public virtual DbSet<ChargingPrice> ChargingPrice { get; set; }
        public virtual DbSet<ChargingRecord> ChargingRecord { get; set; }
        public virtual DbSet<Level> Level { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UseTime> UseTime { get; set; }
    }
}
