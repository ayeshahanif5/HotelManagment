using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace trytry.Models
{
    public class bookingtable
    {
        public int BookingId { get; set; }
        public int TableId { get; set; }
        public string Name { get; set; }
        public int Phone_No { get; set; }
        public string Address { get; set; }
        public DateTime checkindate { get; set; }
        
        public string HallName { get; set; }
        public int personno { get; set; }
        public DateTime Time { get; set; }
    }
}