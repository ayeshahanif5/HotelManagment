//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace trytry.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class weddingbooking
    {
        public int BookingId { get; set; }
        public Nullable<int> HallId { get; set; }
        public string HallName { get; set; }
        public string Name { get; set; }
        public Nullable<int> Phone_No { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> checkindate { get; set; }
        public Nullable<System.DateTime> checkoutdate { get; set; }
        public Nullable<int> Noofpeople { get; set; }
        public string Time { get; set; }
    
        public virtual wedding1 wedding1 { get; set; }
    }
}
