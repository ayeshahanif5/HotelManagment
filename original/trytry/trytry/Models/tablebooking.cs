<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace trytry.Models
{
	public class tableBooking
	{
        public string Name { get; set; }
        public int Person_No { get; set; }
        public DateTime Date { get; set; }
        public DateTime Start_Time { get; set; }
        public DateTime End_Time { get; set; }
        public int Table_No { get; set; }
    }
}
=======
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
    
    public partial class tablebooking
    {
        public int TableId { get; set; }
        public string CityName { get; set; }
        public string HallName { get; set; }
        public string address { get; set; }
        public Nullable<int> personno { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<System.TimeSpan> starttime { get; set; }
        public Nullable<System.TimeSpan> endtime { get; set; }
        public Nullable<int> budget { get; set; }
        public byte[] image { get; set; }
    }
}
>>>>>>> 2fabd8ac4f2c71a90f40a834c1ca6af90e262e73
