﻿using System.ComponentModel.DataAnnotations;

namespace Priyank_P_301112923.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]

        public string Username { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
