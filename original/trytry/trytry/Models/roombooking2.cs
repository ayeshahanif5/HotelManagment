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
    
    public partial class roombooking2
    {
        public int BookingId { get; set; }
        public Nullable<int> HotellId { get; set; }
        public Nullable<int> Roomno { get; set; }
        public string Name { get; set; }
        public Nullable<int> Phoneno { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> checkindate { get; set; }
        public Nullable<System.DateTime> checkoutdate { get; set; }
        public string Hallname { get; set; }
    
        public virtual hotel hotel { get; set; }
    }
}
