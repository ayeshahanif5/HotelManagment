using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace trytry.Models
{
    public class Sign_In
    {
        [DisplayName("User_Name")]
        [Required(ErrorMessage = "User_Name is required.")]
        [StringLength(150)]
        [DataType(DataType.Text)]

        public string UserName { get; set; }



        [DisplayName("Gender")]
        [Required(ErrorMessage = "Gender is required.")]
        [StringLength(50)]


        public Nullable<bool> Gender { get; set; }


        [DisplayName("Dateofbirth")]
        [Required(ErrorMessage = "Dateofbirth is required.")]
        [StringLength(50)]
        [DataType(DataType.DateTime)]

        public Nullable<System.DateTime> DOB { get; set; }



        [DisplayName("address")]
        [Required(ErrorMessage = "address is required.")]
        [StringLength(150)]
        [DataType(DataType.PostalCode)]
        public string Address { get; set; }



        [Required(ErrorMessage = "city is required.")]
        [StringLength(150)]
        public string City { get; set; }



        [DisplayName("email")]
        [Required(ErrorMessage = "email is required.")]
        [StringLength(150)]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }


        [DisplayName("password")]
        [Required(ErrorMessage = "password is required.")]
        [StringLength(150)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DisplayName("password")]
        [Required(ErrorMessage = "password is required.")]
        [StringLength(150)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}