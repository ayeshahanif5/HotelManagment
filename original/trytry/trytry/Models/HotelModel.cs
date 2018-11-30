using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace trytry.Models
{
    public class HotelModel
    {
        public int HotelId { get; set; }
        public int CityId { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Hotel Name")]
        public string hotelname { get; set; }

        [DataType(DataType.PostalCode)]
        [DisplayName("Address")]
        public string address { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Room Type")]
        public string roomtype { get; set; }


        [DataType(DataType.Text)]
        [DisplayName("Facilities")]
        public string facilities { get; set; }


        [DataType(DataType.ImageUrl)]
        [DisplayName("Image Path")]
        public byte[] image { get; set; }



        [DataType(DataType.Text)]
        [DisplayName("Budget")]

        public int budget { get; set; }


        [DisplayName("Avaliable Rooms")]
        public string avaliablerooms { get; set; }



        [DataType(DataType.DateTime)]
        [DisplayName ("CheckIn Date")]
        public DateTime checkindate { get; set; }



        [DataType(DataType.DateTime)]
        [DisplayName ("CheckOut Date")]

        public DateTime checkoutdate { get; set; }

    }
}