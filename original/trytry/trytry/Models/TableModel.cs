using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace trytry.Models
{
    public class TableModel
    {
        public int TableId { get; set; }
        [DisplayName("City Name")]
        public string CityName { get; set; }
        [DisplayName("Hall Name")]
        public string HallName { get; set; }
        public int personno { get; set; }
        [DisplayName("Address")]
        public string address { get; set; }
        public DateTime date { get; set; }
        public DateTime starttime { get; set; }
        public DateTime endtime { get; set; }
        [DisplayName("Budget")]
        public int budget { get; set; }

       
        public byte[] image { get; set; }
    }
}