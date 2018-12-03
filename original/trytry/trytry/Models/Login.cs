using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace trytry.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Please Enter your Email!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please Enter your Password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}