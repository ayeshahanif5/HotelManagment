using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace trytry.Models
{
    public class TableModel
    {
        public int TableId { get; set; }
        [DisplayName("City Name")]





        [DataType(DataType.Text)]
        public string CityName { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Hall Name")]
        public string HallName { get; set; }



        [DataType(DataType.Text)]
        public int personno { get; set; }


        [DataType(DataType.PostalCode)]
        [DisplayName("Address")]
        public string address { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime date { get; set; }





        [DataType(DataType.DateTime)]
        public DateTime starttime { get; set; }



        [DataType(DataType.DateTime)]
        public DateTime endtime { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Budget")]
        public int budget { get; set; }

        [DataType(DataType.ImageUrl)]
        public byte[] image { get; set; }
    }
}