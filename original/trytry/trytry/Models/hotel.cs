using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace trytry.Models
{
    public class hotel
    {
        public int HotelId { get; set; }
        public Nullable<int> CityId { get; set; }
        [DisplayName("hotelname")]
        [Required(ErrorMessage = "hotelname is required.")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string hotelname { get; set; }

       


        public string CityName { get; set; }
        [DisplayName("address")]
        [Required(ErrorMessage = "address is required.")]
        [StringLength(150)]
        [DataType(DataType.PostalCode)]
        public string address { get; set; }


        [DisplayName("roomtype")]
        [Required(ErrorMessage = "roomtype is required.")]
        [StringLength(150)]
        [DataType(DataType.Text)]
        public string roomtype { get; set; }





        [DisplayName("facilities")]
        [Required(ErrorMessage = "facilities is required.")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string facilities { get; set; }

        [DataType(DataType.ImageUrl)]
        public byte[] image { get; set; }






        [DisplayName("budget")]
        [Required(ErrorMessage = "budget is required.")]

        [DataType(DataType.Currency)]
        public Nullable<int> budget { get; set; }





        [DisplayName("availablerooms")]
        [Required(ErrorMessage = "availablerooms is required.")]

        [DataType(DataType.Text)]

        public string avaliablerooms { get; set; }




        [DisplayName("checkinDate")]
        [Required(ErrorMessage = "checkinDate is required.")]

        [DataType(DataType.Date)]

        public Nullable<System.DateTime> checkindate { get; set; }


        [DisplayName("checkoutDate")]
        [Required(ErrorMessage = "checkoutDate is required.")]

        [DataType(DataType.Date)]

        public Nullable<System.DateTime> checkoutdate { get; set; }
        public virtual c c { get; set; }
    }
}