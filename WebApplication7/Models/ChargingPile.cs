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
    
    public partial class ChargingPile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChargingPile()
        {
            this.ChargeStation = new HashSet<ChargeStation>();
        }
    
        public long id { get; set; }
        public System.Guid UUID { get; set; }
        public string ChargePile_Name { get; set; }
        public Nullable<int> Voltage { get; set; }
        public Nullable<int> Current { get; set; }
        public Nullable<int> Power { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChargeStation> ChargeStation { get; set; }
    }
}
