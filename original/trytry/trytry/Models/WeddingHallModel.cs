using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace trytry.Models
{
    public class WeddingHallModel
    {

        public int HallId { get; set; }
        [DisplayName("City Name")]


        [DataType(DataType.Text)]
        public string CityName { get; set; }



        [DataType(DataType.Text)]
        [DisplayName("Wedding Hall Name")]

        public string HallName { get; set; }



        [DataType(DataType.Text)]
        [DisplayName("Facilities")]
        public string facilities { get; set; }

        [DataType(DataType.ImageUrl)]
        [DisplayName("Image")]
        public byte[] image { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Food Items")]
        public string fooditems { get; set; }


        [DataType(DataType.Text)]
        [DisplayName("Capacity")]
        public int capacity { get; set; }




        [DataType(DataType.DateTime)]
        [DisplayName("Check In Date")]
        public DateTime date { get; set; }


        [DataType(DataType.DateTime)]
        [DisplayName("Check In Time")]
        public DateTime time { get; set; }


        [DataType(DataType.MultilineText)]
        [DisplayName("Budget per Person")]
        public int budget { get; set; }



        [DataType(DataType.PostalCode)]
        [DisplayName("Address")]


        public string address { get; set; }
    }
}