using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace trytry.Models
{
    public class Sign_In
    {
        [Display(Name ="User Name")]
        [Required(ErrorMessage = "User_Name is required.")]
        public string UserName { get; set; }
        public Nullable<bool> Gender { get; set; }

        public Nullable<System.DateTime> DOB { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Please confirm your Password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}