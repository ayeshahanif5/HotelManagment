using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace trytry.Models
{
    public class wedding1
    {
        public int HallId { get; set; }

        [DisplayName("CityName")]
        [Required(ErrorMessage = "CityName is required.")]
        [StringLength(50)]
        [DataType(DataType.Text)]


        public string CityName { get; set; }


        [DisplayName("HallName")]
        [Required(ErrorMessage = "HallName is required.")]
        [StringLength(50)]
        [DataType(DataType.Text)]


        public string HallName { get; set; }



        [DisplayName("facilities")]
        [Required(ErrorMessage = "facilities are required.")]
        [StringLength(150)]
        [DataType(DataType.Text)]
        public string facilities { get; set; }



        [Required]
        public string image { get; set; }



        [DisplayName("FoodItems")]
        [Required(ErrorMessage = "FoodItems are required.")]
        [StringLength(50)]
        [DataType(DataType.Text)]

        public string fooditems { get; set; }




        [Required(ErrorMessage = "capacity is required.")]
      
        public Nullable<int> capacity { get; set; }

        [DisplayName("Date")]
        [Required(ErrorMessage = "Date is required.")]
 
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> date { get; set; }

        [DisplayName("Time")]
        [Required(ErrorMessage = "time is required.")]

        [DataType(DataType.DateTime)]
        public Nullable<System.TimeSpan> time { get; set; }


        [DisplayName("budget")]
        [Required(ErrorMessage = "budget is required.")]
     
        [DataType(DataType.Currency)]
        public Nullable<int> budget { get; set; }


        [DisplayName("address")]
        [Required(ErrorMessage = "address is required.")]
        [StringLength(150)]
        [DataType(DataType.PostalCode)]
        public string address { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}