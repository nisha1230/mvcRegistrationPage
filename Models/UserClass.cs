using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvcRegistrationPage.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace mvcRegistrationPage.Models
{
    public class UserClass
    {
        [Required(ErrorMessage = "Enter First Name")]
        [Display(Name = "First Name")]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Enter Last Name")]
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "Enter Email id")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid. Please enter in the form abc@xyx.com")]
        [Display(Name = "Email id")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Passsword")]
        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 8 and 15 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        //[StringLength(15, MinimumLength = 8, ErrorMessage = "Name must be between 8 and 15 char")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter the Password again")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string Confirm_Password { get; set; }

    }
}