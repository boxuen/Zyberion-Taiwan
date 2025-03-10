//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class ChargingRecord
    {
        public long ID { get; set; }
        public Nullable<long> Car_id { get; set; }
        public Nullable<long> Charging_id { get; set; }
        public Nullable<System.DateTime> Charging_Start_Time { get; set; }
        public Nullable<System.DateTime> Charging_End_Time { get; set; }
        public string Charging_Start_Capacity { get; set; }
        public string Charging_End_Capacity { get; set; }
        public string Charging_Minutes { get; set; }
        public string Remaining_Capacity { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual ChargeStation ChargeStation { get; set; }
    }
}
