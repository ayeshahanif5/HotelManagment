using System;
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