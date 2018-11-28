using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace trytry.Models
{
    public class CityModel
    {
        public int CityId { get; set; }

        [DisplayName("City Name")]
        public string CityName { get; set; }
        public byte[] image { get; set; }
    }
}