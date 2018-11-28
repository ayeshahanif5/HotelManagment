using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace trytry.Models
{
    public class WeddingHallModel
    {
   
        public int HallId { get; set; }
        [DisplayName("City Name")]

        public string CityName { get; set; }
        [DisplayName("Wedding Hall Name")]

        public string HallName { get; set; }
        [DisplayName("Facilities")]
        public string facilities { get; set; }
        [DisplayName("Image")]
        public byte[] image { get; set; }
        [DisplayName("Food Items")]
        public string fooditems { get; set; }
        [DisplayName("Capacity")]
        public int capacity { get; set; }
        [DisplayName("Check In Date")]
        public DateTime date { get; set; }
        [DisplayName("Check In Time")]
        public DateTime time { get; set; }
        [DisplayName("Budget per Person")]
        public int budget { get; set; }
        [DisplayName("Address")]
        public string address { get; set; }
    }
}