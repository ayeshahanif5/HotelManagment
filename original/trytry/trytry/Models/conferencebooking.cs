using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace trytry.Models
{
    public class conferencebooking
    {
        public int BookingId { get; set; }
        public int HallId { get; set; }
        public string Name { get; set; }
        public int Phone_No { get; set; }
        public string Address { get; set; }
        public DateTime checkindate { get; set; }
        public DateTime checkoutdate { get; set; }
        public string HallName { get; set; }
        public int Noofpeople { get; set; }
        public string Time { get; set; }
    }
}