using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MarketPlaceMVC.Models
{
    public class UserProfileMetadata
    {

        [Required(ErrorMessage = "Username required!")]
        public string username { get; set; }

        [Required(ErrorMessage = "Email required!")]
        public string email { get; set; }




        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }

    }
}