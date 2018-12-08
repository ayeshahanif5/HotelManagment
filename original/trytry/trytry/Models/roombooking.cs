using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace trytry.Models
{
    public class roombooking
    {
        public int BookingId { get; set; }
        public int HotellId { get; set; }

        public int Roomno { get; set; }
        public string Name { get; set; }
        public int Phoneno { get; set; }
        public string Address { get; set; }
        public DateTime checkindate { get; set; }
        public DateTime checkoutdate { get; set; }
        public string Hallname { get; set; }
    }
}