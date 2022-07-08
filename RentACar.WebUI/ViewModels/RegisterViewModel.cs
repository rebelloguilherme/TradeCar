﻿using System.ComponentModel.DataAnnotations;

namespace RentACar.WebUI.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords doens't match")]
        public string ConfirmPassword { get; set; }
    }
}
