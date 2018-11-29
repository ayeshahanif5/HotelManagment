using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace trytry.Models.CityModel
{
    public class CityModel
    {
        [Required]
        [DataType(DataType.Text)]
        public int CityId { get; set; }


        [Required]
        [DataType(DataType.Text)]
        public string CityName { get; set; }

        
            
        
        public byte[] image { get; set; }
    }
}