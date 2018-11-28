using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace trytry.Models
{
    public class HotelModel
    {
        public int HotelId { get; set; }
        public int CityId { get; set; }
        [DisplayName("Hotel Name")]
        public string hotelname { get; set; }
        [DisplayName("Address")]
        public string address { get; set; }
        [DisplayName("Room Type")]
        public string roomtype { get; set; }
        [DisplayName("Facilities")]
        public string facilities { get; set; }
        [DisplayName("Image Path")]
        public byte[] image { get; set; }
        [DisplayName("Budget")]

        public int budget { get; set; }
        [DisplayName("Avaliable Rooms")]
        public string avaliablerooms { get; set; }

        public DateTime checkindate { get; set; }
        public DateTime checkoutdate { get; set; }

    }
}